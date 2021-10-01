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
using System.Web.Configuration;

public partial class Manager_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtnChangPwd_Click(object sender, EventArgs e)
    {
        ChangePassword1.Visible = true;
    }


    protected void ChangePassword1_ContinueButtonClick(object sender, EventArgs e)
    {
//    	string UserName = Membership.GetUser().UserName;
//    	string Password = Membership.GetUser().GetPassword () ;
//    	UpdateAppSetting("DefaultAdminID",UserName);
//    	UpdateAppSetting("DefaultAdminPassword",Password);
        Response.Redirect(Request.CurrentExecutionFilePath);
    }
    protected void ChangePassword1_CancelButtonClick(object sender, EventArgs e)
    {
        ChangePassword1.Visible = false;
    }
    
    void UpdateAppSetting(string KeyName,string Value){
    	Configuration MyConfig = WebConfigurationManager.OpenWebConfiguration("~");
		MyConfig.AppSettings.Settings.Remove(KeyName);
		MyConfig.AppSettings.Settings.Add(KeyName,Value);
		MyConfig.Save(ConfigurationSaveMode.Modified);
		ConfigurationManager.RefreshSection("appSettings");
    }
}
