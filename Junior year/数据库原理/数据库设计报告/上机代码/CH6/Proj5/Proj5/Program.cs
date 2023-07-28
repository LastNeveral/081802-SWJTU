using System;
using System.Collections;				//新增引用

namespace Proj5
{
    class Stud : IComparable		            //从接口派生
    {
        public int xh { set; get; }				//学号属性
        public string xm { set; get; }			//姓名属性
        public int fs { set; get; }				//分数属性
        public Stud(int no, string name, int degree)
        { xh = no; xm = name; fs = degree; }
        public void disp()				    //输出学生信息
        { 
            Console.WriteLine("\t{0}\t{1}\t{2}", xh, xm, fs); 
        }
        public int CompareTo(object obj)	//实现接口方法
        {
            Stud s = (Stud)obj;		//转换为Stud实例
            if (fs < s.fs) return 1;
            else if (fs == s.fs) return 0;
            else return -1;
        }
    }
    class Program
    {
        
        static void disparr(ArrayList myarr)	//输出所有学生信息
        {
            Console.WriteLine("\t学号\t姓名\t分数");
            foreach (Stud s in myarr)
                s.disp();
        }
        static void Main(string[] args)
        {
            int i, n = 4;
            ArrayList myarr = new ArrayList();
            Stud[] st = new Stud[4] { new Stud(1, "Smith", 82), new Stud(4, "John", 88),
				new Stud(3, "Mary", 95), new Stud(2, "Cherr", 60) };
            for (i = 0; i < n; i++)					//将对象添加到myarr集合中
                myarr.Add(st[i]);
            Console.WriteLine("排序前:");
            disparr(myarr);
            myarr.Sort();
            Console.WriteLine("按分数降序排序后:");
            disparr(myarr);
        }
    }

}
