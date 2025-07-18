namespace Meraki.Core.Patterns.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
