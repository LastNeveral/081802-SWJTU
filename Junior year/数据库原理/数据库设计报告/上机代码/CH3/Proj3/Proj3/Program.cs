using System;
namespace Proj3
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d=DateTime.Now;
            int n = (int)d.DayOfWeek;
            switch(n)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("{0}年{1}月{2}日我工作", d.Year, d.Month, d.Day);
                    break;
                case 0:
                case 6:
                    Console.WriteLine("{0}年{1}月{2}日我休息",d.Year,d.Month,d.Day);
                    break;
            }
        }
    }
}
