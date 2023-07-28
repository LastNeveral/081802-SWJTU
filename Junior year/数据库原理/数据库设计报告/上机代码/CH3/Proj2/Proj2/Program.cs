using System;

namespace Proj2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, tmp, x;
            Console.Write("a:");
            a = int.Parse(Console.ReadLine());
            Console.Write("b:");
            b = int.Parse(Console.ReadLine());
            Console.Write("c:");
            c = int.Parse(Console.ReadLine());
            if (a < b)        //a和b交换
            {
                tmp = a; a = b; b = tmp;
            }
            //以下总是a>b
            if (b > c)      //b>c，则从大到小为a,b,c
                x = b;
            else if (a > c) //b<c<a，则从大到小为a,c,b
                x = c;
            else             //b<c,a<c，则从大到小为从c,a,b
                x = a;
            Console.WriteLine("中间数是{0}",x);
        }
    }
}
