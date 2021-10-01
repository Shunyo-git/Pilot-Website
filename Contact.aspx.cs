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
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

public partial class contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtnSubmit.Attributes.Add("onMouseOut", "MM_swapImgRestore()");
        ibtnSubmit.Attributes.Add("onMouseOver", string.Format("MM_swapImage('{0}','','img/contact/send2.gif',1)", ibtnSubmit.UniqueID));

    }
    protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
    {

        if (Page.IsValid)
        {
            Message msg = new Message();
            msg.MsgID = 0;
            msg.Name = txtName.Value;
            msg.Gender = rbtnGender.SelectedValue;
            msg.Email = Email.Value;
            msg.Contact = rbtnContact.SelectedValue;
            msg.Birthday = string.Format("{0}/{1}/{2}", txtYear.Value, txtMonth.Value,txtDay.Value);
            msg.Content = txtContent.Value;
            msg.Telephone = Teltphone.Value;
            msg.Mobile = Mobile.Value;
            msg.IP = WebUtility.GetUserTrueIP();

            if (msg.Save())
            {
                sendEmail(msg.MsgID);
                ResponseClientScript("SaveSuccess", "alert('謝謝您，您的來信已被紀錄，我們將會儘快回覆您。');location.href='Contact.aspx';");
            }
            else
            {
                ResponseClientScript("SaveSuccess", "alert('很抱歉，系統發生問題無法處理您的來信，請您稍後在試。'); ");
            }
        }
    }

    public void ResponseClientScript(string ScriptKey, string Msg)
    {
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();

        if (!cs.IsStartupScriptRegistered(cstype, ScriptKey))
        {
            cs.RegisterStartupScript(cstype, ScriptKey, Msg, true);
        }
    }

    private bool sendEmail(int MsgID)
    {
        String ScriptKey = "sendPassword Message";
        Boolean blnResult = false;

        string subject = ConfigurationManager.AppSettings["ContactMail_Subject"] + "(郵件編號：" + MsgID.ToString() + ")";
        string mailto = ConfigurationManager.AppSettings["ContactMailTo"];
        string ccMailto = ConfigurationManager.AppSettings["ContactMail_CCTo"];


        string FileName = Server.MapPath("/ContactMail.txt");
        StreamReader reader = new StreamReader(FileName, System.Text.Encoding.Default);
        string body = reader.ReadToEnd();
        reader.Close();

        body = string.Format(body, 
            MsgID, 
            txtName.Value, 
            rbtnGender.SelectedValue, 
            string.Format("{0}/{1}/{2}", txtYear.Value, txtMonth.Value,txtDay.Value),
            Email.Value,
            Teltphone.Value,
            Mobile.Value,
            rbtnContact.SelectedValue,
            txtContent.Value, 
            WebUtility.GetUserTrueIP(),
            DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());

        try
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("service@pilot-pen.com.tw");
            if (mailto.Length > 0 || mailto != string.Empty)
            {
                string[] strTO = mailto.Split(new Char[] { ';', ',' });
                foreach (string strThisTO in strTO)
                {
                    mail.To.Add(new MailAddress(strThisTO));
                }
            }
            if (ccMailto.Length > 0 || ccMailto != string.Empty)
            {
                string[] strCC = ccMailto.Split(new Char[] { ';', ',' });
                foreach (string strThisCC in strCC)
                {
                    mail.CC.Add(new MailAddress(strThisCC));
                }
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = false;
            mail.Priority = MailPriority.High;
            SmtpClient smtp= new SmtpClient();
            smtp.Send(mail);

            blnResult = true;
        }
        catch (FormatException e)
        {
            ResponseClientScript(ScriptKey, "alert(\"Format Exception: " + e.Message + "\");");

        }
        catch (SmtpException e)
        {
            ResponseClientScript(ScriptKey, "alert(\"SmtpException Exception: " + e.Message + "\");");
        }
        catch (Exception e)
        {
            ResponseClientScript(ScriptKey, "alert(\"Exception: " + e.Message + "\");");
        }

        return blnResult;
    }
   
}
