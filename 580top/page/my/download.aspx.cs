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

public partial class page_my_download : zt
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!wkf_login())
        {
            Response.Write("只有<a href=\"../login.aspx\">登陆</a>用户才可以访问此页面,<a href=\"javascript:history.go(-1)\">返回</a>");
            Response.End();
        
        }
    }
}
