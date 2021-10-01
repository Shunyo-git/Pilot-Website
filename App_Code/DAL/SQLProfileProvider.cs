
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Pilot.DBUtility;
using Pilot.BusinessLogicLayer;
using Pilot.IProfileDAL;

namespace Pilot.DataAccessLayer
{
    public class SQLProfileProvider : IProfileProvider
    {

        // Contst matching System.Web.Profile.ProfileAuthenticationOption.Anonymous
        private const int AUTH_ANONYMOUS = 0;

        // Contst matching System.Web.Profile.ProfileAuthenticationOption.Authenticated
        private const int AUTH_AUTHENTICATED = 1;

        // Contst matching System.Web.Profile.ProfileAuthenticationOption.All
        private const int AUTH_ALL = 2;

        /// <summary>
        /// Retrieve account information for current username and application.
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Account information for current user</returns>
        public MemberInfo GetMemberInfo(string userName, string appName)
        {

            string sqlSelect = "SELECT  M.ChineseName,M.Email,M.Gender,M.YearofBirth,M.MonthofBirth,M.DayofBirth,M.AgeLevel,M.Eduction,M.Telephone,M.MobilePhone,M.Address,M.ActivityWish,M.OtherWish,M.RegisterIP,M.OrigenalUserName,M.OrigenalPassword FROM MemberInfo M INNER JOIN Profiles P ON M.UID = P.UID WHERE M.IsDelete=0 AND P.Username = @Username AND P.ApplicationName = @ApplicationName;";


            SqlParameter[] parms = {					   
				new SqlParameter("@Username", SqlDbType.VarChar, 256),
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};
            parms[0].Value = userName;
            parms[1].Value = appName;

            MemberInfo memberinfo = null;

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlSelect, parms);
            while (dr.Read())
            {

                GenderType gender = GenderType.unknown;

                switch (dr.GetInt32(1))
                {
                    case 0:
                        gender = GenderType.unknown;
                        break;
                    case 1:
                        gender = GenderType.male;
                        break;
                    case 2:
                        gender = GenderType.female;
                        break;
                    default:
                        break;
                }


                //string ChineseName, string Email, GenderType Gender, int YearofBirth, int MonthofBirth, int DayofBirth, string AgeLevel, string Eduction, string Telephone, string MobilePhone, string Address, string ActivityWish, string OtherWish, string RegisterIP, string OrigenalUserName, string OrigenalPassword
                memberinfo = new MemberInfo(dr.GetString(0), dr.GetString(1), gender, dr.GetInt32(3), dr.GetInt32(4), dr.GetInt32(5), dr.GetString(6), dr.GetString(7), dr.GetString(8), dr.GetString(9), dr.GetString(10), dr.GetString(11), dr.GetString(12), dr.GetString(13));
            }
            dr.Close();

            return memberinfo;
        }

        /// <summary>
        /// Update account for current user
        /// </summary>
        /// <param name="uniqueID">User id</param>
        /// <param name="addressInfo">Account information for current user</param>   
        public void SetMemberInfo(int uniqueID, MemberInfo memberInfo)
        {
            string sqlDelete = "UPDATE MemberInfo SET IsDelete = 1 ,DeletedDate = GetDate() WHERE UID = @UniqueID;";
            SqlParameter param = new SqlParameter("@UniqueID", SqlDbType.Int);
            param.Value = uniqueID;

            string sqlInsert = "INSERT INTO MemberInfo (UID, ChineseName,Email,Gender,YearofBirth,MonthofBirth,DayofBirth,AgeLevel,Eduction,Telephone,MobilePhone,Address,ActivityWish,OtherWish,RegisterIP,OrigenalUserName,OrigenalPassword) VALUES (@UniqueID, @ChineseName,@Email,@Gender,@YearofBirth,@MonthofBirth,@DayofBirth,@AgeLevel,@Eduction,@Telephone,@MobilePhone,@Address,@ActivityWish,@OtherWish,@RegisterIP,@OrigenalUserName,@OrigenalPassword);";

            //@ChineseName,@Email,@Gender,@YearofBirth,@MonthofBirth,@DayofBirth,@AgeLevel,@Eduction,@Telephone,@MobilePhone,@Address,@ActivityWish,@OtherWish,@RegisterIP,@OrigenalUserName,@OrigenalPassword
			
            SqlParameter[] parms = {					   
			new SqlParameter("@UniqueID", SqlDbType.Int),
                new SqlParameter("@ChineseName", SqlDbType.NVarChar, 50),
			new SqlParameter("@Email", SqlDbType.NVarChar, 200),
            new SqlParameter("@Gender", SqlDbType.Int, 4),
                new SqlParameter("@YearofBirth", SqlDbType.Int, 4),
                new SqlParameter("@MonthofBirth", SqlDbType.Int, 4),
                new SqlParameter("@DayofBirth", SqlDbType.Int, 4),
			new SqlParameter("@AgeLevel", SqlDbType.NVarChar,50),
                new SqlParameter("@Eduction", SqlDbType.NVarChar,50),
                new SqlParameter("@Telphone", SqlDbType.NVarChar,50),
			new SqlParameter("@MobilePhone", SqlDbType.NVarChar, 50),
			new SqlParameter("@Address", SqlDbType.NVarChar, 300),
			new SqlParameter("@ActivityWish", SqlDbType.NVarChar, 50),
			new SqlParameter("@OtherWish", SqlDbType.NVarChar, 200),
			new SqlParameter("@RegisterIP", SqlDbType.NVarChar, 50),
            new SqlParameter("@OrigenalUserName", SqlDbType.NVarChar, 50),
            new SqlParameter("@OrigenalPassword", SqlDbType.NVarChar, 50)
            };

            parms[0].Value = uniqueID;
            parms[1].Value = memberInfo.ChineseName;
            parms[2].Value = memberInfo.Email;
            parms[3].Value = Convert.ToInt16(memberInfo.Gender);
            parms[4].Value = memberInfo.YearofBirth;
            parms[5].Value = memberInfo.MonthofBirth;
            parms[6].Value = memberInfo.DayofBirth;
            parms[7].Value = memberInfo.AgeLevel;
            parms[8].Value = memberInfo.Eduction;
            parms[9].Value = memberInfo.Telephone;
            parms[10].Value = memberInfo.MobilePhone;
            parms[11].Value = memberInfo.Address;
            parms[12].Value = memberInfo.ActivityWish;
            parms[13].Value = memberInfo.OtherWish;
            parms[14].Value = memberInfo.RegisterIP;
            parms[15].Value = memberInfo.OrigenalUserName;
            parms[16].Value = memberInfo.OrigenalPassword;

            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringProfile);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlDelete, param);
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlInsert, parms);
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new ApplicationException(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }




        /// <summary>
        /// Update activity dates for current user and application
        /// </summary>
        /// <param name="userName">USer name</param>
        /// <param name="activityOnly">Activity only flag</param>
        /// <param name="appName">Application Name</param>
        public void UpdateActivityDates(string userName, bool activityOnly, string appName)
        {
            DateTime activityDate = DateTime.Now;

            string sqlUpdate;
            SqlParameter[] parms;

            if (activityOnly)
            {
                sqlUpdate = "UPDATE Profiles Set LastActivityDate = @LastActivityDate WHERE IsDelete = 0 AND Username = @Username AND ApplicationName = @ApplicationName;";
                parms = new SqlParameter[]{						   
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.VarChar, 256),
					new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};

                parms[0].Value = activityDate;
                parms[1].Value = userName;
                parms[2].Value = appName;

            }
            else
            {
                sqlUpdate = "UPDATE Profiles Set LastActivityDate = @LastActivityDate, LastUpdatedDate = @LastUpdatedDate WHERE IsDelete = 0 AND Username = @Username AND ApplicationName = @ApplicationName;";
                parms = new SqlParameter[]{
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.VarChar, 256),
					new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};

                parms[0].Value = activityDate;
                parms[1].Value = activityDate;
                parms[2].Value = userName;
                parms[3].Value = appName;
            }

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlUpdate, parms);

        }

        /// <summary>
        /// Retrive unique id for current user
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="isAuthenticated">Authentication flag</param>
        /// <param name="ignoreAuthenticationType">Ignore authentication flag</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Unique id for current user</returns>
        public int GetUniqueID(string userName, bool isAuthenticated, bool ignoreAuthenticationType, string appName)
        {
            string sqlSelect = "SELECT UID FROM Profiles WHERE IsDelete = 0 AND Username = @Username AND ApplicationName = @ApplicationName";

            SqlParameter[] parms = {
				new SqlParameter("@Username", SqlDbType.VarChar, 256),
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};
            parms[0].Value = userName;
            parms[1].Value = appName;

            if (!ignoreAuthenticationType)
            {
                sqlSelect += " AND IsAnonymous = @IsAnonymous";
                Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                parms[2].Value = !isAuthenticated;
            }

            int uniqueID = 0;

            object retVal = null;
            retVal = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlSelect, parms);

            if (retVal == null)
                uniqueID = CreateProfileForUser(userName, isAuthenticated, appName);
            else
                uniqueID = Convert.ToInt32(retVal);
            return uniqueID;
        }

        /// <summary>
        /// Create profile record for current user
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="isAuthenticated">Authentication flag</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Number of records created</returns>
        public int CreateProfileForUser(string userName, bool isAuthenticated, string appName)
        {

            string sqlInsert = "INSERT INTO Profiles (Username, ApplicationName, LastActivityDate, LastUpdatedDate, IsAnonymous) Values(@Username, @ApplicationName, @LastActivityDate, @LastUpdatedDate, @IsAnonymous); SELECT @@IDENTITY;";

            SqlParameter[] parms = {
				new SqlParameter("@Username", SqlDbType.VarChar, 256),
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256),
				new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
				new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime),
				new SqlParameter("@IsAnonymous", SqlDbType.Bit)};

            parms[0].Value = userName;
            parms[1].Value = appName;
            parms[2].Value = DateTime.Now;
            parms[3].Value = DateTime.Now;
            parms[4].Value = !isAuthenticated;

            int uniqueID = 0;
            int.TryParse(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlInsert, parms).ToString(), out uniqueID);

            return uniqueID;
        }

        /// <summary>
        /// Retrieve colection of inactive user id's
        /// </summary>
        /// <param name="authenticationOption">Authentication option</param>
        /// <param name="userInactiveSinceDate">Date to start search from</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Collection of inactive profile id's</returns>
        public IList<string> GetInactiveProfiles(int authenticationOption, DateTime userInactiveSinceDate, string appName)
        {

            StringBuilder sqlSelect = new StringBuilder("SELECT Username FROM Profiles WHERE IsDelete = 0 AND ApplicationName = @ApplicationName AND LastActivityDate <= @LastActivityDate");

            SqlParameter[] parms = {
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256),
				new SqlParameter("@LastActivityDate", SqlDbType.DateTime)};
            parms[0].Value = appName;
            parms[1].Value = userInactiveSinceDate;

            switch (authenticationOption)
            {
                case AUTH_ANONYMOUS:
                    sqlSelect.Append(" AND IsAnonymous = @IsAnonymous");
                    Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                    parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                    parms[2].Value = true;
                    break;
                case AUTH_AUTHENTICATED:
                    sqlSelect.Append(" AND IsAnonymous = @IsAnonymous");
                    Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                    parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                    parms[2].Value = false;
                    break;
                default:
                    break;
            }

            IList<string> usernames = new List<string>();

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlSelect.ToString(), parms);
            while (dr.Read())
            {
                usernames.Add(dr.GetString(0));
            }

            dr.Close();
            return usernames;
        }

        /// <summary>
        /// Delete user's profile
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="appName">Application Name</param>
        /// <returns>True, if profile successfully deleted</returns>
        public bool DeleteProfile(string userName, string appName)
        {

            int uniqueID = GetUniqueID(userName, false, true, appName);

            string sqlDelete = "UPDATE Profiles SET IsDelete=1 AND DeletedDate = GetDate() WHERE UID = @UniqueID;";
            SqlParameter param = new SqlParameter("@UniqueId", SqlDbType.Int, 4);
            param.Value = uniqueID;

            int numDeleted = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlDelete, param);

            if (numDeleted <= 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Retrieve profile information
        /// </summary>
        /// <param name="authenticationOption">Authentication option</param>
        /// <param name="usernameToMatch">User name</param>
        /// <param name="userInactiveSinceDate">Date to start search from</param>
        /// <param name="appName">Application Name</param>
        /// <param name="totalRecords">Number of records to return</param>
        /// <returns>Collection of profiles</returns>
        public IList<CustomProfileInfo> GetProfileInfo(int authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, string appName, out int totalRecords)
        {

            // Retrieve the total count.
            StringBuilder sqlSelect1 = new StringBuilder("SELECT COUNT(*) FROM Profiles WHERE IsDelete = 0 AND ApplicationName = @ApplicationName");
            SqlParameter[] parms1 = {
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};
            parms1[0].Value = appName;

            // Retrieve the profile data.
            StringBuilder sqlSelect2 = new StringBuilder("SELECT Username, LastActivityDate, LastUpdatedDate, IsAnonymous FROM Profiles WHERE IsDelete = 0 AND ApplicationName = @ApplicationName");
            SqlParameter[] parms2 = { new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256) };
            parms2[0].Value = appName;

            int arraySize;

            // If searching for a user name to match, add the command text and parameters.
            if (usernameToMatch != null)
            {
                arraySize = parms1.Length;

                sqlSelect1.Append(" AND Username LIKE @Username ");
                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                parms1[arraySize] = new SqlParameter("@Username", SqlDbType.VarChar, 256);
                parms1[arraySize].Value = usernameToMatch;

                sqlSelect2.Append(" AND Username LIKE @Username ");
                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                parms2[arraySize] = new SqlParameter("@Username", SqlDbType.VarChar, 256);
                parms2[arraySize].Value = usernameToMatch;
            }


            // If searching for inactive profiles, 
            // add the command text and parameters.
            if (userInactiveSinceDate != null)
            {
                arraySize = parms1.Length;

                sqlSelect1.Append(" AND LastActivityDate >= @LastActivityDate ");
                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                parms1[arraySize] = new SqlParameter("@LastActivityDate", SqlDbType.DateTime);
                parms1[arraySize].Value = (DateTime)userInactiveSinceDate;

                sqlSelect2.Append(" AND LastActivityDate >= @LastActivityDate ");
                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                parms2[arraySize] = new SqlParameter("@LastActivityDate", SqlDbType.DateTime);
                parms2[arraySize].Value = (DateTime)userInactiveSinceDate;
            }


            // If searching for a anonymous or authenticated profiles,    
            // add the command text and parameters.	
            if (authenticationOption != AUTH_ALL)
            {
                arraySize = parms1.Length;

                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                sqlSelect1.Append(" AND IsAnonymous = @IsAnonymous");
                parms1[arraySize] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);

                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                sqlSelect2.Append(" AND IsAnonymous = @IsAnonymous");
                parms2[arraySize] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);

                switch (authenticationOption)
                {
                    case AUTH_ANONYMOUS:
                        parms1[arraySize].Value = true;
                        parms2[arraySize].Value = true;
                        break;
                    case AUTH_AUTHENTICATED:
                        parms1[arraySize].Value = false;
                        parms2[arraySize].Value = false;
                        break;
                    default:
                        break;
                }
            }

            IList<CustomProfileInfo> profiles = new List<CustomProfileInfo>();

            // Get the profile count.
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlSelect1.ToString(), parms1);

            // No profiles found.
            if (totalRecords <= 0)
                return profiles;

            SqlDataReader dr;
            dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlSelect2.ToString(), parms2);
            while (dr.Read())
            {
                CustomProfileInfo profile = new CustomProfileInfo(dr.GetString(0), dr.GetDateTime(1), dr.GetDateTime(2), dr.GetBoolean(3));
                profiles.Add(profile);
            }
            dr.Close();

            return profiles;
        }
    }
}

