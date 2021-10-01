using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
//using Pilot.BusinessLogicLayer;
//using Pilot.Web;


using System.Collections.Generic;
using System.Data.OleDb;
//
//using Pilot.DBUtility;
//
//using Pilot.DataAccessLayer;
//using Pilot.IProfileDAL;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //RestoreProductColor();

        // Test("minip");
        //TestMembership();


       // TranMemberInfo();

    }

//    private void TranMemberInfo()
//    {
//        Response.Buffer = false;
//        IProfileProvider dal = DataAccessHelper.GetProfileDataAccess();
//        List<MemberInfo> infos = dal.GetOldMemberInfo();
//        int UserID = 0;
//        int uniqueID = 0;
//
//        foreach (MemberInfo info in infos)
//        {
//
//            try
//            {
//                if (!string.IsNullOrEmpty(info.OrigenalUserName))
//                {
//                    if (Membership.GetUser(info.OrigenalUserName) != null)
//                    {
//                        UserID++;
//                        //string Pwd = info.OrigenalPassword;
//                        //if (string.IsNullOrEmpty(Pwd))
//                        //{
//                        //    Pwd = Membership.GeneratePassword(10, 0);
//                        //}
//                        //else if (Pwd.Length < 4)
//                        //{
//                        //    Pwd = Membership.GeneratePassword(10, 0);
//                        //}
//                        //Membership.CreateUser(info.OrigenalUserName, Pwd);
//
//                        //ProfileCommon p = Profile.GetProfile(info.OrigenalUserName);
//                        //if (p != null)
//                        //{
//                      
//
//                        //p.MemberInfo = new MemberInfo(info.ChineseName, info.Email, info.Gender, info.YearofBirth, info.MonthofBirth, info.DayofBirth, info.AgeLevel, info.Education, info.Telephone, info.MobilePhone, info.Address, info.ActivityWish, info.OtherWish, info.RegisterIP);
//                        //p.Save();
//                        //}
//
//                        uniqueID = dal.GetUniqueID(info.OrigenalUserName, true, true, "Pilot");
//
//                        if (uniqueID == 0)
//                            uniqueID = dal.CreateProfileForUser(info.OrigenalUserName, true, "Pilot");
//
//                        if (uniqueID > 0)
//                            dal.SetMemberInfo(uniqueID, info);
//                        Response.Write(UserID.ToString() + " : "+ info.OrigenalUserName + "<BR />");
//                    }
//
//
//                }
//
//            }
//            catch (Exception ex)
//            {
//                Response.Write(info.OrigenalUserName + " " + ex.Message + "<BR />");
//            }
//        }
//    }
//
//    private void TestMembership()
//    {
//        if (Membership.GetUser("test") == null)
//        {
//            Membership.CreateUser("test", "test", "test@test.com");
//        }
//        ProfileCommon p = Profile.GetProfile("test");
//        if (p != null)
//        {
//            p.MemberInfo = new MemberInfo("test", "test@test.com", GenderType.male, 2007, 4, 14, "Age", "edu", "tel", "mobile", "addr", "aw", "ow", "ip");
//            p.Save();
//        }
//    }

//    void Test(string userName)
//    {
//        //string sqlSelect = "SELECT  M.ChineseName,M.Email,M.Gender,M.YearofBirth,M.MonthofBirth,M.DayofBirth,M.AgeLevel,M.Eduction,M.Telephone,M.MobilePhone,M.Address,M.ActivityWish,M.OtherWish,M.RegisterIP,M.OrigenalUserName,M.OrigenalPassword FROM MemberInfo M  WHERE  M.OrigenalUserName=@Username ";
//
//        //OleDbCommand OleDbCmd = new OleDbCommand();
//
//        //OleDbHelper.AddParamToOleDbCmd(ref OleDbCmd, "@Username", OleDbType.VarWChar, 50, userName);
//
//        //OleDbHelper.SetCommandType(ref OleDbCmd, CommandType.Text, sqlSelect);
//
//        //List<MemberInfo> dataList = new List<MemberInfo>();
//
//        //OleDbHelper.TExecuteReaderCmd<MemberInfo>(OleDbCmd, OleDbProfileProvider.MemberInfo_TGenerateListFromReader<MemberInfo>, ref dataList);
//
//        //Response.Write(dataList.Count.ToString());
//    }


//    private void RestoreProductColor()
//    {
//        string shortName = string.Empty;
//        string ID;
//        string Code;
//        int ColorID;
//        int ProductID;
//        foreach (string FullFileName in Directory.GetFiles(Server.MapPath("/upload/Product/")))
//        {
//
//            shortName = StringHelper.GetFileName(FullFileName, new Char[] { '\\' }).ToUpper().Replace(".JPG", "");
//
//            ID = GetProductID(shortName);
//            Code = GetColorCode(shortName);
//            ColorID = 0;
//            ProductID = 0;
//
//            if (!string.IsNullOrEmpty(Code))
//            {
//                Color c = Color.GetColorByCode(Code);
//                if (c != null)
//                {
//                    ColorID = c.ColorID;
//                    if (int.TryParse(ID, out ProductID))
//                    {
//                        if (Color.GetColorByProduct(ProductID, ColorID) == null)
//                        {
//                            Product.RemoveProductColor(ProductID, ColorID);
//                            Product.AddProductColor(ProductID, ColorID);
//                            Response.Write(string.Format("{0}  ProductID:{1}  Code:{2} ColorID:{3}<BR />", shortName, ProductID, Code, ColorID));
//                        }
//                    }
//                }
//            }
//
//
//        }
//    }
//
//    public static string GetProductID(string FileName)
//    {
//        string Extension = FileName;
//        if (FileName.IndexOf("-") > 0)
//        {
//            string[] split = FileName.Split(new Char[] { '-' });
//            Extension = split[0];
//
//        }
//
//        return Extension;
//    }
//    public static string GetColorCode(string FileName)
//    {
//        string Extension = string.Empty;
//        if (FileName.IndexOf("-") > 0)
//        {
//            string[] split = FileName.Split(new Char[] { '-' });
//            Extension = split[1];
//        }
//
//        return Extension;
//    }
}
