using System;
using System.Configuration;
using Pilot.IProfileDAL;
/// <summary>
/// Summary description for DataAccessHelper
/// </summary>
namespace Pilot.DataAccessLayer
{
    public class DataAccessHelper
    {
        public static DataAccess GetDataAccess()
        {
            string dataAccessStringType = ConfigurationManager.AppSettings["DataAccessType"];
            if (String.IsNullOrEmpty(dataAccessStringType))
            {
                throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <appSettings> <add key=\"DataAccessType\" value=\"(DataAccessProvider)\" </appSettings>"));
            }
            else
            {
                Type dataAccessType = Type.GetType(dataAccessStringType);
                if (dataAccessType == null)
                {
                    throw (new NullReferenceException("DataAccessType can not be found"));
                }

                //Type tp = Type.GetType("Pilot.DataAccessLayer.SQLDataAccessProvider");
                //if (!tp.IsAssignableFrom(dataAccessType))
                //{
                //    throw (new ArgumentException("DataAccessType does not inherits from Pilot.DataAccessLayer.SQLDataAccessProvider "));

                //}
                DataAccess dc = (DataAccess)Activator.CreateInstance(dataAccessType);
                return (dc);
            }


        }
        public static IProfileProvider GetProfileDataAccess()
        {
             //return new SQLProfileProvider();

             string dataAccessStringType = ConfigurationManager.AppSettings["ProfileDataAccessType"];
             if (String.IsNullOrEmpty(dataAccessStringType))
             {
                 throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <appSettings> <add key=\"ProfileDataAccessType\" value=\"(Profile DataAccessProvider)\" </appSettings>"));
             }
             else
             {
                 Type dataAccessType = Type.GetType(dataAccessStringType);
                 if (dataAccessType == null)
                 {
                     throw (new NullReferenceException("DataAccessType can not be found"));
                 }

                 //Type tp = Type.GetType("Pilot.DataAccessLayer.SQLDataAccessProvider");
                 //if (!tp.IsAssignableFrom(dataAccessType))
                 //{
                 //    throw (new ArgumentException("DataAccessType does not inherits from Pilot.DataAccessLayer.SQLDataAccessProvider "));

                 //}
                 IProfileProvider dc = (IProfileProvider)Activator.CreateInstance(dataAccessType);
                 return (dc);
             }

        }

        //public static AccessDataProvider GetDataAccess()
        //{
        //    Type dataAccessType = Type.GetType("Pilot.DataAccessLayer.AccessDataProvider");
        //    AccessDataProvider dc = (AccessDataProvider)Activator.CreateInstance(dataAccessType);
        //    return (dc);
        //}
    }
}
