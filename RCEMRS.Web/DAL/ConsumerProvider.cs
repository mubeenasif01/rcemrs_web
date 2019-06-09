using RCEMRS.Web.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;

namespace RCEMRS.Web.DAL
{
    public class ConsumerProvider:ConsumerProviderBase
    {
        #region
        public ConsumerProvider() : base(){ }
        #endregion

        public bool RegisterConsumer(Consumer entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "usp_RegisterConsumerMeter", true);
                cmd.Parameters.Add(GetInParameter("@ConsumerName", SqlDbType.VarChar, entity.ConsumerName));
                cmd.Parameters.Add(GetInParameter("@ConsumerFatherName", SqlDbType.VarChar, entity.ConsumerFatherName));
                cmd.Parameters.Add(GetInParameter("@ConsumerCnicNo", SqlDbType.BigInt, entity.ConsumerCnicNo));
                cmd.Parameters.Add(GetInParameter("@ConsumerDoB", SqlDbType.DateTime, entity.ConsumerDoB));
                cmd.Parameters.Add(GetInParameter("@ConsumerPhoneNo", SqlDbType.Int, entity.ConsumerPhoneNumber));
                cmd.Parameters.Add(GetInParameter("@ConsumerAddress", SqlDbType.VarChar, entity.ConsumerAddress));
                cmd.Parameters.Add(GetInParameter("@IsActive", SqlDbType.Bit, entity.IsActive));
                cmd.Parameters.Add(GetInParameter("@CreatedBy", SqlDbType.Int, entity.CreatedBy));
                cmd.Parameters.Add(GetInParameter("@MeterNumber", SqlDbType.Int, entity.MeterNumber));
                cmd.Parameters.Add(GetInParameter("@MeterStatus", SqlDbType.Int, entity.MeterStatus));
                cmd.Parameters.Add(GetInParameter("@MeterType", SqlDbType.Int, entity.MeterType));

                ExecuteNonQuery(cmd);
               
                return true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null) conn.Dispose();
            }

        }

        public bool DeleteConsumerMeterDetail(int consumerId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    conn = GetConnection();
                    cmd = GetCommand(conn, "[usp_DeleteConsumerMeterDetailByConsumerId]", true);
                    cmd.Parameters.Add(GetInParameter("@ConsumerId",SqlDbType.Int, consumerId));
                    cmd.ExecuteNonQuery();

                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsActiveConsumer(int consumerId , bool isActive)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    conn = GetConnection();
                    cmd = GetCommand(conn, "[usp_IsActiveConsumer]", true);
                    cmd.Parameters.Add(GetInParameter("@ConsumerId", SqlDbType.Int, consumerId));
                    cmd.Parameters.Add(GetInParameter("@IsActive", SqlDbType.Bit, isActive));
                    cmd.ExecuteNonQuery();

                    scope.Complete();
                    return true;
                }
            
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}