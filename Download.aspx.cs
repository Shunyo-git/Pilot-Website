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
using System.Collections.Generic;
using Pilot.BusinessLogicLayer;
public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            BindDataList();

        }
        lnkPrev.Attributes.Add("onmouseout", "MM_swapImgRestore()");
        lnkPrev.Attributes.Add("onmouseover", "MM_swapImage('Image31','','img/frame/arrow_left2.gif',1)");
        lnkNext.Attributes.Add("onmouseout", "MM_swapImgRestore()");
        lnkNext.Attributes.Add("onmouseover", "MM_swapImage('Image32','','img/frame/arrow_right2.gif',1)");
    }
    private void BindDataList()
    {
        List<Wallpaper> records = Wallpaper.GetDisplayWallpaper();
        PagedDataSource pds = new PagedDataSource();


        pds.DataSource = records;
        pds.AllowPaging = true;
        pds.PageSize = 3;

        int CurrentPage;
        if (Request.QueryString["Page"] != null)
            CurrentPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurrentPage = 1;

        pds.CurrentPageIndex = CurrentPage - 1;

        if (!pds.IsFirstPage)
        {
            lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(CurrentPage - 1);
        }
        if (!pds.IsLastPage)
        {
            lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(CurrentPage + 1);
        }

        DataList1.DataSource = pds;
        DataList1.DataBind();

        lblPageLink.Text = GetPageLink(CurrentPage, pds.PageCount);
    }

    private string GetPageLink(int CurrentPage, int TotalPage)
    {

        string PageText = string.Empty;
        string NavigateUrl = " <a href=\"" + Request.CurrentExecutionFilePath + "?Page={0}\">{0}</a> ";


        for (int i = 1; i <= TotalPage; i++)
        {
            if (i == CurrentPage)
            {
                PageText += string.Format(" [ {0} ] ", i);
            }
            else
            {
                PageText += string.Format(NavigateUrl, i);
            }
        }
        return PageText;
    }
}
