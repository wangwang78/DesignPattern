# 工厂方法模式（Factory Method Pattern）笔记

## ✅ 定义

> 工厂方法模式定义一个用于创建对象的接口，让子类决定实例化哪一个类。工厂方法使一个类的实例化延迟到其子类。

---

## 📦 本质

* 将“对象的创建”延迟到子类或调用方
* 解耦对象的**使用**与**创建逻辑**
* 面向接口编程，符合开闭原则

---

## 🎯 适用场景

* 不希望客户端代码直接依赖具体类
* 对象的创建过程可能变化或很复杂
* 系统需要扩展时避免修改原有代码

---

## 🧱 模式结构

| 角色                | 说明                     |
| ----------------- | ---------------------- |
| `IProduct`        | 抽象产品接口                 |
| `ConcreteProduct` | 具体产品类，实现 `IProduct` 接口 |
| `IFactory`        | 抽象工厂接口，定义创建方法          |
| `ConcreteFactory` | 具体工厂类，创建某一类产品          |
| `Client`          | 客户端，通过工厂创建对象           |

---

## 🧪 示例：通知发送工厂

### 1. 抽象产品

```csharp
public interface INotificationSender
{
    void Send(string message);
}
```

### 2. 具体产品类

```csharp
public class EmailSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"📧 Email sent: {message}");
    }
}

public class SmsSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"📱 SMS sent: {message}");
    }
}
```

### 3. 抽象工厂接口

```csharp
public interface INotificationFactory
{
    INotificationSender CreateSender();
}
```

### 4. 具体工厂类

```csharp
public class EmailFactory : INotificationFactory
{
    public INotificationSender CreateSender() => new EmailSender();
}

public class SmsFactory : INotificationFactory
{
    public INotificationSender CreateSender() => new SmsSender();
}
```

### 5. 客户端

```csharp
public class NotificationService
{
    public void Notify(INotificationFactory factory, string message)
    {
        var sender = factory.CreateSender();
        sender.Send(message);
    }
}
```

### 使用示例

```csharp
var service = new NotificationService();
service.Notify(new EmailFactory(), "Welcome!");
service.Notify(new SmsFactory(), "Your code is 123456.");
```

---

## ✅ 优点

| 优点        | 说明            |
| --------- | ------------- |
| ✅ 符合开闭原则  | 新增产品类无需修改旧代码  |
| ✅ 解耦创建与使用 | 客户端无需知道如何创建产品 |
| ✅ 可扩展     | 支持任意产品扩展和创建逻辑 |

---

## ❗缺点

* 类数量可能变多（每个产品一个工厂类）
* 简单场景下显得“过度设计”

---

## 🛠️ 实际工程优化方式

### ✅ 简单工厂模式（Simple Factory）

```csharp
public static class NotificationFactory
{
    public static INotificationSender Create(string type)
    {
        return type switch
        {
            "email" => new EmailSender(),
            "sms" => new SmsSender(),
            _ => throw new NotSupportedException()
        };
    }
}
```

### ✅ Dictionary 注册表（支持动态扩展）

```csharp
public static class SenderRegistry
{
    private static readonly Dictionary<string, Func<INotificationSender>> _map = new();

    public static void Register(string key, Func<INotificationSender> creator) => _map[key] = creator;

    public static INotificationSender Create(string key) => _map.TryGetValue(key, out var f) ? f() : throw new();
}
```

---

## ✅ 总结

> 工厂方法模式将“创建对象”封装起来，避免客户端依赖具体类。它强调：**让使用者只依赖接口，不依赖具体实现**。

📌 如果创建逻辑复杂、产品族可变，建议使用工厂方法；如果对象创建非常简单，可使用简单工厂或策略模式替代。
