using DesignPattern.patterns.Strategy.Models;

namespace DesignPattern.patterns.Strategy
{
    internal class SortByPriceStrategy : ISortStrategy
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderBy(p => p.Price).ToList();
        }
    }
}
