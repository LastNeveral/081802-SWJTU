using System;
namespace Proj4
{
    interface IShape			        //接口声明
    {
        double GetArea();               //接口成员声明
    }
    public class Square : IShape			//正方形类
    {
        double x;
        public Square(double x1)
        {
            x = x1;
        }
        public double GetArea()	    //隐式接口成员实现
        {
            return x * x;
        }
    }
    public class Rectangle : IShape		//长方形类
    {
        double x, y;
        public Rectangle(double x1, double y1)
        {
            x = x1; y = y1;
        }
        public double GetArea()	//隐式接口成员实现
        {
            return x * y;
        }
    }
    public class Circle : IShape			//圆类
    {
        double r;
        public Circle(double r1)
        {
            r = r1;
        }
        public double GetArea()	        //隐式接口成员实现
        {
            return Math.PI * r * r;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Square s = new Square(1.5);
            Rectangle r = new Rectangle(3, 4);
            Circle c = new Circle(1.5);
            Console.WriteLine("正方形面积={0:F2}", s.GetArea());
            Console.WriteLine("长方形面积={0:F2}", r.GetArea());
            Console.WriteLine("圆面积={0:F2}", c.GetArea());
        }
    }
}
