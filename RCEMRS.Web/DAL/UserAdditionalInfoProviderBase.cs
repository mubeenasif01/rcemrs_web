
using RCEMRS.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RCEMRS.Web.DAL
{
    public class UserAdditionalInfoProviderBase: SqlProviderBase
    {
        //Enum class of User tbl_columns index of database
        public enum UserAddtionalInfoColumn
        {
            UserAddtionalInfoId = 1, FirstName = 2, LastName = 3, CnicNumber = 4, Email = 5, PhoneNumber = 6, IsActive = 7,
            CreatedBy = 8, CreatedDate = 9, UpdatedBy = 10
        }

        protected static IList<UserAdditionalnfo> Fill(IDataReader reader, IList<UserAdditionalnfo> rows)
        {

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (!reader.Read())
                { break; } // we are done

                var c = new UserAdditionalnfo();
                c.UserAdditionalInfoId = (int)reader[((int)UserAddtionalInfoColumn.UserAddtionalInfoId - 1)];
                c.FirstName = (string)reader[((int)UserAddtionalInfoColumn.FirstName - 1)];
                c.LastName = (string)reader[((int)UserAddtionalInfoColumn.LastName - 1)];
                c.CnicNumber = (Int32)reader[((int)UserAddtionalInfoColumn.CnicNumber - 1)];
                c.Email = (string)reader[((int)UserAddtionalInfoColumn.Email - 1)];
                c.PhoneNumber = (Int32)reader[((int)UserAddtionalInfoColumn.PhoneNumber - 1)];
                c.IsActive = (int)reader[((int)UserAddtionalInfoColumn.IsActive - 1)];
                c.CreatedBy = (int)reader[((int)UserAddtionalInfoColumn.CreatedBy - 1)];
                c.CreatedDate = (reader.IsDBNull((int)UserAddtionalInfoColumn.CreatedDate - 1)) ? null : (DateTime?)reader[((int)UserAddtionalInfoColumn.CreatedDate - 1)];
                c.UpdatedBy = (reader.IsDBNull((int)UserAddtionalInfoColumn.UpdatedBy - 1)) ? null : (int?)reader[((int)UserAddtionalInfoColumn.UpdatedBy - 1)];
                rows.Add(c);
            }
            return rows;
        }

        public virtual IList<UserAdditionalnfo> GetAll()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_UserAdditionalInfo_GetAll]", true);
                IList<UserAdditionalnfo> tmp = new List<UserAdditionalnfo>();
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

        public virtual UserAdditionalnfo GetByUserId(Int32 userAdditionalInfoId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_UserAdditionalInfo_GetById]", true);
                cmd.Parameters.Add(GetInParameter("@userAdditionalInfoId", SqlDbType.Int, userAdditionalInfoId));
                IList<UserAdditionalnfo> tmp = new List<UserAdditionalnfo>();
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

        public virtual bool Insert(UserAdditionalnfo entity)
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

        public virtual bool Delete(UserAdditionalnfo entity)
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

        public virtual bool Update(UserAdditionalnfo entity)
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

        private bool Insert(UserAdditionalnfo entity, SqlConnection conn)
        {

            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_UserAddtionalInfo_Insert]", true);
                cmd.Parameters.Add(GetInParameter("@FirstName", SqlDbType.VarChar, entity.FirstName));
                cmd.Parameters.Add(GetInParameter("@LastName", SqlDbType.VarChar, entity.LastName));
                cmd.Parameters.Add(GetInParameter("@CnicNumber", SqlDbType.BigInt, entity.CnicNumber));
                cmd.Parameters.Add(GetInParameter("@PhoneNumber", SqlDbType.BigInt, entity.PhoneNumber));
                cmd.Parameters.Add(GetInParameter("@Email", SqlDbType.VarChar, entity.Email));
                cmd.Parameters.Add(GetInParameter("@Address", SqlDbType.VarChar, entity.Address));
                cmd.Parameters.Add(GetInParameter("@IsActive", SqlDbType.TinyInt, entity.IsActive));
                cmd.Parameters.Add(GetInParameter("@CreatedBy", SqlDbType.Int, entity.CreatedBy));
                cmd.Parameters.Add(GetInParameter("@CreatedDate", SqlDbType.DateTime, entity.CreatedDate));
                cmd.Parameters.Add(GetInParameter("@UserId", SqlDbType.Int, entity.UserId));
                cmd.Parameters.Add("@UserAdditionalInfoId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                entity.UserAdditionalInfoId = (int)cmd.Parameters["@userAdditionalInfoId"].Value;
                return true;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        private bool Update(UserAdditionalnfo entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_UserAdditionalInfo_Update]", true);
                cmd.Parameters.Add(GetInParameter("@UserAdditionalInfoId", SqlDbType.Int, entity.UserAdditionalInfoId));
                cmd.Parameters.Add(GetInParameter("@FirstName", SqlDbType.VarChar, entity.FirstName));
                cmd.Parameters.Add(GetInParameter("@LastName", SqlDbType.VarChar, entity.LastName));
                cmd.Parameters.Add(GetInParameter("@CnicNumber", SqlDbType.BigInt, entity.CnicNumber));
                cmd.Parameters.Add(GetInParameter("@PhoneNumber", SqlDbType.BigInt, entity.PhoneNumber));
                cmd.Parameters.Add(GetInParameter("@Email", SqlDbType.VarChar, entity.Email));
                cmd.Parameters.Add(GetInParameter("@Address", SqlDbType.VarChar, entity.Address));
                cmd.Parameters.Add(GetInParameter("@IsActive", SqlDbType.TinyInt, entity.IsActive));
                cmd.Parameters.Add(GetInParameter("@UpdatedBy", SqlDbType.Int, entity.UpdatedBy));
                cmd.Parameters.Add(GetInParameter("@UpdatedDate", SqlDbType.DateTime, entity.UpdatedDate));
                cmd.Parameters.Add(GetInParameter("@UserId", SqlDbType.Int, entity.UserId));
                ExecuteNonQuery(cmd);

                return true;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        private bool Delete(UserAdditionalnfo entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_UserAdditionalInfo_Delete] ", true);
                cmd.Parameters.Add(GetInParameter("@userAdditionalInfoId", SqlDbType.Int, entity.UserAdditionalInfoId));
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