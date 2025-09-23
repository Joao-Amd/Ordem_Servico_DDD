using Meraki.Core.Notificador;

namespace Meraki.Core.Patterns.Validation
{
    public class Validation<T>
    {
        private readonly List<ISpecification<T>> _specifications = [];
        private readonly INotification _notification;

        public Validation(INotification notification)
        {
            _notification = notification;
        }

        public void AddSpecification(ISpecification<T> specification)
        {
            _specifications.Add(specification);
        }

        public void Validate(T entity)
        {
            var errors = _specifications.Where(x => !x.IsSatisfiedBy(entity));

            _notification.ToAddNotifications(errors.Select(e => e.GetMessage(entity)).ToList());
        }
    }
}
