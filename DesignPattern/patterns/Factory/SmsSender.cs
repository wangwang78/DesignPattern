namespace DesignPattern.patterns.Factory
{
    public class SmsSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"📱 SMS sent: {message}");
        }
    }
}
