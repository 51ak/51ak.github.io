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

public partial class history :zt
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string content;
        if (Request["id"] != null)
        {

            int id = c_int(Request["id"]);
            content = get_history_byid(id);
        }
        else
        {
            content = "";
        }
        int d = DateTime.Now.Day;
        int m = DateTime.Now.Month;
        string history = bind_history(m, d);
        this.lt_content.Text = " <div>" + content + history + "</div>";
    }


   

}
