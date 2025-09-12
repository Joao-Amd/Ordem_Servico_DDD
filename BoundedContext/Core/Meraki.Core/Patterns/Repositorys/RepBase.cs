using Meraki.Core.Base.QuerysParams;
using Meraki.Core.Interfaces;
using Meraki.Core.Mappers;
using Meraki.Core.Patterns.Repositorys;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Meraki.Cadastros.Data.Patterns
{
    public class RepBase<T, TContext> : IRepBase<T, TContext>, IDisposable
        where T : class
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

        public async Task<List<TView>> ListarPaginadoAsync<TView>(QueryParams queryParams)
            where TView : class, new()
        {
            try
            {
                var mapper = new Mapper();
                var expression = mapper.ToMapper<T, TView>();
                var mapFunc = expression.Compile();

                var query = _dbSet.AsQueryable();

                var propriedades = typeof(T).GetProperties().Select(p => p.Name).ToHashSet(StringComparer.OrdinalIgnoreCase);

                if (!string.IsNullOrEmpty(queryParams.SearchBy) && !string.IsNullOrEmpty(queryParams.SearchTerm))
                {
                    if (!propriedades.Contains(queryParams.SearchBy))
                        throw new ArgumentException($"Propriedade '{queryParams.SearchBy}' não encontrada na entidade {typeof(T).Name}.");

                    query = query.Where(e =>
                        EF.Functions.Like(EF.Property<string>(e, queryParams.SearchBy), $"%{queryParams.SearchTerm}%"));
                }

                if (!string.IsNullOrEmpty(queryParams.SortBy) && propriedades.Contains(queryParams.SortBy))
                {
                    query = queryParams.SortDescending
                        ? query.OrderByDescending(e => EF.Property<object>(e, queryParams.SortBy))
                        : query.OrderBy(e => EF.Property<object>(e, queryParams.SortBy));
                }

                var entidades = await query
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                return entidades.Select(mapFunc).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao listar dados paginados {ex.Message}");
            }
        }
    }
}
