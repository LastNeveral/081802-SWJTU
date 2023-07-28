using System;

namespace Proj4
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int[,] A = new int[,] { { 2, 3, 4, 5 }, { 6, 7, 8, 9 }, { 1, 2, 3, 4 },
								{ 5, 6, 7, 8 }, { 1,2, 3, 4 }, { 5, 6, 7, 8} };
            Console.WriteLine("A是{0}维数组",A.Rank);
            Console.WriteLine("A中元素个数：{0}",A.Length);
            for (i = 1; i <= A.Rank; i++)
                Console.WriteLine("第{0}维,下限为{1},上限为{2}", i, A.GetLowerBound(i - 1), A.GetUpperBound(i - 1));
        }
    }
}
