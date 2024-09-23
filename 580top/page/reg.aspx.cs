using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ajaxpr02;

public partial class page_reg : zt
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bool tmp = chkcookie();
        }


    }
    protected bool chkcookie()
    {
        Cookie cCookie = new Cookie();
        string username = cCookie.getCookie("username");
        string password = cCookie.getCookie("password");
        if (wkf_login(username, password))
        {
            this.lb_msg.Text = "您已经注册过会员了，不需要重复注册<br />用户名：" + username + "<br /><div class=\"zc_margin10\" style=\"margin-left:50px;\"><a href=\"#\" onClick=\"parent.location.reload()\">点击此处返回</a><div>"; 
            this.pl_reg_main.Visible = false;
            return true;
        }
        return false;
    }

    protected void btn_reg_Click(object sender, EventArgs e)
    {
        if (chkcookie())
        {
            return;
        }
        string username = this.txt_username.Text.Trim();
        string cpassword = this.txt_password.Text.Trim();
        pwd_ pc = new pwd_("wkfwww21", "WokoFO2E");
        
       string  pwd_cpassword = pc.Encode(cpassword); 

        string email = this.txt_email.Text.Trim();
        if (username.Length < 2 || cpassword.Length < 2 || email.Length < 4)
        {
            this.lb_msg.Text = "注册会员失败，请检查您输入的资料(错误代码:100001)";
            return;
        }
        Cookie cCookie = new Cookie();
        string cookiename = cCookie.getCookie("gid");
        string password = to_md5(cpassword, 32);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "wkf_add_user";
        SqlParameter ccc = new SqlParameter("@username", SqlDbType.VarChar, 50);
        ccc.Value = username;
        cmd.Parameters.Add(ccc);
        ccc = new SqlParameter("@password", SqlDbType.VarChar, 50);
        ccc.Value = password;
        cmd.Parameters.Add(ccc);
        ccc = new SqlParameter("@cpassword", SqlDbType.VarChar, 50);

        ccc.Value = pwd_cpassword;
        cmd.Parameters.Add(ccc);
        ccc = new SqlParameter("@email", SqlDbType.VarChar, 255);
        ccc.Value = email;
        cmd.Parameters.Add(ccc);
        ccc = new SqlParameter("@cookiename", SqlDbType.VarChar, 50);
        ccc.Value = cookiename;
        cmd.Parameters.Add(ccc);
        ccc = new SqlParameter("@retun", SqlDbType.Int);
        ccc.Direction = ParameterDirection.ReturnValue;
        ccc.Value = 0;
        cmd.Parameters.Add(ccc);
       
        string k = exesql(cmd);
        if (k == "成功")
        {
            int r_int = c_int(ccc.Value.ToString());
            if (r_int > 0)
            {
                Session["uid"] = r_int;
                Session["username"] = username;
                Session["password"] = password;
                cCookie.setCookie("username", username);
                cCookie.setCookie("password", password);
                this.lb_msg.Text = "<div class=\"zc_s2\">恭喜！注册会员成功！</div>用户名：" + username + "<br/>登录密码：" + cpassword + "<br /><div class=\"zc_margin10\" style=\"margin-left:50px;\"><a href=\"#\" onClick=\"parent.location.reload()\">点击此处返回</a><div>";
                this.pl_reg_main.Visible = false;
                this.txt_username.Text = "";
                this.txt_password.Text = "";
                this.txt_email.Text="";
                this.txt_cpassword.Text = "";
            }
            else
            {
                this.txt_username.BorderColor = System.Drawing.Color.Salmon;
                this.lb_msg.Text = "<font color=\"red\">注册会员失败，重复的会员名(请选择其他的用户名)！</font>";
            }
        }
        else
        {
            this.lb_msg.Text = "注册会员失败，不正确的资料(错误代码:100002)"+k;
        }
    }
}
