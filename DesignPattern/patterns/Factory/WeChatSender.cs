namespace DesignPattern.patterns.Factory
{
    public class WeChatSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"💬 WeChat message sent: {message}");
        }
    }
}
