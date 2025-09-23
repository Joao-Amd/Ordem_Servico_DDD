namespace Meraki.Core.Patterns.Validation
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
        string GetMessage(T entity);
    }
}
