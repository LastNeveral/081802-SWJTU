using System;
namespace Proj7
{
    class Node<T>        //结点泛型Node<T>
    {
        Node<T> next;
        T data;
        public Node(T t)    //构造函数
        {
            next = null;
            data = t;
        }
        public Node<T> Next  //获取下一个结点
        {
            get { return next; }
            set { next = value; }
        }
        public T Data       //获取结点值
        {
            get { return data; }
            set { data = value; }
        }
    }
    class MyList<T>          //链表泛型MyList<T>
    {
        protected Node<T> head;      //链表首结点
        protected Node<T> current = null;
       
        ~MyList()        //析构函数
        {
            head = null;
        }
        public void AddHead(T t)    //将一个结点插入在首部
        {
            Node<T> n = new Node<T>(t);
            n.Next = head;
            head = n;
        }
        public void DispList()      //从头到尾输出结点值
        {
            Node<T> p = head;
            while (p != null)
            {
                Console.Write("{0} ", p.Data);
                p = p.Next;
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> intlist = new MyList<int>();
            int[] arr = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int item in arr)
                intlist.AddHead(item);
            Console.WriteLine("整数链表:");
            intlist.DispList();

            MyList<string> strlist = new MyList<string>();
            string[] arrs = new string[5] { "Mary", "John", "Smith", "Hammer", "Reid" };
            foreach (string item in arrs)
                strlist.AddHead(item);
            Console.WriteLine("字符串链表:");
            strlist.DispList();

        }
    }
}
