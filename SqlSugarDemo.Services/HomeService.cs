using System;
using System.Collections.Generic;
using SqlSugarDemo.ORM;
using SqlSugarDemo.ORM.Entity;

namespace SqlSugarDemo.Services
{
    public class HomeService : SqlSugarBase
    {
        public List<Student> GetList()
        {
            return DB.Queryable<Student>().ToList();
        }

        public void InsertData(Student s)
        {
            DB.Insertable<Student>(s);
        }
    }
}
