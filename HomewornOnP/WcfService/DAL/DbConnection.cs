using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfService.DAL
{
    public class DbConnection
    {
        
        string ConnString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        private static SqlConnection conn;
       

        public DbConnection()
        {
            conn = new SqlConnection(ConnString);
        }

       

        public SqlConnection GetConnection()
        {
            return conn;
        }
    }
}