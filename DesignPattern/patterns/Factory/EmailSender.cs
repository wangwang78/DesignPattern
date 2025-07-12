namespace DesignPattern.patterns.Factory    
{
    public class EmailSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"📧 Email sent: {message}");
        }
    }
}
