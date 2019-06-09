using RCEMRS.Entites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCEMRS.DAL;
using System.Data;
using RCEMRS.Web.DAL;

namespace RCEMRS.DAL
{
    public class UserProviderBase : SqlProviderBase
    {
        //Enum class of User tbl_columns index of database
        public enum UserColumn
        {
            UserId = 1 , LoginName = 2 , Password = 3 ,Role = 4
        }

        protected static IList<User> Fill(IDataReader reader, IList<User> rows)
        {

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (!reader.Read())
                { break; } // we are done

                var c = new User();
                c.UserId = (int)reader[((int)UserColumn.UserId - 1)];
                c.LoginName = (string)reader[((int)UserColumn.LoginName - 1)];
                c.Password =  (string)reader[((int)UserColumn.Password - 1)];
                c.Role =  (string)reader[((int)UserColumn.Role - 1)];
                rows.Add(c);
            }
            return rows;
        }

        public virtual IList<User> GetAll()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_User_GetAll]", true);
                IList<User> tmp = new List<User>();
                IDataReader reader = ExecuteReader(cmd);
                Fill(reader, tmp);
                if (!reader.IsClosed) reader.Close();
                return tmp;
            }
            finally
            {
                if (conn != null) conn.Dispose();
                if (cmd != null) cmd.Dispose();
            }
        }

        public virtual User GetByUserId(Int32 userId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_User_GetByUserId]", true);
                cmd.Parameters.Add(GetInParameter("@UserId", SqlDbType.Int, userId));
                IList<User> tmp = new List<User>();
                IDataReader reader = cmd.ExecuteReader();
                Fill(reader, tmp);
                if (!reader.IsClosed) reader.Close();
                return tmp.Count > 0 ? tmp[0] : null;
            }
            finally
            {
                if (conn != null) conn.Dispose();
                if (cmd != null) cmd.Dispose();
            }
        }
       
        public virtual bool Insert(User entity)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                return Insert(entity, conn);
            }
            finally
            {
                if (conn != null) conn.Dispose();
            }
        }

        public virtual bool Delete(User entity)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                return Delete(entity, conn);
            }
            finally
            {
                if (conn != null) conn.Dispose();
            }
        }

        public virtual bool Update(User entity)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                return Update(entity, conn);
            }
            finally
            {
                if (conn != null) conn.Dispose();
            }
        }

        private bool Insert(User entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_User_Insert]", true);
                cmd.Parameters.Add(GetInParameter("@UserName", SqlDbType.VarChar, entity.LoginName));
                cmd.Parameters.Add(GetInParameter("@UserPassword", SqlDbType.VarChar, entity.Password));
                cmd.Parameters.Add(GetInParameter("@UserRole", SqlDbType.VarChar, entity.Role));
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                entity.UserId =(int)cmd.Parameters["@UserId"].Value;
               
                return true;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        private  bool Update(User entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_User_Update]", true);
                cmd.Parameters.Add(GetInParameter("@UserId", SqlDbType.Int, entity.UserId));
                cmd.Parameters.Add(GetInParameter("@UserName", SqlDbType.VarChar, entity.LoginName));
                cmd.Parameters.Add(GetInParameter("@UserPassword", SqlDbType.VarChar, entity.Password));
                cmd.Parameters.Add(GetInParameter("@UserRole", SqlDbType.VarChar, entity.Role));
                cmd.ExecuteNonQuery();

                return true;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        private  bool Delete(User entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_User_Delete] ", true);
                cmd.Parameters.Add(GetInParameter("@UserId", SqlDbType.Int, entity.UserId));
                cmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }
    }
}
