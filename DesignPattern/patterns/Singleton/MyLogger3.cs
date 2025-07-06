namespace DesignPattern.patterns.Singleton
{
    // Eager initialization of Singleton pattern (饿汉式单例)
    internal class MyLogger3
    {
        // Eagerly create the single instance at type initialization
        private static readonly MyLogger3 instance = new MyLogger3();

        // Private constructor to prevent instantiation
        private MyLogger3()
        {
            Console.WriteLine("Logger3 Initialized");
        }

        // Public property to get the single instance of MyLogger3
        public static MyLogger3 Instance => instance;
            
        public void Log(string message)
        {
            Console.WriteLine($"[Log3]: {message}");
        }
    }
}