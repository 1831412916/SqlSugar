using System;
using System.Collections.Generic;
using System.Text;
using SqlSugarDemo.ORM;
using SqlSugarDemo.ORM.Entity;

namespace SqlSugarDemo.Services
{
    public class stu_Services : SqlSugarBase
    {
        /// <summary>
        /// 获取数据列表信息
        /// @author 王伟
        /// @date 2019-05-13 晴朗 15:30 微风
        /// </summary>
        /// <returns></returns>
        public List<Student> GetList()
        {
            return DB.Queryable<Student>().ToList();
        }
        /// <summary>
        /// 插入数据
        /// @Authoe 王伟
        /// @date 2019-05-13 晴朗 16:14 微风
        /// </summary>
        /// <param name="s"></param>
        public void Insertable(List<Student> students)
        {
            DB.Insertable<Student>(students).ExecuteCommand();//返回int
        }
        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="pageize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Student> GetListByPages(int pageize, int pageIndex, ref int totalCount)
        {
            return DB.Queryable<Student>().OrderBy(t => t.id).ToPageList(pageIndex, pageize, ref totalCount);
        }
        /// <summary>
        /// 批量修改数据
        /// @author 王伟
        /// @date 2019-05-13 晴朗 17:06
        /// </summary>
        /// <param name="students"></param>
        public void Updateable(List<Student> students)
        {
            if (students.Count > 0)
                DB.Updateable<Student>(students).ExecuteCommand();
        }
        
    }
}
