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
public partial class Admin_StoreList : System.Web.UI.Page
{
    public int AreaID
    {
        get
        {
            object o = ViewState["AreaID"];
            if (o == null)
                return 0;
            return (int)(o);
        }
        set
        {
            ViewState["AreaID"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindList(SortAscending);
        }
    }
    protected void lbtnNew_Click(object sender, EventArgs e)
    {

        Server.Transfer("StoreModify.aspx");
    }

    void BindList(string sortParameter)
    {

        List<Store> itemList = new List<Store>();
        if (AreaID == 0)
        {
            itemList = Store.GetStore(sortParameter);
        }
        else
        {
       
            List<Store> tmpList = Store.GetStore(sortParameter);
            foreach (Store p in tmpList)
            {
                if (p.AreaID == AreaID)
                {
                    itemList.Add(p);
                }
            }

        }
        lblRowCount.Text = itemList.Count.ToString();
        GridView1.DataSource = itemList;
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
                linkView.NavigateUrl = string.Format("StoreDetail.aspx?ID={0}", intDatalID);
            }

            HyperLink linkModify = (HyperLink)e.Row.FindControl("linkModify");
            if (linkModify != null)
            {
                linkModify.Text = "編輯";
                linkModify.NavigateUrl = string.Format("StoreModify.aspx?ID={0}&back=StoreList.aspx", intDatalID);

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

    public string IsWebDisplay(bool IsDisplay)
    {


        if (IsDisplay)
        {
            return "<img src='image/icon_okay.png'>";
        } return string.Empty;
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int RowID = 0;
        List<Store> dataList;
        int targetIndex = -1;
        switch (e.CommandName)
        {
            case "Delete":
                RowID = Convert.ToInt32(e.CommandArgument);
                Store.Remove(RowID);
                break;
            case "SortUp":
                RowID = Convert.ToInt32(e.CommandArgument);
                dataList = Store.GetStore("SortID");


                foreach (Store c in dataList)
                {
                    int nowIndex = dataList.IndexOf(c);
                    if (c.ID == RowID)
                    {
                        targetIndex = nowIndex;

                    }
                    if (c.SortID != nowIndex)
                    {
                        c.SortID = nowIndex;
                        c.Save();
                    }
                }

                if (targetIndex > 0)
                {
                    dataList[targetIndex].SortID -= 1;
                    dataList[targetIndex - 1].SortID += 1;
                    dataList[targetIndex].Save();
                    dataList[targetIndex - 1].Save();
                }

                BindList(SortParameter);
                break;
            case "SortDown":
                RowID = Convert.ToInt32(e.CommandArgument);
                dataList = Store.GetStore("SortID");


                foreach (Store c in dataList)
                {
                    int nowIndex = dataList.IndexOf(c);
                    if (c.ID == RowID)
                    {
                        targetIndex = nowIndex;

                    }
                    if (c.SortID != nowIndex)
                    {
                        c.SortID = nowIndex;
                        c.Save();
                    }
                }
                if ((targetIndex > 0) & (targetIndex < (dataList.Count - 1)))
                {
                    dataList[targetIndex].SortID += 1;
                    dataList[targetIndex + 1].SortID -= 1;
                    dataList[targetIndex].Save();
                    dataList[targetIndex + 1].Save();
                }
                BindList(SortParameter);
                break;
        }

    }
    
   
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindList(SortParameter);
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        AreaID = Convert.ToInt32(ddlArea.SelectedValue);
        BindList(SortParameter);
    }
}
