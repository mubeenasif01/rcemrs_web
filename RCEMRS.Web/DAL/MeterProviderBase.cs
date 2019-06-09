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
    public class MeterProviderBase : SqlProviderBase
    {
        protected static IList<Meter> Fill(IDataReader reader, IList<Meter> rows)
        {

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (!reader.Read())
                { break; } // we are done

                var c = new Meter();
                c.MeterId = (int)reader["meter_id"];
                c.AssignMeterId = (int)reader["assign_meter_id"];
                c.IsActive = Convert.ToBoolean(reader["meter_status"]);
                c.PaymentStatus = (reader.IsDBNull(reader.GetOrdinal("meter_payment_status"))) ? null : (string)reader["meter_payment_status"];
                c.ConsumerId = (int)reader["consumer_id"];
                c.CreatedDate = (DateTime)reader["created_date"];
                c.CreatedBy = (int)reader["created_by"];
                c.MeterType = (int)reader["meter_type"];
                c.UpdatedBy = (reader.IsDBNull(reader.GetOrdinal("updated_by"))) ? null :(int?) reader["updated_by"];
                c.UpdatedDate = (reader.IsDBNull(reader.GetOrdinal("updated_date"))) ? null : (DateTime?)reader["updated_date"];

                rows.Add(c);
            }
            return rows;
        }

        public virtual IList<Meter> GetAll()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_Meter_GetAll]", true);
                IList<Meter> tmp = new List<Meter>();
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

        public virtual Meter GetByMeterId(Int32 meterId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_Meter_GetById]", true);
                cmd.Parameters.Add(GetInParameter("@MeterId", SqlDbType.Int, meterId));
                IList<Meter> tmp = new List<Meter>();
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

        public virtual bool Insert(Meter entity)
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

        public virtual bool Delete(Meter entity)
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

        public virtual bool Update(Meter entity)
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

        private bool Insert(Meter entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_Meter_Insert]", true);
                cmd.Parameters.Add(GetInParameter("@AssignMeterId", SqlDbType.Int, entity.AssignMeterId));
                cmd.Parameters.Add(GetInParameter("@MeterStatus", SqlDbType.TinyInt, entity.IsActive));
                cmd.Parameters.Add(GetInParameter("@PaymentStatus", SqlDbType.VarChar, entity.PaymentStatus));
                cmd.Parameters.Add(GetInParameter("@CreatedDate", SqlDbType.DateTime, entity.CreatedDate));
                cmd.Parameters.Add(GetInParameter("@MeterType", SqlDbType.Bit, entity.MeterType));
                cmd.Parameters.Add(GetInParameter("@CreatedBy", SqlDbType.Int, entity.CreatedBy));
                cmd.Parameters.Add(GetInParameter("@ConsumerId", SqlDbType.Int, entity.ConsumerId));
                
                cmd.Parameters.Add("@MeterId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                entity.MeterId = (int)cmd.Parameters["@MeterId"].Value;
              
                return true;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        private bool Update(Meter entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_Meter_Update]", true);
                cmd.Parameters.Add(GetInParameter("@MeterId", SqlDbType.TinyInt, entity.MeterId));
                cmd.Parameters.Add(GetInParameter("@AssignMeterId", SqlDbType.Int, entity.AssignMeterId));
                cmd.Parameters.Add(GetInParameter("@MeterStatus", SqlDbType.TinyInt, entity.IsActive));
                cmd.Parameters.Add(GetInParameter("@PaymentStatus", SqlDbType.VarChar, entity.PaymentStatus));
                cmd.Parameters.Add(GetInParameter("@MeterType", SqlDbType.Bit, entity.MeterType));
                cmd.Parameters.Add(GetInParameter("@CreatedDate", SqlDbType.DateTime, entity.CreatedDate));
                cmd.Parameters.Add(GetInParameter("@CreatedBy", SqlDbType.Int, entity.CreatedBy));
                cmd.Parameters.Add(GetInParameter("@UpdatedBy", SqlDbType.Int, entity.UpdatedBy));
                cmd.Parameters.Add(GetInParameter("@UpdatedDate", SqlDbType.DateTime, entity.UpdatedDate));
                cmd.Parameters.Add(GetInParameter("@ConsumerId", SqlDbType.Int, entity.ConsumerId));
              
                cmd.ExecuteNonQuery();

                return true;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        private bool Delete(Meter entity, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = GetCommand(conn, "[dbo].[usp_Meter_Delete]", true);
                cmd.Parameters.Add(GetInParameter("@MeterId", SqlDbType.Int, entity.MeterId));
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