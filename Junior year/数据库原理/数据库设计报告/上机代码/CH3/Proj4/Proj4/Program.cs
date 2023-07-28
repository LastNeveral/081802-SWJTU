using System;
namespace Proj4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("n:");
            n = int.Parse(Console.ReadLine());
            int total = 0, i = 1, m = 1;
            while (i <= n)
            {
                m *= i;
                total += m;
                i++;
            }
            Console.WriteLine("计算结果={0}", total);
        }
    }
}
