namespace Meraki.Core.Notificador
{
    public interface INotification
    {
        bool Notified { get; }
        List<string> Message { get; }
        void ToAddNotification(string mensage);
        void ToAddNotifications(List<string> mensages);
        void ClearNotification();
    }
}
    