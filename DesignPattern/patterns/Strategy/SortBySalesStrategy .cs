using DesignPattern.patterns.Strategy.Models;

namespace DesignPattern.patterns.Strategy
{
    internal class SortBySalesStrategy : ISortStrategy
    {
        public List<Product> Sort(List<Product> products)
        {
            return products.OrderByDescending(p => p.SalesVolume).ToList();
        }
    }
}
