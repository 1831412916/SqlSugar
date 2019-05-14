using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSugarDemo.ORM.Entity
{
    [SugarTable("Student")]
    public class Student
    {
        public int id { get; set; }
        public int StuId { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}
