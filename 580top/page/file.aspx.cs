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

public partial class page_file : zt
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = c_int(Request["id"]);
        if (id < 1)
        {
            this.hy_title.Text = "错误的文件编号，无法下载此文件(代码:d_e012)";
            return;
        }
        if (wkf_login())
        {
            int jifen = c_int(Session["jifen"]);
            string username = c_string(Session["username"]);
            this.lb_jifen.Text = jifen.ToString();
            this.lb_kc.Text = "1";
            if (jifen > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "download_file";
                SqlParameter ccc = new SqlParameter("@id", SqlDbType.Int);
                ccc.Value = id;
                cmd.Parameters.Add(ccc);
                ccc = new SqlParameter("@username", SqlDbType.VarChar, 50);
                ccc.Value = username;
                cmd.Parameters.Add(ccc);
                DataTable dt = GetDataTable(cmd);
                if (dt.Rows.Count == 1)
                {
                    this.hy_title.Text = dt.Rows[0]["Title"].ToString() + dt.Rows[0]["filetype"].ToString() + "(" + dt.Rows[0]["filesize"].ToString() + ")";
                    this.hy_title.NavigateUrl = "/userfiles/" + dt.Rows[0]["downpath"].ToString();
                    refresh_user();
                }
                else
                {

                    this.hy_title.Text = "尊敬的用户" + username + "  您暂时无法下载此文件，原因是：<span class=\"zc_s1\">未找到用户文件</span>(代码:d_e004)";
      
                }
            }
            else
            {
                this.hy_title.Text = "尊敬的用户" + username + "  您暂时无法下载此文件，原因是：<span class=\"zc_s1\">积分不够</span>(代码:d_e003)";
            }
        }
        else
        {
            this.hy_title.Text = "您暂时无法下载此文件，原因是：<span class=\"zc_s1\">未登录用户</span>(代码:d_e001)";

        }
 
    }
}
