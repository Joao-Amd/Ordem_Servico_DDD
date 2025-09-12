namespace Meraki.Core.Patterns.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Rollback();
    }
}
