using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Meraki.Core.Patterns.UnitOfWorks
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext
    {
        private readonly TContext _contexto;
        public UnitOfWork(TContext contexto)
        {
            _contexto = contexto;
        }

        public async Task CommitAsync()
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

                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Rollback();
                throw new Exception("Erro ao salvar no banco", e);
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
                foreach (var entry in _contexto.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged))
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Unchanged;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao executar rollback", e);
            }
        }
    }
}
