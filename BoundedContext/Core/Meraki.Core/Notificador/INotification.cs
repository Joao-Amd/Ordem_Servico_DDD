namespace Meraki.Core.Notificador
{
    public interface INotification
    {
        bool Notified { get; }
        List<string> Message { get; }
    }
}
