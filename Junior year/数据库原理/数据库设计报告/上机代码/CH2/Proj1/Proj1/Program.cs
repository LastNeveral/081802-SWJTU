using System;
namespace Proj1
{
    class MyClass
    {
        int n;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b;
            b = a;
            Console.WriteLine("a、b的值是否相等:{0}",object.Equals(a,b));
            Console.WriteLine("a、b的引用是否相等:{0}", object.ReferenceEquals(a, b));
            MyClass obj1 = new MyClass();
            MyClass obj2 = new MyClass();
            Console.WriteLine("obj1、obj2的值是否相等:{0}", object.Equals(obj1, obj2));
            Console.WriteLine("obj1、obj2的引用是否相等:{0}", object.ReferenceEquals(obj1, obj2));
            obj2 = obj1;
            Console.WriteLine("执行obj2=obj1");
            Console.WriteLine("obj1、obj2的值是否相等:{0}", object.Equals(obj1, obj2));
            Console.WriteLine("obj1、obj2的引用是否相等:{0}", object.ReferenceEquals(obj1, obj2));
        }
    }
}
