using System;

namespace Proj7
{
    class Program
    {
        static void Main(string[] args)
        {
            int z=0;
            try
            {
                int x, y;
                Console.Write("被除数:");
                x = int.Parse(Console.ReadLine());
                Console.Write("除数:");
                y = int.Parse(Console.ReadLine());
                z = x / y;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (z==0)
                    Console.WriteLine("异常处理完毕");
                else
                    Console.WriteLine("除法结果:{0}", z);
            }
        }
    }
}
