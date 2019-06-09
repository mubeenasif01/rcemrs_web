using RCEMRS.DAL;
using RCEMRS.Web.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.DAL
{
    public class ConsumerProviderBase : SqlProviderBase
    {
        //Enum class of User tbl_columns index of database
        public enum UserColumn
        {

            ConsumerId = 1,
            ConsumerName = 2,
            ConsumerFatherName =3,
            ConsumerCnicNo =  4,
            ConsumerDoB = 5,
            ConsumerAddress = 6,   
            ConsumerPhoneNumber =7,
            CreatedDate = 8,
            CreatedBy = 9,
            UpdatedBy = 10,
            UpdatedDate = 11
        }

        protected static IList<Consumer> Fill(IDataReader reader, IList<Consumer> rows)
        {

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (!reader.Read())
                { break; } // we are done

                var c = new Consumer();
                c.ConsumerId  = (int)reader["consumer_id"];
                c.ConsumerName = (string)reader["consumer_name"];
                c.ConsumerFatherName = (string)reader["consumer_fname"];
                c.ConsumerCnicNo = (long)reader["consumer_cnic_number"];
                c.ConsumerDoB = (DateTime)reader["consumer_dob"];
                c.ConsumerPhoneNumber = (Int64)reader["consumer_phone_number"];
                c.ConsumerAddress = (string)reader["consumer_address"];
                c.IsActive = (bool)reader["is_active"];
                c.CreatedDate = (DateTime)reader["created_date"];
                c.CreatedBy = (int)reader["created_by"];
                c.UpdatedBy = (reader.IsDBNull(reader.GetOrdinal("updated_by"))) ? null : (int?)reader["updated_by"];
                c.UpdatedDate = (reader.IsDBNull(reader.GetOrdinal("updated_date"))) ? null : (DateTime?)reader["updated_date"];

                rows.Add(c);
            }
            return rows;
        }

        public virtual IList<Consumer> GetAll()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_Consumer_GetAll]", true);
                IList<Consumer> tmp = new List<Consumer>();
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

        public virtual Consumer GetByConsumerId(Int32 consumerId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_Consumer_GetById]", true);
                cmd.Parameters.Add(GetInParameter("@ConsumerId", SqlDbType.Int, consumerId));
                IList<Consumer> tmp = new List<Consumer>();
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

        public virtual bool Insert(Consumer entity)
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

        public virtual bool Delete(Consumer entity)
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

        public virtual bool Update(Consumer entity)
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

        private bool Insert(Consumer entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_Consumer_Insert]", true);
                cmd.Parameters.Add(GetInParameter("@ConsumerName", SqlDbType.VarChar, entity.ConsumerName));
                cmd.Parameters.Add(GetInParameter("@ConsumerFatherName", SqlDbType.VarChar, entity.ConsumerFatherName));
                cmd.Parameters.Add(GetInParameter("@ConsumerCnicNo", SqlDbType.BigInt, entity.ConsumerCnicNo));
                cmd.Parameters.Add(GetInParameter("@ConsumerDoB", SqlDbType.Date, entity.ConsumerDoB));
                cmd.Parameters.Add(GetInParameter("@ConsumerAddress", SqlDbType.VarChar, entity.ConsumerAddress));
                cmd.Parameters.Add(GetInParameter("@ConsumerPhoneNo", SqlDbType.BigInt, entity.MeterType));
                cmd.Parameters.Add(GetInParameter("@CreatedBy", SqlDbType.Int, entity.CreatedBy));
                cmd.Parameters.Add(GetInParameter("@IsActive", SqlDbType.Bit, entity.IsActive));
                cmd.Parameters.Add(GetInParameter("@CreatedDate", SqlDbType.DateTime, entity.CreatedDate));
                cmd.Parameters.Add("@ConsumerId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                entity.ConsumerId = (Int32)cmd.Parameters["@ConsumerId"].Value;
                return true;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        private bool Update(Consumer entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_Consumer_Update]", true);
                cmd.Parameters.Add(GetInParameter("@ConsumerId", SqlDbType.Int, entity.ConsumerId));
                cmd.Parameters.Add(GetInParameter("@ConsumerName", SqlDbType.VarChar, entity.ConsumerName));
                cmd.Parameters.Add(GetInParameter("@ConsumerFatherName", SqlDbType.VarChar, entity.ConsumerFatherName));
                cmd.Parameters.Add(GetInParameter("@ConsumerCnicNo", SqlDbType.BigInt, entity.ConsumerCnicNo));
                cmd.Parameters.Add(GetInParameter("@ConsumerDoB", SqlDbType.Date, entity.ConsumerDoB));
                cmd.Parameters.Add(GetInParameter("@ConsumerAddress", SqlDbType.VarChar, entity.ConsumerAddress));
                cmd.Parameters.Add(GetInParameter("@ConsumerPhoneNo", SqlDbType.BigInt, entity.ConsumerPhoneNumber));
                cmd.Parameters.Add(GetInParameter("@IsActive", SqlDbType.Bit, entity.IsActive));
                cmd.Parameters.Add(GetInParameter("@UpdatedBy", SqlDbType.Int, entity.UpdatedBy));
                cmd.Parameters.Add(GetInParameter("@UpdatedDate", SqlDbType.DateTime, entity.UpdatedDate));

                cmd.ExecuteNonQuery();

                return true;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        private bool Delete(Consumer entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_Consumer_Delete]", true);
                cmd.Parameters.Add(GetInParameter("@ConsumerId", SqlDbType.Int, entity.ConsumerId));
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