using Meraki.Core.Interfaces;
using Meraki.Core.Patterns.Repositorys;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Meraki.Cadastros.Data.Patterns
{
    public class RepBase<T> : IRepBase<T>, IDisposable where T : class, IAggregateRoot
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public RepBase(ContextCadastros contexto)
        {
            _context = contexto;
            _dbSet = _context.Set<T>();
        }

        public bool Any()
        {
            return _dbSet.Any();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _dbSet.Any(exp);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<T> Get()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Inserir(T t)
        {
            _dbSet.Add(t);
        }
    }
}
