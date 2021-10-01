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
public partial class Manager_ProductColor : System.Web.UI.Page
{
    private Product CurrentObject = null;
    private int _CurrentID
    {
        set { ViewState["ProductID"] = value; }
        get
        {
            if (ViewState["ProductID"] == null)
                return 0;

            return (int)ViewState["ProductID"];

        }
    }
    string _ImageUploadPath = "/Upload/Product/";
    string _BackupPath = ConfigurationManager.AppSettings["UploadBackupPath"] + "/images/Product/{0}/";


    void GetCurrentData()
    {
        int PID = 0;
        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out PID))
        {
            _CurrentID = PID;
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
        ddlColor.DataSource = Color.GetColor("ColorID");
        ddlColor.DataTextField = "FullName";
        ddlColor.DataValueField = "ColorID";
        ddlColor.DataBind();
        if (CurrentObject != null)
        {
            lblID.Text = Convert.ToString(CurrentObject.ProductID);
            lblName.Text = CurrentObject.Name;
            lblCategory.Text = Category.GetCategoryById(CurrentObject.CategoryID).Name;

            List<Color> colors = Color.GetColorByProduct(CurrentObject.ProductID);

            GridView1.DataSource = colors;
            GridView1.DataBind();

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

    public string GetProductColorImage(string ColorColor)
    {

        string strImg = "<img src=\"/Upload/Product/{0}-{1}.jpg\" />";
        return string.Format(strImg, _CurrentID, ColorColor);
    }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int intDatalID = (int)GridView1.DataKeys[e.Row.RowIndex].Value;

            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            if (lbtnDelete != null)
            {
                lbtnDelete.Attributes.Add("onclick", "return chkConfirmDelete()");
            }
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int RowID = 0;

        switch (e.CommandName)
        {
            case "Delete":
                RowID = Convert.ToInt32(e.CommandArgument);
                Color SelectColor = Color.GetColor(RowID);

                if (Product.RemoveProductColor(_CurrentID, RowID)) {
                    string FileName = string.Format("{0}-{1}.jpg", _CurrentID, SelectColor.ColorCode);
                    string FullFileName = Server.MapPath(_ImageUploadPath + FileName);
                    if (File.Exists(FullFileName))
                    {
                        File.Delete(FullFileName);
                    }
                }
                break;

        }

    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindData();
    }

    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            Color SelectColor = Color.GetColor(Convert.ToInt32(ddlColor.SelectedValue));
            if (SelectColor != null)
            {
                bool Recult = UploadFile(UploadControl1, _ImageUploadPath, "{0}-{1}.jpg", CurrentObject.ProductID, SelectColor.ColorCode);
                if (Recult)
                {
                    List<Color> colors = Color.GetColorByProduct(CurrentObject.ProductID);
                    bool IsNew = true;
                    foreach (Color c in colors)
                    {
                        if (c.ColorID == SelectColor.ColorID)
                        {
                            IsNew = false;
                            break;
                        }

                    }
                    if (IsNew)
                    {
                        Product.AddProductColor(CurrentObject.ProductID, SelectColor.ColorID);
                    }
                    BindData();
                }
             
            }
        }
    }

    private bool UploadFile(UploadControl UC, string UploadPath, string FileNamePatten, int ImgID, string ColorCode)
    {
        //First We Check if the page is valid or if we need to flag up an error message
        if (Page.IsValid)
        {
            //Second we need to check if the user has browsed for a file
            if (UC.GotFile)
            {
                //We can safely upload the file here because it has passed all validation.
                //Remeber to add the fullstop before the FileExt variable as it comes without.
                string FileName = string.Format(FileNamePatten, ImgID, ColorCode);
                string FullFileName = Server.MapPath(UploadPath + FileName);
                string BackupPath = Server.MapPath(string.Format(_BackupPath, DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")));
                if (File.Exists(FullFileName))
                {
                    if (!Directory.Exists(BackupPath)) { Directory.CreateDirectory(BackupPath); }
                    File.Move(FullFileName, BackupPath + FileName);
                }

                UC.FilePost.SaveAs(FullFileName);

            }
            return true;
        }
        else
        {
            return false;
        }

    }
}
