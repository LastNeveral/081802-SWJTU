using System;

namespace Proj4
{
    class Program
    {
        static void Main(string[] args)
        {
            int year, month, day;
            Console.Write("输入年:");
            year = int.Parse(Console.ReadLine());
            Console.Write("输入月:");
            month = int.Parse(Console.ReadLine());
            Console.Write("输入日:");
            day = int.Parse(Console.ReadLine());
            DateTime d = new DateTime(year, month,day);
            Console.WriteLine("{0}年是否为闰年：{1}", year,DateTime.IsLeapYear(year)); //静态方法调用
            Console.WriteLine("该日期是{0}",d.DayOfWeek);  //使用属性
            Console.WriteLine("该日期是本年的第{0}天", d.DayOfYear);
        }
    }
}
