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

public partial class Manager_ProductDetail : System.Web.UI.Page
{
    private Product CurrentObject = null;
    private int _CurrentID = 0;


    void GetCurrentData()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _CurrentID))
        {
            CurrentObject = Product.GetProductById(_CurrentID);
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
            lblID.Text = Convert.ToString(CurrentObject.ProductID);

            if (CurrentObject.IsDisplay)
            {
                lblIsDisplay.Text = "<img src='/Manager/image/icon_okay.png'> 顯示";
            }
            else
            {
                lblIsDisplay.Text = "<img src='/Manager/image/icon_no.png'> 不顯示";
            }
 

            lblName.Text = CurrentObject.Name;
            lblDescription.Text = Pilot.Web.StringHelper.NewLineToBreak( CurrentObject.Description);
            lblCategory.Text = Category.GetCategoryById(CurrentObject.CategoryID).Name;
            lblContent.Text = Pilot.Web.StringHelper.NewLineToBreak(CurrentObject.Spec);
            lblPrice.Text = CurrentObject.Price;
            imgLogo.ImageUrl = string.Format("/Upload/Product/{0}.jpg", CurrentObject.ProductID);
        }
    }



    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("ProductModify.aspx?ID={0}&&back=ProductDetail.aspx", _CurrentID));
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        Product.Remove(_CurrentID);
        Response.Redirect("ProductList.aspx");
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductList.aspx");
    }
}
