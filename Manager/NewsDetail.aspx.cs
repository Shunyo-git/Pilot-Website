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

public partial class Manager_NewsDetail : System.Web.UI.Page
{
    private News CurrentObject = null;
    private int _CurrentID = 0;


    void GetCurrentData()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _CurrentID))
        {
            CurrentObject = News.GetNews(_CurrentID);
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

            if (CurrentObject.IsApproved)
            {
                lblIsApproved.Text = "<img src='/Manager/image/icon_okay.png'> 顯示";
            }
            else
            {
                lblIsApproved.Text = "<img src='/Manager/image/icon_no.png'> 不顯示";
            }

            if (CurrentObject.IsMainPageDisplay)
            {
                lblIsMainPageDisplay.Text = "<img src='/Manager/image/icon_okay.png'> 顯示";
            }
            else
            {
                lblIsMainPageDisplay.Text = "<img src='/Manager/image/icon_no.png'> 不顯示";
            }

            if (CurrentObject.IsDisplayImage)
            {
                lblIsDisplayImage.Text = "圖片版型";
            }
            else
            {
                lblIsDisplayImage.Text = "文字版型";
            }
            
        
                lblCategory.Text = Pilot.BusinessLogicLayer.News.IsHotNewsDisplay(CurrentObject.IsHotNews);
           
            lblName.Text = CurrentObject.Caption;
            lblForeword.Text = StringHelper.NewLineToBreak( CurrentObject.Foreword);
            lblContent.Text = StringHelper.NewLineToBreak(CurrentObject.Content);
            lblCreationDate.Text = CurrentObject.CreationDate.ToString();
            imgLogo.ImageUrl = string.Format("/Upload/News/{0}.jpg", CurrentObject.ID);
        }
    }



    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("NewsModify.aspx?ID={0}&&back=NewsDetail.aspx", _CurrentID));
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        News.Remove(_CurrentID);
        Response.Redirect("NewsList.aspx");
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewsList.aspx");
    }
}
