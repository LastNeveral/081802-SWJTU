using System;
using System.Collections;				//新增引用

namespace Proj6
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
    public class myCompareClassxh : IComparer	//从接口派生myCompareClassxh类
    {
        int IComparer.Compare(object x, object y)	//实现Compare方法
        {
            Stud a = (Stud)x;					//将x对象转换成Stud类对象a
            Stud b = (Stud)y; 					//将y对象转换成Stud类对象b
            if (a.xh > b.xh) return 1;
            else if (a.xh == b.xh) return 0;
            else return -1;
        }
    }
    public class myCompareClassxm : IComparer	//从接口派生myCompareClassxm类
    {
        int IComparer.Compare(object x, object y)	//实现Compare方法
        {
            Stud a = (Stud)x;					//将x对象转换成Stud类对象a
            Stud b = (Stud)y; 					//将y对象转换成Stud类对象b
            return String.Compare(a.xm, b.xm);
        }
    }
    public class myCompareClassfs : IComparer	//从接口派生myCompareClassfs类
    {
        int IComparer.Compare(object x, object y)	//实现Compare方法
        {
            Stud a = (Stud)x; 					//将x对象转换成Stud类对象a
            Stud b = (Stud)y; 					//将y对象转换成Stud类对象b
            if (a.fs < b.fs) return 1;
            else if (a.fs == b.fs) return 0;
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
			IComparer myComparerxh = new myCompareClassxh();
			IComparer myComparerxm = new myCompareClassxm();
			IComparer myComparerfs = new myCompareClassfs();
			ArrayList myarr = new ArrayList();
			Stud[] st = new Stud[4] { new Stud(1, "Smith", 82),new Stud(4, "John", 88),
					  new Stud(3, "Mary", 95),new Stud(2, "Cherr", 60) };
			for (i = 0; i < n; i++)		//将st的各元素添加到myarr集合中
				myarr.Add(st[i]);
            Console.WriteLine("排序前:");
			disparr(myarr );
			myarr.Sort(myComparerxh);	//按学号排序
            Console.WriteLine("按学号升序排序后:");
			disparr(myarr );
			myarr.Sort(myComparerxm);	//按姓名排序
            Console.WriteLine("按姓名词典次序排序后:");
			disparr(myarr);
			myarr.Sort(myComparerfs);	//按分数排序
            Console.WriteLine("按分数降序排序后:");
			disparr(myarr);
        }
    }
}
