using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Drive.DAO
{
    public static class FolderDAO
    {
        public static FolderDTO getFolderById(int id)
        {

            String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                String query = String.Format(@"select * from dbo.Folder where Id={0}", id);
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader rd = comm.ExecuteReader();

                rd.Read();
                FolderDTO obj = new FolderDTO();
                obj.id = rd.GetInt32(0);
                obj.Name = rd.GetString(1);
                obj.ParentFolderId = rd.GetInt32(2);
                obj.CreatedBy = rd.GetInt32(3);
                obj.CreatedOn = rd.GetDateTime(4).ToString();
                obj.IsActive = rd.GetBoolean(5);
                return obj;

            }
        }

        public static int Save(FolderDTO dto)
        {
            String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                String sqlQuery = "";
                if (dto.id > 0)
                {
                    sqlQuery = String.Format("Update dbo.Folder Set Name='{0}',ParentFolderId={1} Where Id={2}",
                        dto.Name, dto.ParentFolderId, dto.id);
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.ExecuteNonQuery();
                   
                    return dto.id;
                }
                else
                {
                    sqlQuery = String.Format("INSERT INTO dbo.Folder(Name,ParentFolderId,CreatedBy, CreatedOn,IsActive) VALUES('{0}',{1},{2},'{3}',{4});",
                        dto.Name, dto.ParentFolderId, dto.CreatedBy, dto.CreatedOn,1);
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.ExecuteNonQuery();
                   
                    return 0;
                }
            }
            
        }

        public static int DeleteFolder(int id)
        {
            String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                String sqlQuery = "";
                   sqlQuery = String.Format("Delete from dbo.Folder where Id={0}",id);
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.ExecuteNonQuery();

                    return 0;
                
            }

        }

        public static List<FolderDTO> getAllFoldersList(int id)
        {
            List<FolderDTO> lst = new List<FolderDTO>();
            String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                String query = String.Format(@"select * from dbo.Folder where ParentFolderId={0}",id);
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader rd = comm.ExecuteReader();

                while (rd.Read() == true)
                {
                    FolderDTO obj = new FolderDTO();
                    obj.id = rd.GetInt32(0);
                    obj.Name = rd.GetString(1);
                    obj.ParentFolderId = rd.GetInt32(2);
                    obj.CreatedBy = rd.GetInt32(3);
                    obj.CreatedOn = rd.GetDateTime(4).ToString();
                    obj.IsActive = rd.GetBoolean(5);

                    lst.Add(obj);


                }
            }
            return lst;
        }
        
    }
}
