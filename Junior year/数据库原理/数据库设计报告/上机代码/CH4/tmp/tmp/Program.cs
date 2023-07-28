using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace tmp
{
    struct Fruits
    {
        public string name;
        public string color;
        public int size;
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList fr = new ArrayList();
            Fruits afr;
            afr.name = "苹果"; afr.color = "红色"; afr.size = 8;
            fr.Add(afr);
            afr.name = "苹果"; afr.color = "绿色"; afr.size = 5;
            fr.Add(afr);
            afr.name = "李子"; afr.color = "绿色"; afr.size = 3;
            fr.Add(afr);
            afr.name = "香蕉"; afr.color = "黄色"; afr.size = 15;
            fr.Add(afr);
            afr.name = "梨子"; afr.color = "黄色"; afr.size = 10;
            fr.Add(afr);
 

        }
    }
}
