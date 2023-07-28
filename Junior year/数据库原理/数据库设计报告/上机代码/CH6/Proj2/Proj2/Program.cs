using System;

namespace Proj2
{
    public class Square		            //正方形类
    {
        protected double x;
        public Square(double x1)
        {
            x = x1;
        }
        public virtual double GetArea()	 //求面积方法
        {
            return x * x;
        }
    }
    public class Rectangle:Square   	//长方形类
    {
        private double y;
        public Rectangle(double x1, double y1):base(x1)
        { 
            y = y1;
        }
        public override double GetArea()	//求面积方法
        {
            return x * y;
        }
    }
    public class Circle :Square		        //圆类
    {
        public Circle(double r) : base(r) 
        { }
        public override double GetArea()	//求面积方法
        { 
            return Math.PI * x * x; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Square s = new Square(1.5);
            Rectangle r = new Rectangle(3,4);
            Circle c = new Circle(1.5);
            Console.WriteLine("正方形面积={0:F2}", s.GetArea());
            Console.WriteLine("长方形面积={0:F2}", r.GetArea());
            Console.WriteLine("圆面积={0:F2}", c.GetArea());
        }
    }
}
