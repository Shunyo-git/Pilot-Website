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
 
public partial class JoinForm : System.Web.UI.Page
{
    DropDownList selYear;
    DropDownList selMonth;
    DropDownList selDay;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadTemplateControls();
        if (!Page.IsPostBack)
        {
            BindOption();
           
        }
    }

    private void LoadTemplateControls()
    {
        selYear = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("selYear");
        selMonth = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("selMonth");
        selDay = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("selDay");
         
    }
    void BindOption()
    {

        DropDownList ddlEducation = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ddlEducation");

        if (ddlEducation!=null)
        {
            ddlEducation.DataSource = Education.GetEducation();
            ddlEducation.DataTextField = "Caption";
            ddlEducation.DataValueField = "Caption";
            ddlEducation.DataBind();
        }

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


        if (selYear != null)
        {
            if (selMonth.Items.Count <= 0)
            {
                for (int i = 1; i <= 12; i++)
                {
                    selMonth.Items.Add(i.ToString());
                }
            }
        }


        if (selYear != null)
        {
            if (selDay.Items.Count <= 0)
            {
                for (int i = 1; i <= 31; i++)
                {
                    selDay.Items.Add(i.ToString());
                }
            }

        }

        selYear.SelectedValue = "1980";
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {

        if (SaveProfile())
        {
            //Response.Redirect("MemberRegisterSuccess.aspx");
        }
        else
        {
            string UserName = GetTextBoxControlValue("UserName");
            Membership.DeleteUser(UserName);
            CreateUserWizard1.ActiveStepIndex = 1;
        }
    }

    private bool SaveProfile()
    {

        //this.OrigenalUserName = OrigenalUserName;
        //this.OrigenalPassword = OrigenalPassword;
        //this.ChineseName = ChineseName;
        //this.Email = Email;
        //this.Gender = Gender;
        //this.YearofBirth = YearofBirth;
        //this.MonthofBirth = MonthofBirth;
        //this.DayofBirth = DayofBirth;
        //this.AgeLevel = AgeLevel;
        //this.Eduction = Eduction;
        //this.Telephone = Telephone;
        //this.MobilePhone = MobilePhone;
        //this.Address = Address;
        //this.ActivityWish = ActivityWish;
        //this.OtherWish = OtherWish;
        //this.RegisterIP = RegisterIP;

        string tmpOrigenalUserName = string.Empty;
        string tmpOrigenalPassword = string.Empty;
        string tmpChineseName = string.Empty;
        string tmpEmail = string.Empty;
        GenderType tmpGender = GenderType.unknown;
        int tmpYearofBirth = 0;
        int tmpMonthofBirth = 0;
        int tmpDayofBirth = 0;
        string tmpAgeLevel = string.Empty;
        string tmpEducation = string.Empty;
        string tmpTelephone = string.Empty;
        string tmpMobilePhone = string.Empty;
        string tmpAddress = string.Empty;
        string tmpActivityWish = string.Empty;
        string tmpOtherWish = string.Empty;
        string tmpRegisterIP = string.Empty;

        DateTime Birthday;

        tmpChineseName = GetTextBoxControlValue("txtChineseName");
        tmpEmail = GetTextBoxControlValue("Email");
        
        RadioButtonList rbtnGender = (RadioButtonList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("rbtnGender");
        if (rbtnGender.SelectedValue == "male")
        {
            tmpGender = GenderType.male;
        }
        if (rbtnGender.SelectedValue == "female")
        {
            tmpGender = GenderType.female;
        }

        if (selYear == null || selMonth == null || selDay == null) { LoadTemplateControls(); }
        if (!DateTime.TryParse(selYear.SelectedValue + "/" + selMonth.SelectedValue + "/" + selDay.SelectedValue, out Birthday))
        {
            Birthday = DateTime.MinValue;
        }

        tmpYearofBirth = Birthday.Year;
        tmpMonthofBirth = Birthday.Month;
        tmpDayofBirth = Birthday.Day;

        tmpEducation = GetDropDownListControlValue("ddlEducation");
        tmpTelephone = GetTextBoxControlValue("txtTelphone");
        tmpAddress = Request.Form["zip_code0"] + Request.Form["district0"] + Request.Form["city"] + GetTextBoxControlValue("txtAddress");
        tmpActivityWish = GetRadioButtonListControlValue("rbtnWish");
        tmpOtherWish = GetTextBoxControlValue("txtOtherWish");
        tmpRegisterIP = Pilot.Web.WebUtility.GetUserTrueIP();

        string UserName = GetTextBoxControlValue("UserName");

        if (!string.IsNullOrEmpty(UserName))
        {
            ProfileCommon p = Profile.GetProfile(UserName);

            if (p != null)
            {
                p.MemberInfo = new MemberInfo(tmpChineseName, tmpEmail, tmpGender, tmpYearofBirth, tmpMonthofBirth, tmpDayofBirth, tmpAgeLevel, tmpEducation, tmpTelephone, tmpMobilePhone, tmpAddress, tmpActivityWish,tmpOtherWish, tmpRegisterIP);
                p.Save();
                return true;
            }

        }
        return false;

    }

    private string GetTextBoxControlValue(string ControlID)
    {
        TextBox obj = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl(ControlID);
        if (obj != null) { return obj.Text; } else { return string.Empty; }
    }

    private string GetRadioButtonListControlValue(string ControlID)
    {
        RadioButtonList obj = (RadioButtonList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl(ControlID);
        if (obj != null) { return obj.SelectedValue; } else { return string.Empty; }
    }
    private string GetDropDownListControlValue(string ControlID)
    {
        DropDownList obj = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl(ControlID);
        if (obj != null) { return obj.SelectedValue; } else { return string.Empty; }
    }
   //(System.Web.UI.WebControls.DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("selYear");
}
