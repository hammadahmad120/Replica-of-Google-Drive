using System;
using Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.DAO
{
   public static class UserDAO
    {
       public static User getUserByLogin(string log)
       {

           String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
           using (SqlConnection conn = new SqlConnection(sqlConn))
           {
               conn.Open();
               String query = String.Format(@"select * from dbo.Users where Login='{0}'",log);
               SqlCommand comm = new SqlCommand(query, conn);
               SqlDataReader rd = comm.ExecuteReader();

               rd.Read();
               User obj = new User();
               obj.id = rd.GetInt32(0);
               obj.Name = rd.GetString(1);
               obj.Login = rd.GetString(2);
               obj.Password = rd.GetString(3);
               obj.Email = rd.GetString(4);
               return obj;

           }
       }
       public static User getUserById(int id)
       {

           String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
           using (SqlConnection conn = new SqlConnection(sqlConn))
           {
               conn.Open();
               String query = String.Format(@"select * from dbo.Users where Id={0}",id);
               SqlCommand comm = new SqlCommand(query, conn);
               SqlDataReader rd = comm.ExecuteReader();

               rd.Read();
               User obj = new User();
               obj.id = rd.GetInt32(0);
               obj.Name = rd.GetString(1);
               obj.Login = rd.GetString(2);
               obj.Password = rd.GetString(3);
               obj.Email = rd.GetString(4);
               return obj;

           }
       }

       public static Boolean UserLogin(String log, String pass)
       {

           String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
           using (SqlConnection conn = new SqlConnection(sqlConn))
           {
               conn.Open();
               String query = String.Format(@"select * from dbo.Users where Login='{0}' and Password='{1}'", log, pass);
               SqlCommand comm = new SqlCommand(query, conn);
               SqlDataReader rd = comm.ExecuteReader();
               if (rd.HasRows == true)
                   return true;
               else
                   return false;

           }
       }


    }
}
