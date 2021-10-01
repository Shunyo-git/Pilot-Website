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
using Pilot.BusinessLogicLayer;
using Pilot.Web;
using System.Collections.Generic;
using System.IO;

public partial class Manager_MessageModify : System.Web.UI.Page
{
    private Message CurrentMessage = null;
    private int _MsgID = 0;
    private string _backto = "MessageList.aspx";

     
    void GetCurrentMessage()
    {

        if (Request.QueryString["MsgID"] != null && Int32.TryParse((string)Request.QueryString["MsgID"], out _MsgID))
        {
            CurrentMessage = Message.GetMessage(_MsgID);

        }
        if (Request.QueryString["CurrentPageIndex"] != null)
        {
           　
            _backto += "?CurrentPageIndex=";
            _backto += (string)Request.QueryString["CurrentPageIndex"];
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {


        GetCurrentMessage();
        
        if (!Page.IsPostBack)
        {
            BindMessage();
        }

    }

    private void BindMessage()
    {
        if (CurrentMessage != null)
        {
            lblID.Text = Convert.ToString(CurrentMessage.MsgID);
            rbtnIsDone.SelectedValue = CurrentMessage.IsDone.ToString();
            lblCreationDate.Text = CurrentMessage.CreationDate.ToString("yyyy-MM-dd hh:mm");
            lblIP.Text = CurrentMessage.IP;
            lblUpdateDate.Text = CurrentMessage.UpdateDate.ToString("yyyy-MM-dd hh:mm");
             
            lblName.Text = CurrentMessage.Name;
            lblGender.Text = CurrentMessage.Gender;
            lblBirthday.Text = CurrentMessage.Birthday;
            lblEmail.Text = CurrentMessage.Email;
            lblTelephone.Text = CurrentMessage.Telephone;
            lblMobile.Text = CurrentMessage.Mobile;
            lblContact.Text = CurrentMessage.Contact;
            
            lblContent.Text = WebUtility.CrToBr(CurrentMessage.Content);
            txtNote.Text = CurrentMessage.Note;
            
        }
     
    }
 

    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        bool blnResult = false;


        if (CurrentMessage!= null)
        {
              
            CurrentMessage.IsDone = Convert.ToBoolean(rbtnIsDone.SelectedValue);
            CurrentMessage.Note = txtNote.Text;
         
            blnResult = CurrentMessage.Save();
            
        }

        if (!blnResult)
        {
            ValidatorResult.Text = "儲存失敗，請檢查您的資料後重新再試一次。";
            ValidatorResult.IsValid = false;
            Response.Write("There was an error.  Please fix it and try it again.");
        }
        else
        {


            Response.Redirect(_backto);

        }
    }
 

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(_backto);
    }
}
