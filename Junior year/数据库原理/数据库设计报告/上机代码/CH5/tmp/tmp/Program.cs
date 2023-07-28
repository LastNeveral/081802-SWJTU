using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmp
{
    class Triangle
    {
        public void Perimeter(double a, double b, double c,ref double per)
        {
            per = a + b + c;
        }
        public void Area(double a, double b, double c,ref double area)
        {
            double d = (a + b + c) / 2;
            area = Math.Sqrt(d * (d - a) * (d - b) * (d - c));
        }
        public bool valid(double x, double y, double z)
        {
            if ((x + y > z && x - y < z) && (x + z > y && x - z < y) && (y + z > x && y  -z <x))
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args) 
        {
            Triangle tr = new Triangle(); 
            double x, y, z;
            double per = 0, area = 0;
            Console.WriteLine("输入三角形的三边");
            Console.Write("x:");  x = double.Parse(Console.ReadLine());
            Console.Write("y:"); y = double.Parse(Console.ReadLine());
            Console.Write("z:"); z = double.Parse(Console.ReadLine()); 
            if (tr.valid(x,y,z))
            {
                tr.Perimeter(x, y, z, ref per);
                tr.Area(x,y,z,ref area);
                Console.WriteLine("三角形的周长为{0}",per); 
                Console.WriteLine("三角形的面积为{0}", area); 
            } 
            else 
                Console.WriteLine("三角形三边不合法"); 
        }
    }
}
