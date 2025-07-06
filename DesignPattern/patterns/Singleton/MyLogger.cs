namespace DesignPattern.patterns.Singleton
{
    //lazy initialization of Singleton pattern of thread-safe
    internal class MyLogger
    {
        //thread-safe lazy initialization using Lazy<T>
        private static readonly Lazy<MyLogger> instance = new(() => new MyLogger());

        //private constructor to prevent instantiation
        private MyLogger()
        {
            Console.WriteLine("Logger Initialized");
        }

        // public property to get the single instance of MyLogger
        public static MyLogger Instance => instance.Value;

        public void Log(string message)
        {
            Console.WriteLine($"[Log]: {message}");
        }
    }
}
