using RCEMRS.Web.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RCEMRS.Web.DAL
{
    public class MeterProvider:MeterProviderBase
    {
        #region Constructor
        public MeterProvider() : base() { }
        #endregion

        public IList<Meter> GetAllMeterByForeignKey(int consumerId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_GetMeterListByConsumerForeignKey]", true);
                cmd.Parameters.Add(GetInParameter("@ConsumerId",SqlDbType.Int , consumerId));
                IList<Meter> temp = new List<Meter>();
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Meter entity = new Meter();
                    entity.MeterId = (int)reader["meter_id"];
                    temp.Add(entity);
                }
                if (!reader.IsClosed)
                    reader.Close();
                return temp;
            }
            catch (Exception)
            {

                throw;
            }
        } 

        public bool AssignMeterToConsumer(Meter entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_Meter_Insert]", true);
                cmd.Parameters.Add(GetInParameter("@AssignMeterId", SqlDbType.Int, entity.AssignMeterId));
                cmd.Parameters.Add(GetInParameter("@MeterStatus", SqlDbType.TinyInt, entity.IsActive));
                cmd.Parameters.Add(GetInParameter("@PaymentStatus", SqlDbType.VarChar, entity.PaymentStatus));
                cmd.Parameters.Add(GetInParameter("@CreatedDate", SqlDbType.DateTime, entity.CreatedDate));
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

        public bool ChangeMeterStatus(int meterId , bool isActive)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "usp_ChangeMeterStatus", true);
                cmd.Parameters.Add(GetInParameter("@MeterId", SqlDbType.Int, meterId));
                cmd.Parameters.Add(GetInParameter("@MeterStatus", SqlDbType.TinyInt, isActive));
                cmd.ExecuteNonQuery();
             

                return true;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

      

        #region Mobile Application 
        public IList<MeterReading> GetMeterReadingByMeterId(int meterId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_GetMeterByMeterId]", true);
                cmd.Parameters.Add(GetInParameter("@MeterId", SqlDbType.Int, meterId));
                IList<MeterReading> temp = new List<MeterReading>();
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MeterReading entity = new MeterReading();
                    entity.ReadingId = Convert.ToInt32(reader["reading_id"]);
                    entity.MeteReading = Convert.ToInt64(reader["current_reading"]);
                   // entity.ReadingUnit = Convert.ToInt64(reader["reading_unit"]);
                    entity.ReadingDate = Convert.ToDateTime(reader["reading_date"]);
                    entity.BillingStatus = Convert.ToBoolean(reader["payment_status"]);
                    entity.MeterStatus = Convert.ToBoolean(reader["meter_status"]);
                    temp.Add(entity);
                }
                if (!reader.IsClosed)
                    reader.Close();
                return temp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<Billing> GetBillingHistorybyForeignKey(int meterId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_GetBillingDetailByConsumerId]", true);
                cmd.Parameters.Add(GetInParameter("@MeterId", SqlDbType.Int, meterId));
                List<Billing> tmp = new List<Billing>();
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Billing entity = new Billing();
                    entity.PaymentStatus = Convert.ToBoolean(reader["payment_status"]);
                    entity.BillingMonth = Convert.ToInt32(reader["billing_month"]);
                    tmp.Add(entity);
                }

                return tmp;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        public bool SaveMeterReading(int meterId, int meterReading, int meterStatus)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_MeterReading_Insert]", true);
                cmd.Parameters.Add(GetInParameter("@MeterId", SqlDbType.Int, meterId));
                cmd.Parameters.Add(GetInParameter("@MeterReading", SqlDbType.Int, meterReading));
                cmd.Parameters.Add(GetInParameter("@MeterStatus", SqlDbType.Int, meterStatus));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SaveConsumerFeedBack(int meterId , int consumerId , string remarks)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_Insert_Feedback]",true);
                cmd.Parameters.AddWithValue("@MeterId",meterId);
                cmd.Parameters.AddWithValue("@ConsumerId",consumerId);
                cmd.Parameters.AddWithValue("@Remarks",remarks);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}