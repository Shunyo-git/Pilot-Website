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

public partial class Manager_NewsModify : System.Web.UI.Page
{
    private News CurrentObject = null;
    private int _CurrentID = 0;
    private string _backto = "NewsList.aspx";


    string _LogoUploadPath = "/Upload/News/";
    string _BackupPath = ConfigurationManager.AppSettings["UploadBackupPath"] + "/images/News/{0}/";
   
    void GetCurrentData()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _CurrentID))
        {
            CurrentObject = News.GetNews(_CurrentID);

        }
        if (Request.QueryString["back"] != null)
        {
            _backto = (string)Request.QueryString["back"];
            _backto += "?ID=";
            _backto += (string)Request.QueryString["ID"];
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {


        GetCurrentData();

        if (!Page.IsPostBack)
        {
            BindData();
        }

    }

    private void BindData()
    {
        if (CurrentObject != null)
        {
            lblID.Text = Convert.ToString(CurrentObject.ID);

            rbtnIsHotNews.SelectedValue = CurrentObject.IsHotNews.ToString();
            rbtnIsApproved.SelectedValue = CurrentObject.IsApproved.ToString();
            rbtnIsDisplayImage.SelectedValue = CurrentObject.IsDisplayImage.ToString();
            rbtnIsMainPageDisplay.SelectedValue = CurrentObject.IsMainPageDisplay.ToString();
            txtTitle.Text = CurrentObject.Caption;

            txtContent.Text = CurrentObject.Content;
            txtForeword.Text = CurrentObject.Foreword;


            imgLogo.ImageUrl = string.Format("/Upload/News/{0}.jpg", CurrentObject.ProductID);
        }
        else
        {
            imgLogo.Visible = false;

        }

        
    }

  


    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        bool blnResult = false;


        if (Page.IsValid)
        {

            if (CurrentObject == null)
            {
                CurrentObject = new News();
                 
            }

            CurrentObject.ID = _CurrentID;
            CurrentObject.Caption = txtTitle.Text;
            CurrentObject.IsHotNews = Convert.ToBoolean(rbtnIsHotNews.SelectedValue);
            CurrentObject.IsApproved = Convert.ToBoolean(rbtnIsApproved.SelectedValue);
            CurrentObject.IsMainPageDisplay = Convert.ToBoolean(rbtnIsMainPageDisplay.SelectedValue);
            CurrentObject.IsDisplayImage = Convert.ToBoolean(rbtnIsDisplayImage.SelectedValue);
            CurrentObject.Content = txtContent.Text;
            CurrentObject.Foreword = txtForeword.Text;

            blnResult = CurrentObject.Save();

            if (blnResult)
            {
                blnResult = UploadFile(UploadControl1, _LogoUploadPath, "{0}.jpg", CurrentObject.ID);

            }
            
        }


        if (!blnResult)
        {
            //ValidatorResult.Text = "儲存失敗，請檢查您的資料後重新再試一次。";
            ValidatorResult.IsValid = false;
            Response.Write("There was an error.  Please fix it and try it again.");
        }
        else
        {
            Response.Redirect(_backto);
        }
    }

    private bool UploadFile(UploadControl UC, string UploadPath, string FileNamePatten, int ImgID)
    {
        //First We Check if the page is valid or if we need to flag up an error message
        if (Page.IsValid)
        {
            //Second we need to check if the user has browsed for a file
            if (UC.GotFile)
            {
                //We can safely upload the file here because it has passed all validation.
                //Remeber to add the fullstop before the FileExt variable as it comes without.
                string FileName = string.Format(FileNamePatten, ImgID);
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

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(_backto);
    }
}
