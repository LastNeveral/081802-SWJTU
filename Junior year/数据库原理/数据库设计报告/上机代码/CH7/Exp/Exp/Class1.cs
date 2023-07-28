using System.Collections.Generic;
namespace Exp
{
    public class Student                //学生类
    {
        public int xh { set; get; }     //学号
        public string xm { set; get; }  //姓名
        public string xb { set; get; }  //性别
        public string mz { set; get; }  //民族
        public string bh { set; get; }  //班号
    }
    public class StudLib                //学生记录库
    {
        public static List<Student> stlist = new List<Student>();
        public static int tag;          //添加：1，修改：0，查找:2
        public static int current;      //当前记录索引
        public static int Find(int xh1) //查找xh为学号的记录索引
        {
            int i = 0;
            while (i < stlist.Count)
            {
                if (stlist[i].xh == xh1)
                    return i;
                i++;
            }
            return -1;              //未找到返回-1
        }
    }
}
