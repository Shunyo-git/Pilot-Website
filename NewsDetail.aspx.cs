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
using System.Collections.Generic;
using Pilot.BusinessLogicLayer;
using System.Text;
using Pilot.Web;
public partial class NewsDetail : System.Web.UI.Page
{


    private int _CurrentID = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        GetCurrentData();
        linkReturn.Attributes.Add("onmouseout", "MM_swapImgRestore()");
        linkReturn.Attributes.Add("onmouseover", "MM_swapImage('Image19','','img/frame/back2.gif',1)");
        linkReturn.NavigateUrl = "NewsList.aspx";
        if (!Page.IsPostBack)
        {

            BindData();

        }
       
       
    }

    private void BindData()
    {
        News news = News.GetNews(_CurrentID, true);
        if(news!=null){
            lblCaption.Text = news.Caption;
            lblForeword.Text = news.Foreword;
            lblCreationDate.Text= news.NewsDate ;
            TableImage.Visible = news.IsDisplayImage;
            NewsImage.Src = string.Format("Upload/News/{0}.jpg",news.ID);
            lblContent.Text = StringHelper.NewLineToBreak(Pilot.Web.StringHelper.SpaceToNbsp(news.Content));
            PanelHotNewsTitle.Visible = news.IsHotNews;
            PanelHistoryNewsTitle.Visible = !(news.IsHotNews);
            if(!news.IsHotNews){
            	linkReturn.NavigateUrl = "NewsList.aspx?HotNews=n";
            }
        }
    }


    void GetCurrentData()
    {


        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _CurrentID))
        {
            _CurrentID = Convert.ToInt32(Request.QueryString["ID"]);

        }


    }
}
