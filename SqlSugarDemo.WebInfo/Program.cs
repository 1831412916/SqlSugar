using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqlSugar;
using SqlSugarDemo.ORM;
using SqlSugarDemo.ORM.Entity;
using SqlSugarDemo.Services;

namespace SqlSugarDemo.WebInfo
{
    public class Program : SqlSugarBase
    {
        public static int totalCount = 0;
        public static void Main(string[] args)
        {
            List<Student> list = new stu_Services().GetList();
            if (list.Count < 10)
            {
                List<Student> arr = new List<Student>();
                string[] namestr = { "赵", "钱", "孙", "李", "周", "吴", "郑", "王", "冯", "陈", "啊", "打", "是", "的", "人", "如", "了", "哦", "拍", "没", "树", "特曼", "荣耀", "普京", "奥巴马", "荣浩", "光荣", "策划", "芳茹", "骋怀" };
                for (int i = 0; i < 100000; i++)
                {
                    Random rd = new Random();
                    int index1 = rd.Next(1, 10);
                    int index2 = rd.Next(11, 30);
                    Student s = new Student();
                    s.StuId = i % 2 == 0 ? 1 : 2;
                    s.Name = namestr[index1] + namestr[index2];
                    s.CourseId = i % 2 == 0 ? 19 : 20;
                    arr.Add(s);
                }
                Stopwatch sw = new Stopwatch();
                sw.Start();
                new stu_Services().Insertable(arr);
                sw.Stop();
                string msg = sw.ElapsedMilliseconds.ToString();
            }
            List<Student> listEntities = new stu_Services().GetListByPages(10, 2, ref totalCount);
            //list = list.Where(t => t.Name.Equals("王如")).ToList();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    list[i].Name = list[i].Name + (i + 1);
            //}
            //new stu_Services().Updateable(list);

            var lsitJoins = DB.Queryable<Student, Teacher, Course>((s, t, c) => new object[]{
                JoinType.Left,s.StuId==t.id,
                JoinType.Left,s.CourseId==c.id
            }).Select((s, t, c) => new V_Student
            {
                id = s.id,
                name = s.Name,
                teacher = t.Name,
                classed = c.Name
            }).ToList();

            CreateWebHostBuilder(args).Build().Run();
        }



        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
