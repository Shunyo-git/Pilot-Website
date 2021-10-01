<%@ WebHandler Language="C#" Class="EmailHandler" %>

using System;
using System.Web;

public class EmailHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ClearContent(); 
        context.Response.ContentType = "text/plain";

        context.Response.AddHeader("Content-Disposition", "attachment; filename=Email.txt");
        
        context.Response.WriteFile(context.Server.MapPath("/Upload/Email.txt"), true);
        
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}