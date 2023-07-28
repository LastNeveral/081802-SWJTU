using System;
using System.Collections;       //新增
namespace Proj5
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList st = new ArrayList();
            st.Add(89);
            st.Add(58);
            st.Add(85);
            st.Add(72);
            st.Add(69);
            st.Add(92);
            st.Add(76);
            st.Add(82);
            st.Add(96);
            st.Sort();
            st.Reverse();
            int i=1;
            foreach (int item in st)
            {
                Console.WriteLine("第{0}名: {1}", i, item);
                i++;
            }
        }
    }
}
