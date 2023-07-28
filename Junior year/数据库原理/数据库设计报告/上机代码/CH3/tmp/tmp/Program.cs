using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 20, n = 0;
            do
            {
                n++;
                switch (i % 4)
                {
                    case 0: i = i - 7;break;
                    case 1:
                    case 2:
                    case 3: i++;break;
                }
            } while (i >= 0);
            Console.WriteLine(n);

        }
    }
}
