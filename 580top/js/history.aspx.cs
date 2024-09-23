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

public partial class js_history : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string htmstr = "";
        htmstr += "document.getElementById('div3_l1').innerHTML = '这是浏览历史';";
        htmstr += "document.getElementById('div3_l2').innerHTML = '这是下载历史';";
        Response.Write(htmstr);
    }
}
