using DesignPattern.patterns.Strategy.Models;

namespace DesignPattern.patterns.Strategy
{
    internal class StrategyTest
    {
        private static readonly List<Product> products =
        [
                new Product { Id = 1, Name = "iPhone 15", Price = 999.99, Rate = 4.8, SalesVolume = 12000 },
                new Product { Id = 2, Name = "Samsung Galaxy S24", Price = 899.50, Rate = 4.5, SalesVolume = 8000 },
                new Product { Id = 3, Name = "Xiaomi 14", Price = 699.99, Rate = 4.6, SalesVolume = 15000 },
                new Product { Id = 4, Name = "OnePlus 12", Price = 749.00, Rate = 4.3, SalesVolume = 5000 },
                new Product { Id = 5, Name = "Huawei Mate 60", Price = 829.00, Rate = 4.7, SalesVolume = 10000 },
                new Product { Id = 6, Name = "Google Pixel 8", Price = 799.00, Rate = 4.4, SalesVolume = 4000 }
         ];

        public static void Process()
        {
            SortContext sortContext;
            sortContext = new SortContext(new SortByPriceStrategy());

            sortContext.Sort(products).ForEach(p => Console.WriteLine($"Name: {p.Name}, Price: {p.Price}"));

            Console.WriteLine("==================================");
            sortContext = new SortContext(new SortByRatingStrategy());

            sortContext.Sort(products).ForEach(p => Console.WriteLine($"Name: {p.Name}, Rate: {p.Rate}"));


            Console.WriteLine("==================================");
            sortContext = new SortContext(new SortBySalesStrategy());

            sortContext.Sort(products).ForEach(p => Console.WriteLine($"Name: {p.Name}, SalesVolume: {p.SalesVolume}"));


        }
    }
}
