using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Pilot.DBUtility
{

    /// <summary>
    /// OleDbHelper 的摘要描述
    /// </summary>
    public abstract class OleDbHelper
    {

        /*** PROPERTIES ***/
        public static string ConnectionString
        {
            get
            {

                string ConnectionStringName = ConfigurationManager.AppSettings["ProfileDataAccessConnectionStringName"];
                string connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;

                if (connectionString == null)
                    throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <appSettings> <add key=\"ProfileDataAccessConnectionStringName\" value=\"(ConnectionStringName)\" </appSettings>"));

                if (String.IsNullOrEmpty(connectionString))
                    throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <appSettings> <add key=\"ProfileDataAccessConnectionStringName\" value=\"(ConnectionStringName)\" </appSettings>"));
                else
                    return (connectionString);
            }
        }

        /*** DELEGATE ***/

        public delegate void TGenerateListFromReader<T>(OleDbDataReader returnData, ref List<T> tempList);


        /*****************************  SQL HELPER METHODS *****************************/
        #region SQL HELPER METHODS
        public static int ExecuteScalarCmdGetIdentity(OleDbCommand OleDbCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {
                OleDbCmd.Connection = cn;
                cn.Open();
                OleDbCmd.ExecuteScalar();

                int newID = 0;
                OleDbCommand cmdGetIdentity = new OleDbCommand();
                cmdGetIdentity.CommandType = CommandType.Text;
                cmdGetIdentity.CommandText = "SELECT @@IDENTITY";
                cmdGetIdentity.Connection = cn;

                newID = (int)cmdGetIdentity.ExecuteScalar();
                return newID;
            }
        }
        public static void AddParamToOleDbCmd(ref  OleDbCommand OleDbCmd,
                                      string paramId,
                                       OleDbType sqlType,
                                      int paramSize,
                                      object paramvalue)
        {

            if (OleDbCmd == null)
                throw (new ArgumentNullException("OleDbCmd"));
            if (paramId == string.Empty)
                throw (new ArgumentOutOfRangeException("paramId"));

            OleDbParameter newOleDbParam = new OleDbParameter(paramId, sqlType);

            if (paramSize > 0)
            {
                newOleDbParam.Size = paramSize;
            }

            if (paramvalue != null)
            {
                newOleDbParam.Value = paramvalue;
            }

            OleDbCmd.Parameters.Add(newOleDbParam);
        }


        public static void ExecuteScalarCmd(OleDbCommand OleDbCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (OleDbCmd == null)
                throw (new ArgumentNullException("OleDbCmd"));


            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {
                OleDbCmd.Connection = cn;
                cn.Open();
                OleDbCmd.ExecuteScalar();
            }
        }
        public static void ExecuteNonQueryCmd(OleDbCommand OleDbCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (OleDbCmd == null)
                throw (new ArgumentNullException("OleDbCmd"));


            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {
                OleDbCmd.Connection = cn;
                cn.Open();
                OleDbCmd.ExecuteNonQuery();
            }
        }

        public static void SetCommandType(ref OleDbCommand OleDbCmd, CommandType cmdType, string cmdText)
        {
            OleDbCmd.CommandType = cmdType;
            OleDbCmd.CommandText = cmdText;
        }


        public static void TExecuteReaderCmd<T>(OleDbCommand OleDbCmd, TGenerateListFromReader<T> gcfr, ref List<T> List)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (OleDbCmd == null)
                throw (new ArgumentNullException("OleDbCmd"));


            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {
                OleDbCmd.Connection = cn;
                cn.Open();
                OleDbDataReader reader = OleDbCmd.ExecuteReader();
                gcfr(reader, ref List);
                reader.Close();

            }
        }
        #endregion
    }
}