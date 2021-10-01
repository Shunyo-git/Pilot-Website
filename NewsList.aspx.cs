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

public partial class NewsList : System.Web.UI.Page
{
    bool _IsHotNews = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCurrentData();
        if (!Page.IsPostBack)
        {
            BindDataList();

        }
        lnkPrev.Attributes.Add("onmouseout", "MM_swapImgRestore()");
        lnkPrev.Attributes.Add("onmouseover", "MM_swapImage('Image31','','img/frame/arrow_left2.gif',1)");
        lnkNext.Attributes.Add("onmouseout", "MM_swapImgRestore()");
        lnkNext.Attributes.Add("onmouseover", "MM_swapImage('Image32','','img/frame/arrow_right2.gif',1)");
    }

    private void GetCurrentData()
    {
        if(Request.QueryString["HotNews"] != null && Convert.ToString(Request.QueryString["HotNews"]).ToLower() == "n" ){
            _IsHotNews = false;
        }
        PanelHotNewsTitle.Visible = _IsHotNews;
        PanelHistoryNewsTitle.Visible = !(_IsHotNews);
    }


    private void BindDataList()
    {
        List<News> records = News.GetNews(_IsHotNews,ApproveType.Approved);
        PagedDataSource pds = new PagedDataSource();


        pds.DataSource = records;
        pds.AllowPaging = true;
        pds.PageSize = 8;

        int CurrentPage;
        if (Request.QueryString["Page"] != null)
            CurrentPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurrentPage = 1;

        pds.CurrentPageIndex = CurrentPage - 1;

        string HotNewsUrl = string.Empty;

        if (!_IsHotNews)
        {
            HotNewsUrl = "&HotNews=n";
        }

        if (!pds.IsFirstPage)
        {
            lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(CurrentPage - 1) + HotNewsUrl;
        }
        if (!pds.IsLastPage)
        {
            lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(CurrentPage + 1) + HotNewsUrl;
        }

        DataList1.DataSource = pds;
        DataList1.DataBind();

        lblPageLink.Text = GetPageLink(CurrentPage, pds.PageCount);
    }

    private string GetPageLink(int CurrentPage, int TotalPage)
    {

        string PageText = string.Empty;
        string HotNewsUrl = string.Empty;

        if (!_IsHotNews)
        {
            HotNewsUrl = "&HotNews=n";
        }
        string NavigateUrl = " <a href=\"" + Request.CurrentExecutionFilePath + "?Page={0}{1}\">{0}</a> ";


        for (int i = 1; i <= TotalPage; i++)
        {
            if (i == CurrentPage)
            {
                PageText += string.Format(" [ {0} ] ", i);
            }
            else
            {
                PageText += string.Format(NavigateUrl, i, HotNewsUrl);
            }
        }
        return PageText;
    }

    public string DisplayNewsImage(int NewsID, bool IsDisplayImage) {
        string imgText = "<td  width=\"30\"><a href='NewsDetail.aspx?ID={0}'><img border=\"0\" src=\"Upload/News/Thumb/{0}.jpg\"  /></a></td><td width=\"10\"> &nbsp;</td>";
        if(IsDisplayImage){
            return string.Format(imgText, NewsID);
        }else{
            return string.Empty;
        }
    }
}
