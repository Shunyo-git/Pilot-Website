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

public partial class Manager_ProductList : System.Web.UI.Page
{
    public int CategoryID
    {
        get
        {
            object o = ViewState["CategoryID"];
            if (o == null)
                return 0;
            return (int)(o);
        }
        set
        {
            ViewState["CategoryID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            BingCategory();
            BindList(SortAscending);
        }
    }
    private void BingCategory()
    {
        List<Category> itemList = new List<Category>();
        itemList = Category.GetCategory();
        itemList.Insert(0, new Category(0, 0, "所有類別",false,0));
        ddlCategory.DataSource = itemList;
        ddlCategory.DataTextField = "Name";
        ddlCategory.DataValueField = "CategoryID";
        ddlCategory.DataBind();
    

    }
    protected void lbtnNew_Click(object sender, EventArgs e)
    {

        Response.Redirect("ProductModify.aspx", true);
    }

    void BindList(string sortParameter)
    {
        List<Product> itemList = new List<Product>();
        if (CategoryID == 0)
        {
            itemList = Product.GetProduct(sortParameter);
        }
        else
        {
            List<Product> tmpList = Product.GetProduct(sortParameter);
            foreach (Product p in tmpList)
            {
                if (p.CategoryID == CategoryID)
                {
                    itemList.Add(p);
                }
            }

        }
        lblRowCount.Text = itemList.Count.ToString();
        GridView1.DataSource = itemList;
        GridView1.DataBind();

        ddlCategory.SelectedValue = CategoryID.ToString();
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
                linkView.NavigateUrl = string.Format("ProductDetail.aspx?ID={0}", intDatalID);
            }

            HyperLink linkModify = (HyperLink)e.Row.FindControl("linkModify");
            if (linkModify != null)
            {
                linkModify.Text = "編輯";
                linkModify.NavigateUrl = string.Format("ProductModify.aspx?ID={0}&back=ProductList.aspx", intDatalID);

            }
            HyperLink linkColor = (HyperLink)e.Row.FindControl("linkColor");
            if (linkColor != null)
            {
                linkColor.Text = "顏色";
                linkColor.NavigateUrl = string.Format("ProductColor.aspx?ID={0}&back=ProductList.aspx", intDatalID);

            }
            

            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            if (lbtnDelete != null)
            {
                lbtnDelete.Attributes.Add("onclick", "return chkConfirmDelete()");
            }
        }
        if (ddlCategory.SelectedIndex == 0)
        {
            ImageButton ibtnUP = (ImageButton)e.Row.FindControl("ibtnUP");
            if (ibtnUP!=null)
            {
                ibtnUP.Enabled = false;
                ibtnUP.ToolTip = "排序前請先選擇商品分類。";
            }

            ImageButton ibtnDOWN = (ImageButton)e.Row.FindControl("ibtnDOWN");
            if (ibtnDOWN != null)
            {
                ibtnDOWN.Enabled = false;
                ibtnDOWN.ToolTip = "排序前請先選擇商品分類。";
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
        List<Product> dataList;
        int targetIndex = -1;
        switch (e.CommandName)
        {
            case "Delete":
                RowID = Convert.ToInt32(e.CommandArgument);
                Product.Remove(RowID);
                break;
            case "SortUp":
                if (ddlCategory.SelectedIndex > 0)
                {
                    RowID = Convert.ToInt32(e.CommandArgument);
                    dataList = Product.GetProduct("SortID");


                    foreach (Product c in dataList)
                    {
                        int nowIndex = dataList.IndexOf(c);
                        if (c.ProductID == RowID)
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
                }
                break;
            case "SortDown":
                if (ddlCategory.SelectedIndex > 0)
                {
                    RowID = Convert.ToInt32(e.CommandArgument);
                    dataList = Product.GetProduct("SortID");


                    foreach (Product c in dataList)
                    {
                        int nowIndex = dataList.IndexOf(c);
                        if (c.ProductID == RowID)
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
                }
                break;
        }

    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindList(SortParameter);
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
        BindList(SortParameter);
    }
}
