using System;
namespace Proj3
{
   class Score				//声明Score类
	{	int no;				    //学号
		string name;			//姓名
		int deg1;				//语文成绩
		int deg2;				//数学成绩
		int deg3;				//英语成绩
		static int sum1=0;		//语文总分
		static int sum2=0;		//数学总分
		static int sum3=0;		//英语总分
		static int sn=0;		//总人数
	 	public Score(int n,string na,int d1,int d2,int d3)	//构造函数
		{	no=n;  name=na;
			deg1=d1;deg2=d2;deg3=d3;
			sum1+=deg1;sum2+=deg2;sum3+=deg3;
			sn++;
		}
		public void disp()		//定义disp()方法
		{	Console.WriteLine("学号:{0} 姓名:{1} 语文:{2} 数学:{3} 英语:{4}"+
                " 平均分:{5:f}",no,name,deg1,deg2,deg3,(double)(deg1+deg2+deg3)/3);
	 	}
		public static double avg1() { return (double)sum1/sn; }	//静态方法
		public static double avg2() { return (double)sum2/sn; }	//静态方法
		public static double avg3() { return (double)sum3/sn; }	//静态方法
	};
	class Program
	{	static void Main(string[] args)
		{	Score s1=new Score(1,"王华",85,89,90);
			Score s2=new Score(2,"李明",78,74,65);
			Score s3=new Score(3,"张兵",82,89,82);
			Score s4=new Score(4,"王超",65,98,72);
			Console.WriteLine("输出平均分结果如下");
			s1.disp(); s2.disp(); s3.disp(); s4.disp();
			Console.WriteLine("语文平均分:{0} 数学平均分:{1} 英语平均分:{2}",
				Score.avg1(), Score.avg2(),Score.avg3());
		}
	}

}
