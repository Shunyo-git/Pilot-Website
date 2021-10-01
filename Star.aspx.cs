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
 
public partial class Star : System.Web.UI.Page
{
    private int _CurrentID = 1;
    private PilotStar CurrentStar;
    protected void Page_Load(object sender, EventArgs e)
    {

        GetCurrentData();

        if (!Page.IsPostBack)
        {
            BindData();

        }
        hlinkMore.Attributes.Add("onmouseout", "MM_swapImgRestore()");
        hlinkMore.Attributes.Add("onmouseover", "MM_swapImage('Image18','','img/product/more2.gif',1)");
    }

    void GetCurrentData()
    {


        if (Request.QueryString["ID"] != null  )
        {
            Int32.TryParse((string)Request.QueryString["ID"], out _CurrentID);

        }
        CurrentStar = PilotStar.GetPilotStarById(_CurrentID);

    }
    void BindData() {
        if (CurrentStar!=null) {
            lblCaprion.Text = CurrentStar.Caption;
            imgPilotStar.Src = string.Format("/Upload/Star/{0}.jpg", _CurrentID);
            hlinkMore.NavigateUrl = CurrentStar.Url;
        }
    }
}
