using Meraki.Core.Base.QuerysParams;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Meraki.Core.Patterns.Repositorys
{
    public interface IRepBase<T, TContext> 
        where T : class
        where TContext : DbContext
    {
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task DeleteAsync(int id);
        Task DeleteAsync(Guid id);
        Task<List<T>> GetAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(Guid id);
        Task InserirAsync(T entity);
        Task InserirAsync(List<T> entitys);
        IQueryable<T> Where(Expression<Func<T, bool>> exp);
        T? FirstOrDefault(Expression<Func<T, bool>> exp);
        IQueryable<T> Include(params string[] includes);
        Task<List<TView>> ListarPaginadoAsync<TView>(QueryParams query) where TView : class, new();
    }
}
