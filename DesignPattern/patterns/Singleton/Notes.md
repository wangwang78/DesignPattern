# Double-Checked Locking in Singleton Pattern (C#)

## 🔍 Why Double Null Check?

Double-checked locking is a common pattern in implementing a thread-safe singleton with lazy initialization.

Here's a sample implementation:

```csharp
public static MyLogger2 GetInstance()
{
    if (_instance == null) // First check
    {
        lock (_lock)
        {
            if (_instance == null) // Second check
            {
                _instance = new MyLogger2();
            }
        }
    }
    return _instance;
}
```

## ✅ First `if (_instance == null)` - Performance Optimization

* Avoids acquiring lock **every time** the method is called.
* After the singleton is initialized, this check prevents unnecessary locking.
* Significantly improves performance when method is accessed frequently.

## ✅ Second `if (_instance == null)` - Thread Safety Guarantee

Even with the first check, **multiple threads can pass it simultaneously**.

### Scenario:

1. Thread A: enters `if (_instance == null)` and pauses right before `lock`.
2. Thread B: does the same.
3. Thread A acquires the lock and initializes `_instance`.
4. Thread B acquires the lock **after A**, and without the second check, it **would overwrite** the singleton.

The **second null check ensures** that only one instance is created, even under concurrency.

---

## 🔄 What Happens Without Second Null Check?

* Multiple threads can create multiple instances.
* Violates the core idea of the singleton pattern (only one instance).

---

## ✅ Summary

| Purpose           | Explanation                                                   |
| ----------------- | ------------------------------------------------------------- |
| First null check  | Avoids locking when instance is already created (performance) |
| Second null check | Guarantees only one instance under multi-threading            |

---

## 📆 Modern Recommended C# Approach

Since C# 4.0+, you can avoid manual locking by using `Lazy<T>`:

```csharp
private static readonly Lazy<MyLogger2> _instance = new(() => new MyLogger2());

public static MyLogger2 Instance => _instance.Value;
```

* Thread-safe
* Lazy initialization
* Cleaner, easier to read and maintain

---

## 🔮 Bonus: What is CLR?

**CLR (Common Language Runtime)** is the execution engine for .NET programs. It handles:

* Memory management (Garbage Collection)
* Type safety
* Thread scheduling
* Exception handling
* **Thread synchronization**, including in `Lazy<T>`

> `Lazy<T>`'s thread safety is internally implemented by the CLR using double-checked locking and other concurrency features.

---

## 📈 Conclusion

Double-checked locking is a powerful pattern, but it's easy to misuse.

* In modern C#, **prefer `Lazy<T>`** for thread-safe lazy singletons.
* Use manual `lock` logic only if you need very fine-grained control.
