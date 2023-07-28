using System;
namespace Proj3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] st = new string[3][];
            st[0] = new string[] { "社会主义理论", "马克思主义原理", "思想道德修养", "英语", "高等数学"};
            st[1] = new string[] { "高级语言", "数字逻辑", "离散数学", "数据结构", "计算机组成原理" };
            st[2] = new string[] { "操作系统", "数据库原理", "计算机体系结构" };
            for (int i=0;i<st.Length;i++)
            {
                switch (i)
                {
                    case 0: Console.WriteLine("通识教育课:"); break;
                    case 1: Console.WriteLine("专业基础课:"); break;
                    case 2: Console.WriteLine("专业课:"); break;
                }
                for (int j = 0; j < st[i].Length;j++ )
                    Console.Write("{0}  ",st[i][j]);
                Console.WriteLine();
            }
        }
    }
}
