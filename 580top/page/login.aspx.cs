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

public partial class page_login : zt
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            plview(wkf_login());
        
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string username = this.username.Text;
        string password = to_md5(this.password.Text,32);
        bool isuser = wkf_login(username, password);
        plview(isuser);        
    }
    protected void plview(bool tmp)
    {
        if (tmp)
        {
            pl_login.Visible = false;
            pl_my.Visible = true;
            if (Session["jifen"] != null && Session["username"] != null)
            {
                this.lb_jifen.Text = Session["jifen"].ToString();
                this.lb_username.Text = Session["username"].ToString();
            }
        }
        else
        {
            pl_login.Visible = true;
            pl_my.Visible = false;
        }

    }
}
