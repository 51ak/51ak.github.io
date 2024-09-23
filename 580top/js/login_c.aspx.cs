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

public partial class js_login:zt
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string innerhtml = "";
        bool isuser = false;
        bool iscookie = false;
        HttpCookie cookie = Request.Cookies["cdboccookie"];

        int userid = 0;
        string cookiename = "";
        if (cookie != null)
        {
            
            if (cookie["username"] != null && cookie["password"] != null)
            {
               
                string username = cookie["username"].ToString();
                string password = cookie["password"].ToString();
                if (username.Length > 4 && password.Length > 10)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "loginmain";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter ccc = new SqlParameter("@username", SqlDbType.VarChar, 50);
                    ccc.Value = username;
                    cmd.Parameters.Add(ccc);
                    ccc = new SqlParameter("@password", SqlDbType.VarChar, 50);
                    ccc.Value = password;
                    cmd.Parameters.Add(ccc);

                    DataTable dt = GetDataTable(cmd);
                    if (dt.Rows.Count == 1)
                    {
                        innerhtml += "用户:" + username.ToString() + "<br />";
                        innerhtml += "密码:" + password.ToString() + "<br />";
                        isuser = true;
                    }              
                   
                }                
            }


            if (cookie["gid"] != null)
            {
                cookiename = cookie["gid"].ToString();                         
            }        

        }
        if (cookiename.Length <30)
        {
            //生成随机COOKIE
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            int iResult = ran.Next(100000);
            cookiename = to_md5(to_md5(DateTime.Now.ToString(), 16) + iResult.ToString(), 32);
        }     



        /*
                  * @userid int,
     @ip varchar(50),
     @url varchar(500),
     @cookiename varchar(50),
     @ie varchar(50),
     @pix varchar(50),
     @newsid int,
     @cataid int
         * 
                  */
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandText = "login_guest";
        cmd1.CommandType = CommandType.StoredProcedure;
        SqlParameter ccc1 = new SqlParameter("@userid", SqlDbType.Int);
        ccc1.Value = userid;
        cmd1.Parameters.Add(ccc1);
        ccc1 = new SqlParameter("@ip", SqlDbType.VarChar, 50);
        ccc1.Value = "ip";
        cmd1.Parameters.Add(ccc1);
        ccc1 = new SqlParameter("@url", SqlDbType.VarChar, 500);
        ccc1.Value = "url";
        cmd1.Parameters.Add(ccc1);
        ccc1 = new SqlParameter("@cookiename", SqlDbType.VarChar, 50);
        ccc1.Value = cookiename;
        cmd1.Parameters.Add(ccc1);
        ccc1 = new SqlParameter("@ie", SqlDbType.VarChar, 50);
        ccc1.Value = "ie";
        cmd1.Parameters.Add(ccc1);
        ccc1 = new SqlParameter("@pix", SqlDbType.VarChar, 50);
        ccc1.Value = "pix";
        cmd1.Parameters.Add(ccc1);
        ccc1 = new SqlParameter("@newsid", SqlDbType.Int);
        ccc1.Value = 1;
        cmd1.Parameters.Add(ccc1);
        ccc1 = new SqlParameter("@cataid", SqlDbType.Int);
        ccc1.Value = 1;
        cmd1.Parameters.Add(ccc1);
        string k1= exesql(cmd1);
        innerhtml = k1 + cookiename;




        string htmstr = "";
        htmstr += "document.getElementById('div_login').innerHTML = '<font color=red>" + innerhtml + "</font>';";

        Response.Write(htmstr);
    }

    protected void addcookie(string cookiekey, string cookievalue)
    {
        HttpCookie cookie = new HttpCookie("cdboccookie");
        cookie.Values.Add(cookiekey, cookievalue);
        cookie.Expires = DateTime.Now.AddMonths(1);
        Response.Cookies.Add(cookie);

    }
    protected void addcookie(HttpCookie cookie, string cookiekey, string cookievalue)
    {
        if (cookie[cookiekey] != null)
        {
            cookie[cookiekey] = "222222222222";
        }
        else
        {
            cookie.Values.Add(cookiekey, cookievalue);
            //  Response.Cookies.Add(cookie);
        }
        Response.Cookies.Add(cookie);

    }
}
