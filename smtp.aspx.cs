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
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

public partial class smtp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string subject = ConfigurationManager.AppSettings["ContactMail_Subject"] ;
        string mailto = ConfigurationManager.AppSettings["ContactMailTo"];
        string ccMailto = ConfigurationManager.AppSettings["ContactMail_CCTo"];

        string FileName = Server.MapPath("/ContactMail.txt");
        StreamReader reader = new StreamReader(FileName, System.Text.Encoding.Default);
        string body = reader.ReadToEnd();
        reader.Close();

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
        mail.Body = body ;
        mail.IsBodyHtml = false;
        mail.Priority = MailPriority.High;
        SmtpClient smtp = new SmtpClient();
        smtp.Send(mail);
    }
}
