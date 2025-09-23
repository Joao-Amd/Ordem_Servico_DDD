namespace Meraki.Core.Notificador
{
    public class Notification : INotification
    {
        public bool Notified { get; private set; }
        public List<string> Message { get; private set; } = [];

        public void ToAddNotification (string mensage)
        {
            Notified = true;
            Message.Add(mensage);
        }

        public void ToAddNotifications(List<string> mensages)
        {
            Notified = true;
            Message.AddRange(mensages);
        }

        public void ClearNotification()
        {
            Notified = false;
            Message.Clear();
        }
    }
}
