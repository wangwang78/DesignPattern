namespace DesignPattern.patterns.SimpleFactory
{
    public interface IMessageSender
    {
        void Send(string message);
    }

    public class EmailSender : IMessageSender
    {
        public void Send(string message) => Console.WriteLine($"Email: {message}");
    }

    public class SmsSender : IMessageSender
    {
        public void Send(string message) => Console.WriteLine($"SMS: {message}");
    }

    public class MessageSenderFactory
    {
        public static IMessageSender Create(string type)
        {
            return type switch
            {
                "email" => new EmailSender(),
                "sms" => new SmsSender(),
                _ => throw new NotImplementedException()
            };
        }
    }

}
