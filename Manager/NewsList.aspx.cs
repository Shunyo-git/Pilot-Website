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
using System.Collections.Generic;

public partial class Manager_NewsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindList(SortAscending);
        }
    }
    protected void lbtnNew_Click(object sender, EventArgs e)
    {

        Response.Redirect("NewsModify.aspx", true);
    }

    void BindList(string sortParameter)
    {
        if (string.IsNullOrEmpty(SortParameter)) { sortParameter = "ID desc"; }
        List<News> itenList = News.GetNews(sortParameter);
        lblRowCount.Text = itenList.Count.ToString();
        GridView1.DataSource = itenList;
        GridView1.DataBind();
    }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int intDatalID = (int)GridView1.DataKeys[e.Row.RowIndex].Value;
            HyperLink linkView = (HyperLink)e.Row.FindControl("linkView");
            if (linkView != null)
            {
                linkView.Text = "檢視";
                linkView.NavigateUrl = string.Format("NewsDetail.aspx?ID={0}", intDatalID);
            }

            HyperLink linkModify = (HyperLink)e.Row.FindControl("linkModify");
            if (linkModify != null)
            {
                linkModify.Text = "編輯";
                linkModify.NavigateUrl = string.Format("NewsModify.aspx?ID={0}&back=NewsList.aspx", intDatalID);

            }

            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            if (lbtnDelete != null)
            {
                lbtnDelete.Attributes.Add("onclick", "return chkConfirmDelete()");
            }
        }
    }

    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        BindList(SortParameter);
    }

    protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
    {

        string sortParameter = e.SortExpression + " " + SortAscending;
        SortParameter = sortParameter;
        BindList(sortParameter);

        bool _reverse;
        _reverse = SortAscending.ToLowerInvariant().EndsWith(" desc");
        if (_reverse)
        {
            SortAscending = string.Empty;
        }
        else
        {
            SortAscending = " desc";
        }
    }
    public string SortParameter
    {
        get
        {
            object o = ViewState["SortParameter"];
            if (o == null)
                return string.Empty;
            return (string)(o);
        }
        set
        {
            ViewState["SortParameter"] = value;
        }
    }
    public string SortAscending
    {
        get
        {
            object o = ViewState["SortAscending"];
            if (o == null)
                return string.Empty;
            return (string)(o);
        }
        set
        {
            ViewState["SortAscending"] = value;
        }
    }

    public string IsWebDisplay(bool Value)
    {


        if (Value)
        {
            return "<img src='image/icon_okay.png'>";
        } return string.Empty;
    }

    public string IsDisplayImage(bool Value)
    {


        if (Value)
        {
            return "圖片";
        } return "文字";
    }
   
    
    

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int RowID = 0;
     
        switch (e.CommandName)
        {
            case "Delete":
                RowID = Convert.ToInt32(e.CommandArgument);
                News.Remove(RowID);
                break;
         
        }

    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindList(SortParameter);
    }
}
