using System;

namespace Proj2
{
    class Student
    {
        int xh;
        string xm;
        public void GetData()
        {
            Console.WriteLine("输入一个学生信息:");
            Console.Write("学号:");
            xh = int.Parse(Console.ReadLine());
            Console.Write("姓名:");            
            xm = Console.ReadLine();
        }
        public void DispData()
        {
            Console.WriteLine("输出一个学生信息:");
            Console.WriteLine("  学号:{0},姓名:{1}",xh,xm);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            st.GetData();
            st.DispData();
        }
    }
}
