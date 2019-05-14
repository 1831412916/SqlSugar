using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSugarDemo.ORM.Entity
{
    [SugarTable("Teacher")]
    public class Teacher
    {
        public int id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}
