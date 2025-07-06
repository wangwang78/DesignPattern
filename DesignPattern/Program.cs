
using DesignPattern.patterns.Singleton;

var instance1 = MyLogger3.Instance;
var instance2 = MyLogger3.Instance;

Console.WriteLine(ReferenceEquals(instance1, instance2));

instance1.Log("some logs");

instance2.Log("some other logs");
