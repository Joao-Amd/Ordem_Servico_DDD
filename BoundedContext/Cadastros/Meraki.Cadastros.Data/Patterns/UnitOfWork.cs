using Meraki.Core.Patterns.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace Meraki.Cadastros.Data.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextCadastros _contexto;
        public UnitOfWork(ContextCadastros contexto)
        {
            _contexto = contexto;
        }

        public void Commit()
        {
            try
            {
                foreach (object item in from x in _contexto.ChangeTracker.Entries()
                                        where x.State == EntityState.Added
                                              || x.State == EntityState.Modified
                                        select x.Entity)
                {
                    ValidationContext validationContext = new ValidationContext(item);
                    Validator.ValidateObject(item, validationContext);
                }
                _contexto.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Rollback();
                throw new Exception(e.Message);
            }
            catch (ValidationException e)
            {
                Rollback();
                throw new Exception(e.Message);
            }
        }

        public void Rollback()
        {
            try
            {
                foreach (EntityEntry item in (from x in _contexto.ChangeTracker.Entries() where x.State != EntityState.Unchanged select x).ToList())
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            item.CurrentValues.SetValues(item.OriginalValues);
                            item.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            item.State = EntityState.Detached;
                            break;
                        case EntityState.Deleted:
                            item.State = EntityState.Unchanged;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
