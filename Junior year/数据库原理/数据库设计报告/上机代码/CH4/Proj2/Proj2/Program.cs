using System;
namespace Proj2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, m = 6, n = 4;
            int[,] A = new int [,] { { 2, 3, 4, 5 }, { 6, 7, 8, 9 }, { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 1,2, 3, 4 }, { 5, 6, 7, 8} };
            int [,] B =new int[n,m];
            for (i=0;i<m;i++)
                for (j=0;j<n;j++)
                    B[j,i]=A[i,j];
            i = 0;
            Console.WriteLine("A");
            foreach (int item in A)
            {
                Console.Write("{0,5}", item);
                i++;
                if (i % n == 0) Console.WriteLine(); //每n个元素换一行
            }
            i = 0;
            Console.WriteLine("B");
            foreach (int item in B)
            {
                Console.Write("{0,5}",item);
                i++;
                if (i%m==0) Console.WriteLine(); //每m个元素换一行
            }
        }
    }
}
