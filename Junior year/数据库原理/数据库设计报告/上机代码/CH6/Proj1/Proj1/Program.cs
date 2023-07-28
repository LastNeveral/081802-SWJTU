using System;
namespace Proj1
{
    class A                 //基类A
    {
        private int x;
        public A(int x1)
        {
            x = x1;
            Console.WriteLine("调用A的重载构造函数");
        }
        ~A() { Console.WriteLine("调用A的析构函数:x={0}", x); }
    }
    class B : A         //从A派生出B
    {
        private int y;
        public B(int x1, int y1)
            : base(x1)
        {
            y = y1;
            Console.WriteLine("调用B的重载构造函数");
        }
        ~B() { Console.WriteLine("调用B的析构函数:y={0}", y); }
    }
    class C : B     //从B派生出C
    {
        private int z;
        public C(int x1, int y1, int z1)
            : base(x1, y1)
        {
            z = z1;
            Console.WriteLine("调用C的重载构造函数");
        }
        ~C() { Console.WriteLine("调用C的析构函数:z={0}", z); }
    }
    class Program
    {
        static void Main(string[] args)
        { C c = new C(1, 2, 3); }
    }

}
