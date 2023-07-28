using System;

namespace Exp
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, z;
            for (x=1;x<=100;x++)
                for (y = 1; y <= 100; y++)
                {
                    z = 100 - x - y;
                    if (15 * x + 9 * y + z == 300)
                        Console.WriteLine("鸡翁:{0},鸡母:{1},鸡雏:{2}", x, y, z);
                }
        }
    }
}
