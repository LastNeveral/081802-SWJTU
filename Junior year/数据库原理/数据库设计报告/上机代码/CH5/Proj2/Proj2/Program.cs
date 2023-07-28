using System;
namespace Proj2
{
    public class TPoint 				//声明类TPoint
    {
        int x, y;
        public TPoint()                 //默认构造函数
        {
            x = 0; y = 0;
        }
        public TPoint(int x1, int y1)	//带参数的构造函数
        { 
            x = x1; y = y1;
        }
        ~TPoint()           //析构函数
        {
            Console.WriteLine("点=>({0},{1})", x, y);
        }
    }
    class Program
    {       
        static void Main(string[] args)
        {
            TPoint p1 = new TPoint();
            TPoint p2 = new TPoint(2, 6);
            TPoint p3 = new TPoint(8, 3);
        }
    }

}
