using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.patterns.Singleton
{
    // use（Double-Checked Locking）implementation of Singleton pattern of thread-safe 
    internal class MyLogger2
    {
        private static MyLogger2? _instance;

        private static readonly object _lock = new object();

        // Private constructor to prevent instantiation
        private MyLogger2()
        {
            Console.WriteLine("Logger Initialized");
        }

        // Public method to get the single instance of MyLogger2
        public static MyLogger2 GetInstance()
        {
            if (_instance == null) 
            {
                lock (_lock)
                {
                    if (_instance == null) // double null check
                    {
                        _instance = new MyLogger2();
                    }
                }
            }
            return _instance;
        }

        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }
}
