using RCEMRS.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Http;

namespace RCEMRS.Web.DAL
{
    public class UserAdditionalInfoProvider : UserAdditionalInfoProviderBase
    {
        #region Constructor
        public UserAdditionalInfoProvider() : base() { }
        #endregion

        public bool GetRegister(UserAdditionalnfo entity)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    var user = new User();

                    user.LoginName = entity.UserLoginName;
                    user.Password = entity.UserLoginName;
                    user.Role = entity.Role;


                    new UserProvider().Insert(user);

                    UserAdditionalnfo userAdditionalInfo = new UserAdditionalnfo()
                    {

                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        CnicNumber = entity.CnicNumber,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address,
                        IsActive = entity.IsActive,
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        UserId = user.UserId

                    };


                    new UserAdditionalInfoProvider().Insert(userAdditionalInfo);



                    scope.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<UserAdditionalnfo> GetAllUserInfo()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "[dbo].[usp_User_UserAdditionalDetail]", true);
                IList<UserAdditionalnfo> tmp = new List<UserAdditionalnfo>();
                IDataReader reader = ExecuteReader(cmd);
                FillUserAdditionalInfo(reader, tmp);
                if (!reader.IsClosed) reader.Close();
                return tmp;
            }
            finally
            {
                if (conn != null) conn.Dispose();
                if (cmd != null) cmd.Dispose();
            }
        }

        public IList<UserAdditionalnfo> GetUserInfoById(int userId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "usp_User_UserAdditionalDetailByUserId", true);
                cmd.Parameters.Add(GetInParameter("@UserId", SqlDbType.Int , userId));
                IList<UserAdditionalnfo> tmp = new List<UserAdditionalnfo>();
                IDataReader reader = ExecuteReader(cmd);
                FillUserAdditionalInfo(reader, tmp);
                if (!reader.IsClosed) reader.Close();
                return tmp;
            }
            finally
            {
                if (conn != null) conn.Dispose();
                if (cmd != null) cmd.Dispose();
            }
        }

        public IList<UserAdditionalnfo> DeleteUserByUserId(int userId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = GetConnection();
                cmd = GetCommand(conn, "usp_Cus_DeleteUserByUserId", true);
                cmd.Parameters.Add(GetInParameter("@userId", SqlDbType.Int, userId));
                IList<UserAdditionalnfo> tmp = new List<UserAdditionalnfo>();
                IDataReader reader = ExecuteReader(cmd);
                FillUserAdditionalInfo(reader, tmp);
                if (!reader.IsClosed) reader.Close();
                return tmp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateUserProfile(UserAdditionalnfo entity)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    var user = new User();

                    user.LoginName = entity.UserLoginName;
                    user.Password = entity.UserLoginName;
                    user.Role = entity.Role;


                    new UserProvider().Update(user);

                    UserAdditionalnfo userAdditionalInfo = new UserAdditionalnfo()
                    {

                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        CnicNumber = entity.CnicNumber,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address,
                        IsActive = entity.IsActive,
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = 1,
                        UpdatedDate = DateTime.Now,
                        UserId = entity.UserId

                    };

                    new UserAdditionalInfoProvider().Update(userAdditionalInfo);

                    scope.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private IList<UserAdditionalnfo> FillUserAdditionalInfo(IDataReader reader, IList<UserAdditionalnfo> rows)
        {

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (!reader.Read())
                { break; } // we are done

                var c = new UserAdditionalnfo();
                c.UserId = (int)reader["user_id"];
                c.UserLoginName = (string)reader["user_name"];
                c.UserPassword = (string)reader["user_password"];
                c.Role = (string)reader["user_role"];
                c.UserAdditionalInfoId = (int)reader["user_addtional_info_id"];
                c.FirstName = (string)reader["first_name"];
                c.LastName = (string)reader["last_name"];
                c.CnicNumber = (Int64)reader["cnic_number"];
                c.Email = (string)reader["email_address"];
                c.PhoneNumber = (Int64)reader["phone_number"];
                c.IsActive = Convert.ToInt32(reader["IsActive"]);
                c.CreatedBy = (int)reader["created_by"];
                c.CreatedDate = (DateTime?)reader["created_date"];
                //c.UpdatedBy = Convert.ToInt32(reader["created_date"]);
                rows.Add(c);
            }
            return rows;
        }
    }
}
