using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Drive.DAO
{
    public static class FileDAO
    {
        public static FileDTO getFileById(int id)
        {

            String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                String query = String.Format(@"select * from dbo.Files where Id={0}", id);
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader rd = comm.ExecuteReader();

                rd.Read();
                FileDTO obj = new FileDTO();
                obj.id = rd.GetInt32(0);
                obj.Name = rd.GetString(1);
                obj.ParentFolderId = rd.GetInt32(2);
                obj.FileExt = rd.GetString(3);
                obj.FileUniqueName = rd.GetString(4);
                obj.FileSizeInKB = rd.GetInt32(5);
                obj.CreatedBy = rd.GetInt32(6);
                obj.UploadedOn = rd.GetDateTime(7).ToString();
                obj.IsActive = rd.GetBoolean(8);
                obj.ContentType = rd.GetString(9);
                return obj;

            }
        }
        public static FileDTO getFileByUniqueName(String uname)
        {

            String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                String query = String.Format(@"select * from dbo.Files where Id={0}", 6);
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader rd = comm.ExecuteReader();

                rd.Read();
                FileDTO obj = new FileDTO();
                obj.id = rd.GetInt32(0);
                obj.Name = rd.GetString(1);
                obj.ParentFolderId = rd.GetInt32(2);
                obj.FileExt = rd.GetString(3);
                obj.FileUniqueName = rd.GetString(4);
                obj.FileSizeInKB = rd.GetInt32(5);
                obj.CreatedBy = rd.GetInt32(6);
                obj.UploadedOn = rd.GetDateTime(7).ToString();
                obj.IsActive = rd.GetBoolean(8);
                obj.ContentType = rd.GetString(9);
                return obj;

            }
        }

        public static int Save(FileDTO dto)
        {
            String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                String sqlQuery = "";
                if (dto.id > 0)
                {
                    sqlQuery = String.Format("Update dbo.Files Set Name='{0}',ParentFolderId={1},FileExt='{2}',FileSizeInKB={3}, Where Id={4}",
                        dto.Name, dto.ParentFolderId,dto.FileExt,dto.FileSizeInKB, dto.id);
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.ExecuteNonQuery();

                    return dto.id;
                }
                else
                {
                    sqlQuery = String.Format("INSERT INTO dbo.Files(Name,ParentFolderId,FileExt,FileUniqueName,FileSizeInKB,CreatedBy, UploadedOn,IsActive,ContentType) VALUES('{0}',{1},'{2}','{3}',{4},{5},'{6}',{7},'{8}');",
                        dto.Name, dto.ParentFolderId,dto.FileExt,dto.FileUniqueName, dto.FileSizeInKB, dto.CreatedBy, dto.UploadedOn, 1,dto.ContentType);
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.ExecuteNonQuery();

                    return 0;
                }
            }

        }

        public static int DeleteFile(int id)
        {
            String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                String sqlQuery = "";
                sqlQuery = String.Format("Delete from dbo.Files where Id={0}", id);
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.ExecuteNonQuery();

                return 0;

            }

        }

        public static List<FileDTO> getAllFilesList(int id)
        {
            List<FileDTO> lst = new List<FileDTO>();
            String sqlConn = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment8; User id=sa; Password=120";
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                String query = String.Format(@"select * from dbo.Files where ParentFolderId={0}", id);
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader rd = comm.ExecuteReader();

                while (rd.Read() == true)
                {
                    FileDTO obj = new FileDTO();
                    obj.id = rd.GetInt32(0);
                    obj.Name = rd.GetString(1);
                    obj.ParentFolderId = rd.GetInt32(2);
                    obj.FileExt = rd.GetString(3);
                    obj.FileUniqueName = rd.GetString(4);
                    obj.FileSizeInKB = rd.GetInt32(5);
                    obj.CreatedBy = rd.GetInt32(6);
                    obj.UploadedOn = rd.GetDateTime(7).ToString();
                    obj.IsActive = rd.GetBoolean(8);
                    obj.ContentType = rd.GetString(9);
                    lst.Add(obj);


                }
            }
            return lst;
        }
       
    }
}
