using System;

namespace Exp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("输入一个正整数:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("十进制数:{0}",n);
            Console.WriteLine("二进制数:{0}", Convert.ToString(n,2));
            Console.WriteLine("八进制数:{0}", Convert.ToString(n,8));
            Console.WriteLine("十六进制:{0}", Convert.ToString(n,16).ToUpper());
        }
    }
}
