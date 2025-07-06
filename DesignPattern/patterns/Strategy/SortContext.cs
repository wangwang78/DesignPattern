using DesignPattern.patterns.Strategy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.patterns.Strategy
{
    internal class SortContext
    {
        private ISortStrategy _sortStrategy;

        public SortContext(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

      public List<Product> Sort(List<Product> products)
        {
            if (_sortStrategy == null)
            {
                throw new ArgumentNullException(nameof(_sortStrategy), "Sort strategy cannot be null");
            }
            return _sortStrategy.Sort(products);
        }
    }
}
