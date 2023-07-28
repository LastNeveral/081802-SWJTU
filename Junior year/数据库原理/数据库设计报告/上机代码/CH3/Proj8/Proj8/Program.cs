using System;
namespace Proj8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int total = 0, i, m;
            m = 0;
            for (i = 1; i <= n; i++)
            {
                m += i;
                total += m;
            }
            Console.WriteLine("计算结果:{0}",total);
        }
    }
}
