using System;

namespace Proj5
{
    class AddClass
    {
        public int addvalue(int a, int b)				//方法重载1
        { return a + b; }
        public int addvalue(int a, int b, int c)			//方法重载2
        { return a + b + c; }
        public double addvalue(double a, double b)		//方法重载3
        { return a + b; }
        public double addvalue(double a, double b, double c)	//方法重载4
        { return a + b + c; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AddClass s = new AddClass();
            Console.WriteLine("2个整数相加：{0}",s.addvalue(1, 2));
            Console.WriteLine("3个整数相加：{0}", s.addvalue(1, 2, 3));
            Console.WriteLine("2个实数相加：{0}", s.addvalue(2.5, 3.5));
            Console.WriteLine("3个实数相加：{0}", s.addvalue(1.2, 2.8, 8.5));
        }
    }

}
