namespace DesignPattern.patterns.Strategy.Models
{
    internal class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public double Price { get; set; } // 价格

        public double Rate { get; set; } // 评分

        public int SalesVolume { get; set; } // 销量
    }
}
