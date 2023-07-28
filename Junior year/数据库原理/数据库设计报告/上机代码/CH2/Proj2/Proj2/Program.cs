using System;

namespace Proj2
{
    struct Student			//结构类型声明应放在Main函数的外面
    {
        public int xh;		//学号
        public string xm;		//姓名
        public string xb;		//性别
        public int nl;		//年龄
        public string bh;		//班号
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            Student s1, s2;		//定义两个结构类型变量
            s1.xh = 101; s1.xm = "李明"; s1.xb = "男";
            s1.nl = 20; s1.bh = "15001";
            Console.WriteLine("学号:{0},姓名:{1},性别:{2},年龄:{3},班号:{4}",
                s1.xh, s1.xm, s1.xb, s1.nl, s1.bh);
            s2 = s1;				//将结构变量s1赋给s2
            s2.xh = 108;s2.xm = "王华"; s2.xb = "女"; s2.nl = 21;
            Console.WriteLine("学号:{0},姓名:{1},性别:{2},年龄:{3},班号:{4}",
                s2.xh, s2.xm, s2.xb, s2.nl, s2.bh);
            Console.WriteLine("s1和s2的引用是否相等:{0}",object.ReferenceEquals(s1,s2));
        }
    }

}
