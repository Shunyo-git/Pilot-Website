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

public partial class ModifyMember : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            ibtnSave.Attributes.Add( "onmouseout","MM_swapImgRestore()");
            ibtnSave.Attributes.Add("onmouseover", "MM_swapImage('" + ibtnSave.ClientID + "','','img/join/send2.gif',1)");
            if (!Page.IsPostBack)
            {
                BindOption();
                BindData();

            }
        }

    }
    void BindOption()
    {

       
            ddlEducation.DataSource = Education.GetEducation();
            ddlEducation.DataTextField = "Caption";
            ddlEducation.DataValueField = "Caption";
            ddlEducation.DataBind();
       

        if (selYear != null)
        {
            if (selYear.Items.Count <= 0)
            {
                for (int i = 1900; i <= DateTime.Now.Year; i++)
                {
                    selYear.Items.Add(i.ToString());
                }
            }
        }


        if (selMonth != null)
        {
            if (selMonth.Items.Count <= 0)
            {
                for (int i = 1; i <= 12; i++)
                {
                    selMonth.Items.Add(i.ToString());
                }
            }
        }


        if (selDay != null)
        {
            if (selDay.Items.Count <= 0)
            {
                for (int i = 1; i <= 31; i++)
                {
                    selDay.Items.Add(i.ToString());
                }
            }

        }

     
    }

    void BindData()
    {
        string UserName = Page.User.Identity.Name;
        lblUserName.Text = UserName;
        MembershipUser thisUser = Membership.GetUser(UserName);

        if (thisUser != null)
        {
            ProfileCommon thisProfile = Profile.GetProfile(UserName);
            if (thisProfile != null)
            {
                Email.Text = thisUser.Email;
                
                if (thisProfile.MemberInfo != null)
                {
                    txtChineseName.Text = thisProfile.MemberInfo.ChineseName;
                    rbtnGender.SelectedValue = thisProfile.MemberInfo.Gender.ToString().ToLower();
                    selYear.SelectedValue = thisProfile.MemberInfo.YearofBirth.ToString();
                    selMonth.SelectedValue = thisProfile.MemberInfo.MonthofBirth.ToString();
                    selDay.SelectedValue = thisProfile.MemberInfo.DayofBirth.ToString();
                    ddlEducation.SelectedValue = thisProfile.MemberInfo.Education;
                    txtTelphone.Text = thisProfile.MemberInfo.Telephone;
                    txtAddress.Text = thisProfile.MemberInfo.Address;
                    rbtnWish.SelectedValue = thisProfile.MemberInfo.ActivityWish;
                    txtOtherWish.Text = thisProfile.MemberInfo.OtherWish;
                }
            }
        }

    }

    

    private bool SaveProfile()
    {
        string UserName = Page.User.Identity.Name;

        if (!string.IsNullOrEmpty(UserName))
        {
            
            ProfileCommon p = Profile.GetProfile(UserName);

            if (p != null)
            {
                GenderType tmpGender = GenderType.unknown;

                if (rbtnGender.SelectedValue == "male")
                {
                    tmpGender = GenderType.male;
                }
                if (rbtnGender.SelectedValue == "female")
                {
                    tmpGender = GenderType.female;
                }

                DateTime Birthday;
                int tmpYearofBirth = 0;
                int tmpMonthofBirth = 0;
                int tmpDayofBirth = 0;
                if (!DateTime.TryParse(selYear.SelectedValue + "/" + selMonth.SelectedValue + "/" + selDay.SelectedValue, out Birthday))
                {
                    Birthday = DateTime.MinValue;
                }

                tmpYearofBirth = Birthday.Year;
                tmpMonthofBirth = Birthday.Month;
                tmpDayofBirth = Birthday.Day;

                string tmpAgeLevel = (p.MemberInfo == null) ? string.Empty : p.MemberInfo.AgeLevel;

                string tmpMobilePhone = (p.MemberInfo == null) ? string.Empty : p.MemberInfo.MobilePhone;  

                p.MemberInfo = new MemberInfo(txtChineseName.Text, Email.Text, tmpGender, tmpYearofBirth, tmpMonthofBirth, tmpDayofBirth, tmpAgeLevel, ddlEducation.SelectedValue, txtTelphone.Text,  tmpMobilePhone, txtAddress.Text, rbtnWish.SelectedValue, txtOtherWish.Text, Pilot.Web.WebUtility.GetUserTrueIP());
                p.Save();
                return true;
            }

        }
        return false;

    }

    //private string GetTextBoxControlValue(string ControlID)
    //{
    //    TextBox obj = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl(ControlID);
    //    if (obj != null) { return obj.Text; } else { return string.Empty; }
    //}

    //private string GetRadioButtonListControlValue(string ControlID)
    //{
    //    RadioButtonList obj = (RadioButtonList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl(ControlID);
    //    if (obj != null) { return obj.SelectedValue; } else { return string.Empty; }
    //}
    //private string GetDropDownListControlValue(string ControlID)
    //{
    //    DropDownList obj = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl(ControlID);
    //    if (obj != null) { return obj.SelectedValue; } else { return string.Empty; }
    //}
    //(System.Web.UI.WebControls.DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("selYear");
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (SaveProfile())
        {
            ErrorMessage.Text = "個人資料修改成功!  ";

        }
        else {
            ErrorMessage.Text = "個人資料修改發生錯誤!";
        }

        if (!string.IsNullOrEmpty(Password.Text))
        {
            string UserName = Page.User.Identity.Name;
            MembershipUser thisUser = Membership.GetUser(UserName);

            if (thisUser.ChangePassword(txtOldPassword.Text, Password.Text))
            {
                ErrorMessage.Text += "<BR />密碼修改成功!  ";
            }
            else {
                ErrorMessage.Text += "<BR />密碼修改失敗!  ";
            }
        }
    }
}
