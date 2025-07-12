namespace DesignPattern.patterns.Factory
{
    public class NotificationService
    {
        public static void Notify(INotificationFactory factory, string message)
        {
            var sender = factory.CreateSender();    
            sender.Send(message);
        }
    }
}
