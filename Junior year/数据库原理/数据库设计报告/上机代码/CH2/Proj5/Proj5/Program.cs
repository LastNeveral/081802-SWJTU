using System;

namespace Proj5
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d = DateTime.Now;
            Console.WriteLine("今天是：{0},{1}", d.ToString("yyyy-mm-dd"), d.DayOfWeek.ToString());
        }
    }
}
