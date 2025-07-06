using DesignPattern.patterns.Strategy.Models;

namespace DesignPattern.patterns.Strategy
{
    internal interface ISortStrategy
    {
        public  List<Product> Sort(List<Product> products);
    }
}
