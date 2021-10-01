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

public partial class Template01 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtnSearch.Attributes.Add("onmouseout", "MM_swapImgRestore()");
        ibtnSearch.Attributes.Add("onmouseover", "MM_swapImage('" + ibtnSearch .ClientID + "','','img/frame/top_arrow2.gif',1)");
    }
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(string.Format("/SearchResult.aspx?Keyword={0}", txtkeyword.Value), true);
    }
}
