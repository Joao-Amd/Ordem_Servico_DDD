using Meraki.Core.Interfaces;
using Meraki.Core.Patterns.Repositorys;
using Meraki.Core.Patterns.Repositorys.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Meraki.Cadastros.Data.Patterns
{
    public class RepBase<T, TContext> : IRepBase<T, TContext>, IDisposable
        where T : class, IAggregateRoot
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<T> _dbSet;

        public RepBase(TContext contexto)
        {
            _context = contexto;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> AnyAsync()
        {
            return await _dbSet.AnyAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _dbSet.AnyAsync(exp);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<List<T>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task InserirAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<PaginationResult<TViewModel>> ListarPaginadoAsync<TViewModel>(
            int pagina,
            int tamanhoPagina,
            Func<T, TViewModel> map)
        {
            var total = await _dbSet.CountAsync();
            var totalPaginas = (int)Math.Ceiling(total / (double)tamanhoPagina);

            var entidades = await _dbSet
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            var viewModels = entidades.Select(map);

            return new PaginationResult<TViewModel>
            {
                Total = total,
                PaginaAtual = pagina,
                TotalPaginas = totalPaginas,
                Content = viewModels
            };
        }

        public async Task<List<T>> Teste(int pagina, int tamanhoPagina)
        {
            var entidades = await _dbSet
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            return entidades;
        }
    }
}
