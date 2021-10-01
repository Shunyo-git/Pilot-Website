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
using System.Text;

public partial class SearchResult : System.Web.UI.Page
{
    private string _Keyword {
        set { ViewState["Keyword"] = value; }
        get {
            if (ViewState["Keyword"] == null)
                return string.Empty;

            return (string)ViewState["Keyword"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCurrentData();
        if (!Page.IsPostBack)
        {
            BindResult();

        }
    }

    void GetCurrentData()
    {


        if (Request.QueryString["Keyword"] != null )
        {
            _Keyword = Convert.ToString(Request.QueryString["Keyword"]);

        }


    }
    private void BindResult()
    {
        lblKeyword.Text = _Keyword;
        List<Product> records = Product.FindDisplayProduct(_Keyword);
        PagedDataSource pds = new PagedDataSource();


        pds.DataSource = records;
        pds.AllowPaging = true;
        pds.PageSize = 5;

        int CurrentPage;
        if (Request.QueryString["Page"] != null)
            CurrentPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurrentPage = 1;

        pds.CurrentPageIndex = CurrentPage - 1;

        if (!pds.IsFirstPage)
        {
            lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?Keyword=" + _Keyword.ToString() + "&Page=" + Convert.ToInt32(CurrentPage - 1);
        }
        if (!pds.IsLastPage)
        {
            lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?Keyword=" + _Keyword.ToString() + "&Page=" + Convert.ToInt32(CurrentPage + 1);
        }

        DataList1.DataSource = pds;
        DataList1.DataBind();

        lblPageLink.Text = GetPageLink(CurrentPage, pds.PageCount);
    }

    private string GetPageLink(int CurrentPage, int TotalPage)
    {

        string PageText = string.Empty;
        string NavigateUrl = " <a href=\"" + Request.CurrentExecutionFilePath + "?Keyword=" + _Keyword.ToString() + "&Page={0}\">{0}</a> ";


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


    public string DisplayPrice(string price)
    {

        string displayText = string.Empty;

        if (price.IndexOf("#") > 0)
        {
            displayText = "<BR />" + price.Replace("#", " 元<BR />");
        }
        else
        {
            displayText = string.Format("{0} 元", price);
        }


        return displayText;
    }


    public string DisplayMainImage(int ProductID)
    {

        string htmlTemplate = "<img id=\"imgProductMain_{0}\" src=\"Upload/Product/{0}.jpg\" />";
        return string.Format(htmlTemplate, ProductID);

    }

    public string DisplayColorImage(int ProductID)
    {

        StringBuilder sBuilder = new StringBuilder();

        List<Color> colors = Color.GetColorByProduct(ProductID);

        if (colors.Count > 0)
        {
            sBuilder.Append("<img  src=\"img/product/color.gif\"  style=\"vertical-align:top;\" />");
        }
        foreach (Color c in colors)
        {
            sBuilder.Append(string.Format("<a href=\"#\"><img border=\"0\" onmouseout=\"MM_swapImgRestore()\" onmouseover=\"MM_swapImage('imgProductMain_{0}','','Upload/Product/{0}-{1}.jpg',1)\" src=\"img/product/color_{1}.gif\" style=\"cursor:auto;\" /></a> ", ProductID, c.ColorCode));
        }


        return sBuilder.ToString();

    }
}
