using System;
using System.Collections; 

namespace Exp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr1 = new ArrayList();   //奇数容器
            ArrayList arr2 = new ArrayList();   //偶数容器
            string str;                         //输入整数字符串 
            Console.Write("输入若干整数:");
            str = Console.ReadLine();
            string[] strtemp = str.Split(' ');  //分解 
            int n;
            foreach (string item in strtemp)
            {
                n = int.Parse(item);
                if (n % 2 == 1)
                    arr1.Add(n);                //加入奇数容器
                else
                    arr2.Add(n);                //加入偶数容器
            }
            Console.WriteLine("奇数个数：{0}；偶数个数：{1}", arr1.Count,arr2.Count);
            Console.Write("所有奇数：");
            Disp(arr1);
            Console.Write("排序后：");
            arr1.Sort();
            Disp(arr1);
            Console.Write("所有偶数：");
            Disp(arr2);
            Console.Write("排序后：");
            arr2.Sort();
            Disp(arr2);
        }
        static void Disp(ArrayList arr)     //输出一个arr对象的元素
        {
            foreach (int item in arr)
                Console.Write("{0} ", item);
            Console.WriteLine();
        }
    }
}
