using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace SqlSugarDemo.ORM
{
    public class SqlSugarBase
    {
        public static string DB_ConnectionString = @"Data Source=DESKTOP-0KHQ8KN\XPS;Initial Catalog=SqlSugarDemo;Integrated Security=True";//定义连接字符串变量
        public static SqlSugarClient DB
        {
            get => new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = DB_ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.SystemTable,
                IsShardSameThread = true
            });
        }
    }
}
