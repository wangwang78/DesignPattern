namespace DesignPattern.patterns.Factory
{
    public class FactoryTest
    {
        public static void Process()
        {
            NotificationService.Notify(new EmailFactory(), "Welcome to our platform!");
            NotificationService.Notify(new SmsFactory(), "Your code is 123456.");
            NotificationService.Notify(new WeChatFactory(), "You have a new message.");
        }
    }
}
