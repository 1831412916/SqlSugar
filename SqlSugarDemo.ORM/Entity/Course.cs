using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSugarDemo.ORM.Entity
{
    [SugarTable("Course")]
    public class Course
    {
        public int id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
