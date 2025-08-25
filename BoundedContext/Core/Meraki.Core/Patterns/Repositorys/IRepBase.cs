using Meraki.Core.Interfaces;
using Meraki.Core.Patterns.Repositorys.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Meraki.Core.Patterns.Repositorys
{
    public interface IRepBase<T, TContext> : IDisposable
        where T : IAggregateRoot
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
        Task<PaginationResult<TViewModel>> ListarPaginadoAsync<TViewModel>(int pagina,int tamanhoPagina, Func<T, TViewModel> map);
        Task<List<T>> Teste(int pagina, int tamanhoPagina);
    }
}
