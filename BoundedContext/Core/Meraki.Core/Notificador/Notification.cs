namespace Meraki.Core.Notificador
{
    public class Notification : INotification
    {
        public bool Notified { get; private set; }
        public List<string> Message { get; private set; } = new List<string>();

        public void ToAddNotification (string mensagem)
        {
            Notified = true;
            Message.Add(mensagem);
        }

        public void ClearNotification()
        {
            Notified = false;
            Message.Clear();
        }
    }
}
