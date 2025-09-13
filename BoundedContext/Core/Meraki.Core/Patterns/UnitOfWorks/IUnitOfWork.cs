using Microsoft.EntityFrameworkCore;

namespace Meraki.Core.Patterns.UnitOfWorks
{
    public interface IUnitOfWork<TContext>
       where TContext : DbContext
    {
        Task CommitAsync();
        void Rollback();
    }
}
