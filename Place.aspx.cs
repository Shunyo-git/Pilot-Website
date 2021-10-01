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

public partial class Place : System.Web.UI.Page
{
    private int _AreaID = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRequestData();
        if (!Page.IsPostBack)
        {
            BindDataList();

        }
    }
    void GetRequestData()
    {


        if (Request.QueryString["AreaID"] != null && Int32.TryParse((string)Request.QueryString["AreaID"], out _AreaID))
        {
            _AreaID = Convert.ToInt32(Request.QueryString["AreaID"]);

        }


    }

    private void BindDataList()
    {

        GridView1.DataSource = Store.GetDisplayStoreByArea(_AreaID);
        GridView1.DataBind();

        imgArea.Src = string.Format("img/place/title_place{0}.jpg", _AreaID);
    }
    
    public string DisplayStore(string storeName, string url)
    {
    	string ret = storeName ;
    	if(!string.IsNullOrEmpty(url)){
    		ret = string.Format("<a href=\"{0}\" target=\"_blank\" style=\"color: #30647E;\" >{1}</a>",url,storeName);
    	}
    	return ret;
    }
}
