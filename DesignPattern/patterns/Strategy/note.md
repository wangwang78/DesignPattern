# 策略模式（Strategy Pattern）笔记

## ✅ 定义

策略模式定义了一系列算法（或行为），并将每个算法封装到独立的类中，使它们可以相互替换。策略模式让算法的变化独立于使用它的客户端。

> 本质：**将行为封装为独立策略类，根据上下文选择不同策略执行**。

---

## 🎯 应用场景

* 避免冗长的 if-else / switch 语句
* 允许用户根据配置或上下文选择行为
* 多种可互换的处理方式（如排序、支付、导出等）

---

## 🧱 角色组成

| 角色                 | 说明                |
| ------------------ | ----------------- |
| `Context`          | 上下文类，持有策略并调用策略方法  |
| `IStrategy`        | 抽象策略接口，定义算法行为方法   |
| `ConcreteStrategy` | 具体策略实现类，封装不同算法或逻辑 |

---

## ✅ 示例：商品排序

### 模型类

```csharp
internal class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public double Price { get; set; }
    public double Rate { get; set; }
    public int SalesVolume { get; set; }
}
```

### 策略接口

```csharp
internal interface ISortStrategy
{
    List<Product> Sort(List<Product> products);
}
```

### 具体策略类

```csharp
internal class SortByPriceStrategy : ISortStrategy
{
    public List<Product> Sort(List<Product> products)
        => products.OrderBy(p => p.Price).ToList();
}

internal class SortByRatingStrategy : ISortStrategy
{
    public List<Product> Sort(List<Product> products)
        => products.OrderByDescending(p => p.Rate).ToList();
}

internal class SortBySalesStrategy : ISortStrategy
{
    public List<Product> Sort(List<Product> products)
        => products.OrderByDescending(p => p.SalesVolume).ToList();
}
```

### 上下文类

```csharp
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
            throw new ArgumentNullException("Sort strategy cannot be null");

        return _sortStrategy.Sort(products);
    }
}
```

### 使用方式

```csharp
var products = new List<Product> { ... };

var context = new SortContext(new SortByPriceStrategy());
var sortedByPrice = context.Sort(products);
```

---

## ✅ 优点

* 避免重复代码和 if-else
* 遵循开闭原则：新增策略无需修改原有逻辑
* 每个策略类职责单一，易于维护和测试

## ❗缺点

* 策略类数量可能增多
* 客户端需要了解所有策略并选择合适的

---

## ✅ 实际项目中常见做法

### 注入所有策略（使用 DI）

* 将所有策略注册到容器中
* 注入 `IEnumerable<IStrategy>`，根据条件动态选择

### 动态选择策略（运行时）

* 可基于配置、用户输入、枚举等动态选择策略类

---

## 🏁 总结

> 策略模式适用于 **有多个可替代处理方式的场景**，将行为封装成可独立扩展、替换的类，提升系统扩展性与可维护性。
