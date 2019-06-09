using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCEMRS.Web.DAL
{
    public class SqlProviderBase
    {
        #region  ConnectionString
        public const string DefualtConnection = "RCEMRSystem";
        private static Dictionary<string, string> ConnectionString = InitConnection();

        private static Dictionary<string, string > InitConnection()
        {
            var ConnectionString = new Dictionary<string, string>
            {
                {DefualtConnection , ConfigurationManager.ConnectionStrings[DefualtConnection].ConnectionString}
            };

            return ConnectionString;
        }
        #endregion ConnectionString

        /// <summary>
        /// Get Connection string from ConnectionString Dictionary 
        /// Get open connection with database
        /// Return SqlConnection type object
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionString[DefualtConnection]);
            conn.Open();
            return conn;
        }

       

        /// <summary>
        /// Get Sqlconnection to open connection with database
        /// Get Sql Command and check whhter command type is storedprocedure or inline query text
        /// Return Sql commmand type cmd object to calling party
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandName"></param>
        /// <param name="useStoredProcedure"></param>
        /// <returns></returns>
        public static SqlCommand GetCommand(SqlConnection conn , string commandName, bool useStoredProcedure)
        {
          var cmd = new SqlCommand(commandName, conn)
            {
                CommandType = useStoredProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text
            };

            return cmd;
        }

        /// <summary>
        /// Get paramName ,sqldbType and value of paramName that want to store into the database
        /// Check dbtype is same as in the backend if not <paramref = dbtype > give exception Invlid dataType
        /// Return sqlparamter type object 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SqlParameter GetInParameter(string paramName , SqlDbType dbType , object value)
        {
            var param = new SqlParameter(paramName, dbType) { Value = value };
            return param;
        }

        /// <summary>
        /// Get sql command type object 
        /// Execute command on the database
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public static object ExecuteNonQuery(SqlCommand sqlCommand)
        {
            var executeQuery = sqlCommand.ExecuteNonQuery();
           
            return executeQuery;
        }

        public static SqlDataReader ExecuteReader(SqlCommand command)
        {
            var results = command.ExecuteReader();
            return results;
        }
    }
}
