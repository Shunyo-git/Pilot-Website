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
public partial class Manager_WallpaperDetail : System.Web.UI.Page
{
    private Wallpaper CurrentObject = null;
    private int _CurrentID = 0;


    void GetCurrentData()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _CurrentID))
        {
            CurrentObject = Wallpaper.GetWallpaperById(_CurrentID);
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

            imgLogo.ImageUrl = string.Format("/Upload/Download/{0}.gif", CurrentObject.ID);

            link800.NavigateUrl = string.Format("/Upload/Download/wall{0}_800x600.jpg", CurrentObject.ID);
            if (!File.Exists(Server.MapPath(link800.NavigateUrl)))
            {
                link800.Text = "尚未上傳檔案800x600";
                link800.Enabled = false;
            }

            link1024.NavigateUrl = string.Format("/Upload/Download/wall{0}_1024x768.jpg", CurrentObject.ID);
            if (!File.Exists(Server.MapPath(link1024.NavigateUrl)))
            {
                link1024.Text = "尚未上傳檔案1024x768";
                link1024.Enabled = false;
            }
           
        }
    }



    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("WallpaperModify.aspx?ID={0}&&back=WallpaperDetail.aspx", _CurrentID));
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        Wallpaper.Remove(_CurrentID);
        Response.Redirect("WallpaperList.aspx");
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("WallpaperList.aspx");
    }
}
