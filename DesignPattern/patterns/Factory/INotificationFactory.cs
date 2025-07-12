namespace DesignPattern.patterns.Factory
{
    public interface INotificationFactory
    {
         public INotificationSender CreateSender();
    }

    public class EmailFactory : INotificationFactory
    {
        public INotificationSender CreateSender() => new EmailSender();
    }

    public class SmsFactory : INotificationFactory
    {
        public INotificationSender CreateSender() => new SmsSender();
    }

    public class WeChatFactory : INotificationFactory
    {
        public INotificationSender CreateSender() => new WeChatSender();
    }

}
