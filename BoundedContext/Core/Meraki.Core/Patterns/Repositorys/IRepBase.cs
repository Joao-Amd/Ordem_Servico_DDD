using Meraki.Core.Interfaces;
using System.Linq.Expressions;

namespace Meraki.Core.Patterns.Repositorys
{
    public interface IRepBase<T> : IDisposable where T : IAggregateRoot
    {
        T GetById(int id);
        T GetById(Guid id);
        List<T> Get();
        void Inserir(T t);
        void Delete(int id);
        void Delete(Guid id);
        bool Any();
        bool Any(Expression<Func<T, bool>> exp);
    }
}
