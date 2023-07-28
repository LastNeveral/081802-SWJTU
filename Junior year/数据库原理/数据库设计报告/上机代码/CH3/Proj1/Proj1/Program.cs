using System;

namespace Proj1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("分数:");
            n = int.Parse(Console.ReadLine());
            if (n < 0 || n > 100)
                Console.WriteLine("分数输入错误");
            else
                Console.WriteLine("分数输入正确");
        }
    }
}
