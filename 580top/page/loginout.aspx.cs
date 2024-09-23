using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class page_loginout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Cookie ccookie = new Cookie();
            ccookie.delCookie("username");
            ccookie.delCookie("password");
       
            Response.Write("<div  style=\"font-size:12px; \">退出成功！ <br /></a>");
        }
        catch
        {
            Response.Write("<div  style=\"font-size:12px; \">退出error！ <br /></a>");
        }
      //  Response.Write("<div style=\"margin-left:50px;\"><a href=\"#\" onClick=\"parent.location.reload()\"><span style=\"font-size:12px; \">点击此处返回</span></a><div></div>");
         
    }
}
