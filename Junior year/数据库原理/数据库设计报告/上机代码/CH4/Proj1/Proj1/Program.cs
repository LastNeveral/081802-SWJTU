using System;

namespace Proj1
{
    class Program
    {
        static void Main(string[] args)
        {
            var weekdays = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            var time = DateTime.Now;
            Console.Write("{0}年{1}月{2}日是",time.Year,time.Month,time.Day);
            Console.WriteLine(weekdays[(int)time.DayOfWeek]);
        }
    }
}
