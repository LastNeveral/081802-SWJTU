using System;

namespace Exp
{
    class Complex       //复数类
    {
        public double e1 { set; get; }
        public double e2 { set; get; }
        public Complex(double e1, double e2)
        {
            this.e1 = e1;
            this.e2 = e2;
        }
        public void Dispcomp()
        {
            if (e2>=0)
                Console.WriteLine("{0} + {1}i",e1,e2);
            else
                Console.WriteLine("{0} - {1}i", e1, -e2);
        }
    }
    class ComOp //复数运算类
    {
        public Complex add(Complex c1, Complex c2)
        {
            double e1 = c1.e1 + c2.e1;
            double e2 = c1.e2 + c2.e2;
            return new Complex(e1, e2);                
        }
        public Complex sub( Complex c1, Complex c2)
        {
            double e1 = c1.e1 - c2.e1;
            double e2 = c1.e2 - c2.e2;
            return new Complex(e1, e2);                
        }
        public Complex mul(Complex c1, Complex c2)
        {
            double e1 = c1.e1*c2.e1 - c1.e2*c2.e2;
            double e2 = c1.e1*c2.e2 + c1.e2*c2.e1;
            return new Complex(e1, e2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(2, 3);
            Complex c2 = new Complex(-2, 5);
            Console.Write("c1:"); c1.Dispcomp();
            Console.Write("c2:"); c2.Dispcomp();
            Complex c3, c4, c5;
            ComOp op = new ComOp();
            c3 = op.add(c1, c2);
            Console.WriteLine("c3=c1+c2");
            Console.Write("c3:"); c3.Dispcomp();
            c4 = op.sub(c1, c2);
            Console.WriteLine("c4=c1-c2");
            Console.Write("c4:"); c4.Dispcomp();
            c5 = op.mul(c1, c2);
            Console.WriteLine("c5=c1*c2");
            Console.Write("c5:"); c5.Dispcomp();
        }
    }
}
