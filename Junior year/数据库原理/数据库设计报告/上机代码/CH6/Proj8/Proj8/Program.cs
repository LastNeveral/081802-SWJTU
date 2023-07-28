using System;
using System.Collections.Generic;

namespace Proj8
{
    class Stud : IComparable<Stud>	    //声明Stud类
	{
        public int xh { set;get; }      //学号属性
        public string xm { set; get; }  //姓名
        public Stud(int xh, string xm)
        {
            this.xh = xh; this.xm = xm;
        }
        public void dispstud()         //输出学生信息
        {
            Console.WriteLine("  学号:{0},姓名:{1}",xh,xm);
        }
        public int CompareTo(Stud obj)  //实现接口方法
        {
            Stud s = (Stud)obj;		//转换为Stud实例
			if (xh > s.xh) return 1;
			else if (xh == s.xh) return 0;
			else return -1;
		}
	}
    class Program
    {
        static void Main(string[] args)
        {
            List<Stud> mylist = new List<Stud>();
            mylist.Add(new Stud(1, "Mary"));
            mylist.Add(new Stud(3, "Smith"));
            mylist.Add(new Stud(5, "John"));
            mylist.Add(new Stud(4, "Skinner"));
            mylist.Add(new Stud(2, "Hammer"));
            Console.WriteLine("排序前：");
            foreach (Stud item in mylist)
                item.dispstud();
            mylist.Sort();
            Console.WriteLine("按学号递增排序后：");
            foreach (Stud item in mylist)
                item.dispstud();


        }
    }
}
