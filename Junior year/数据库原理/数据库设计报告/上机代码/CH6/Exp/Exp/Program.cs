using System;
using System.Collections.Generic;

namespace Exp
{
    abstract class Traff                //车辆类
    {
        abstract public void Run();   //抽象方法声明
    }
    class Tube : Traff                  //地铁类
    {
        public override void Run()
        {
            Console.Write("乘座地铁");
        }
    }
    class Cars : Traff     //汽车类
    {
        public override void Run()
        {
            Console.Write("驾驶汽车");
        }
    }
    class Bicycle : Traff    //自行车类
    {
        public override void Run()
        {
            Console.Write("骑自行车");
        }
    }
    class Employe       //员工类
    {
        string name;     //姓名
        public Employe(string name)
        {
            this.name = name;
        }
        public void Gohome(Traff tool)
        {
            Console.Write("员工" + name);
            tool.Run();
            Console.WriteLine("回家");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employe> emplist = new List<Employe>();
            Employe emp = new Employe("王华");
            emplist.Add(emp);
            emp = new Employe("李明");
            emplist.Add(emp);
            emp = new Employe("程军");
            emplist.Add(emp);
            emplist[0].Gohome(new Cars());
            emplist[1].Gohome(new Bicycle());
            emplist[2].Gohome(new Tube());
        }
    }
}
