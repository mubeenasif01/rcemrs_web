using RCEMRS.DAL;
using System;
using RCEMRS.Entites;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
namespace RCEMRS.Web.DAL
{
    public class UserProvider : UserProviderBase
    {
        public UserProvider() : base() { }

        public bool VerifyLogin(User entity)
        {
            
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "dbo.usp_User_Credential", true);
                cmd.Parameters.Add(GetInParameter("@userName", SqlDbType.VarChar, entity.LoginName));
                cmd.Parameters.Add(GetInParameter("@userPassword", SqlDbType.VarChar, entity.Password));
                var reader = ExecuteReader(cmd);

                if (reader.HasRows)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {

                throw;
            }

        }


        public User VerfiyMobileUser(User entity)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_MobileUser_Credential]", true);
                cmd.Parameters.Add(GetInParameter("@MeterId", SqlDbType.Int, entity.MeterId));
                cmd.Parameters.Add(GetInParameter("@ConsumerId", SqlDbType.Int, entity.ConsumerId));
                IDataReader reader = cmd.ExecuteReader();

                if (reader.FieldCount > 0)
                {
                    while (reader.Read())
                    {
                        entity.ConsumerName = reader["consumer_name"].ToString();
                    }
                }
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}