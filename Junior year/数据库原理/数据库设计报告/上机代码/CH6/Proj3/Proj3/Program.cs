using System;

namespace Proj3
{
    public abstract class Shape        //抽象类声明
    {
        abstract public double GetArea();	//抽象方法声明
    }
    public class Square:Shape		     //正方形类
    {
        double x;
        public Square(double x1)
        {
            x = x1;
        }
        public override double GetArea()	//抽象方法实现
        {
            return x * x;
        }
    }
    public class Rectangle : Shape   	//长方形类
    {
        double x,y;
        public Rectangle(double x1, double y1)
        {
            x = x1; y = y1;
        }
        public override double GetArea()	//求面积方法
        {
            return x * y;
        }
    }
    public class Circle : Shape		        //圆类
    {
        double r;
        public Circle(double r1)
        {
            r = r1;
        }
        public override double GetArea()	//求面积方法
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
