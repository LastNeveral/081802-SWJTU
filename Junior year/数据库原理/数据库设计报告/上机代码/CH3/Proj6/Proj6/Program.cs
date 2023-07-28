using System;
namespace Proj6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n,i;
            bool prime;
            for (n = 2; n <= 20; n++)
            {
                prime = true;
                for (i = 2; i <= Math.Sqrt(n); i++)
                    if (n % i == 0)
                    {
                        prime = false;
                        break;
                    }
                if (!prime) continue;
                Console.Write("{0} ", n);
            }
            Console.WriteLine();
        }
    }
}
