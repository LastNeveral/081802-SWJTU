using System;
namespace Proj3
{
    class Program
    {
        static void Main(string[] args)
        {
            string email;                       //邮箱
            string name;                        //用户名
            Console.Write("输入邮箱:");
            email = Console.ReadLine();
            int position = email.IndexOf("@");  //求@的位置
            if (position>0)
            {
                name=email.Substring(0,position);
                Console.WriteLine("邮箱:{0},用户名:{1}",email,name);
            }
            else
               Console.WriteLine("邮箱格式错误!");
        }
    }
}
