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

public partial class Manager_MessageListList : System.Web.UI.Page
{

    public int CurrentPageIndex
    {
        set {
            Session["MessageList:PageIndex"] = value;
        }
        get {
            if (Session["MessageList:PageIndex"] == null)
            {
                return 0;
            }
            else {
                return (int)Session["MessageList:PageIndex"];
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int _currentPageIndex = 0;
            if (Request.QueryString["CurrentPageIndex"] != null && Int32.TryParse((string)Request.QueryString["CurrentPageIndex"], out _currentPageIndex))
            {
                GridView1.PageIndex = _currentPageIndex;
            }
            BindDataList(SortAscending);
        }
    }
    

    void BindDataList(string sortParameter)
    {
        List<Message> msgList ;

        if (!string.IsNullOrEmpty(Keyword))
        {

            msgList = Message.FindMessage(Keyword, sortParameter);
             
        }
        else {
            msgList = Message.GetMessage(sortParameter);
        }

        lblTotalCount.Text = msgList.Count.ToString();
        GridView1.DataSource = msgList;
        GridView1.DataBind();
    }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int intDatalID = (int)GridView1.DataKeys[e.Row.RowIndex].Value;
            

            HyperLink linkModify = (HyperLink)e.Row.FindControl("linkModify");
            if (linkModify != null)
            {
                //linkModify.Text = "內容";
                linkModify.NavigateUrl = string.Format("MessageModify.aspx?MsgID={0}&CurrentPageIndex={1}", intDatalID, CurrentPageIndex);

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
        BindDataList(SortParameter);
        CurrentPageIndex = e.NewPageIndex;
    }

    protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
    {

        string sortParameter = e.SortExpression + " " + SortAscending;
        SortParameter = sortParameter;
        BindDataList(sortParameter);

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

    public string DisplayBooleanIcon(bool Value)
    {


        if (Value)
        {
            return "<img src='/Manager/image/icon_okay.png'>";
        } return string.Empty;
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int RowID = 0;
     
        switch (e.CommandName)
        {
            case "Delete":
                RowID = Convert.ToInt32(e.CommandArgument);
                Message.Remove(RowID);
                break;
        
        }

    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindDataList(SortParameter);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtKeyword.Text))
        {

            Keyword = txtKeyword.Text;

        }
        else
        {
            Keyword = string.Empty;
        }
        BindDataList(SortAscending);
    }
    public string Keyword
    {
        get
        {
            object o = Session["Keyword"];
            if (o == null)
                return string.Empty;
            return (string)(o);
        }
        set
        {
            Session["Keyword"] = value;
        }
    }
}
