using System;
namespace Proj1
{
    class Student            //学生类
    {
        int xh;
        string xm;
        public void setdata(int xh1, string xm1)
        {
            xh = xh1; xm = xm1;
        }
        public void dispdata()
        {
            Console.WriteLine("学号:{0},姓名:{1}",xh,xm);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.setdata(1,"王华");
            Console.Write("s1"); s1.dispdata();
            Student s2 = new Student();
            Console.Write("s2"); s2.setdata(2, "李明");
            s2.dispdata();
            Console.WriteLine("s1和s2的引用是否相等:{0}",object.ReferenceEquals(s1,s2));
            Console.WriteLine("执行s2=s1");
            s2 = s1;
            Console.WriteLine("s1和s2的引用是否相等:{0}", object.ReferenceEquals(s1, s2));
        }
    }
}
