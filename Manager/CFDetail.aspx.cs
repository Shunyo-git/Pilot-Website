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
public partial class Manager_CFDetail : System.Web.UI.Page
{
    private PilotCF CurrentObject = null;
    private int _CurrentID = 0;


    void GetCurrentData()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _CurrentID))
        {
            CurrentObject = PilotCF.GetCFById(_CurrentID);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        lbtnDelete.Attributes.Add("onclick", "return chkConfirmDelete()");
        GetCurrentData();
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }
    void BindData()
    {
        if (CurrentObject != null)
        {
            lblID.Text = Convert.ToString(CurrentObject.ID);

            if (CurrentObject.IsDisplay)
            {
                lblIsDisplay.Text = "<img src='/Manager/image/icon_okay.png'> 顯示";
            }
            else
            {
                lblIsDisplay.Text = "<img src='/Manager/image/icon_no.png'> 不顯示";
            }
 

            lblName.Text = CurrentObject.Caption;

            imgLogo.ImageUrl = string.Format("/Upload/CF/{0}.jpg", CurrentObject.ID);

            linkFile.NavigateUrl = string.Format("/Upload/CF/{0}.mp4", CurrentObject.ID);
            if (!File.Exists(Server.MapPath(linkFile.NavigateUrl)))
            {
                linkFile.Text = "尚未上傳檔案";
                linkFile.Enabled = false;
            }
           
        }
    }



    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("CFModify.aspx?ID={0}&&back=CFDetail.aspx", _CurrentID));
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        PilotCF.Remove(_CurrentID);
        Response.Redirect("CFList.aspx");
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFList.aspx");
    }
}
