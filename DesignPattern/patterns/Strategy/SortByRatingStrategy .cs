using DesignPattern.patterns.Strategy.Models;

namespace DesignPattern.patterns.Strategy
{
    internal class SortByRatingStrategy : ISortStrategy
    {
        public List<Product> Sort(List<Product> products)
        {
           return products.OrderByDescending(p => p.Rate).ToList();
        }
    }
}
