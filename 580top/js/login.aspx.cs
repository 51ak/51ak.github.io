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
        /*
       int newsid = 0;
       int cataid = 0;
       if (Request["newsid"] != null)
       {
           newsid = c_int(Request["newsid"]);           
       }
       if (Request["cataid"] != null)
       {
           cataid = c_int(Request["cataid"]);
       }      
       string page = q("page");  
       string htmstr = "";
       if (page != "com")
       {
           //如果是新闻页
           if (newsid > 0 && page == "view")
           {
              // string newshtml;
               SqlCommand cmd2 = new SqlCommand();
               cmd2.CommandText = "get_newsid_info";
               SqlParameter ccc2 = new SqlParameter("@newsid", SqlDbType.Int);
               ccc2.Value = newsid;
               cmd2.Parameters.Add(ccc2);
               DataTable dt2 = GetDataTable(cmd2);
               if (dt2.Rows.Count == 1)
               {
                   htmstr += "document.getElementById('a_view_num').innerHTML = '" + dt2.Rows[0][0].ToString() + "';\r\n";
                   htmstr += "document.getElementById('a_re_num').innerHTML = '" + dt2.Rows[0][1].ToString() + "';\r\n";

               }
           }
           htmstr += get_question();          
           Response.Write(htmstr);
       }
       */
        string page = q("page");

        if (page != "index")
        {
            string htmstr = get_login();
            htmstr += get_question();
            Response.Write(htmstr);
        }
        else
        {
            string htmstr = get_login();
            htmstr += get_login_title();
            Response.Write(htmstr);
        }
       
    }
    protected string get_login()
    {
        string tmp = "document.getElementById('div_login').innerHTML = '<iframe src=\"../../page/login.aspx\" frameBorder=\"0\" width=\"100%\"  scrolling=\"no\" height=\"190\"></iframe>';\r\n";       
        return tmp;
    }
    protected string get_login_title()
    {
        string tmp = "document.getElementById('div_login').innerHTML = '<iframe src=\"page/login.aspx\" frameBorder=\"0\" width=\"100%\"  scrolling=\"no\" height=\"190\"></iframe>';\r\ndocument.getElementById('div_login_title').innerHTML = '通行证登录';\r\n";
        return tmp;
    }


  
    protected string get_history()
    {
        string tmp="";
        DateTime dtnow = DateTime.Now;
        int y = dtnow.Year;
        int m = dtnow.Month;
        int d = dtnow.Day;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "wkf_get_history_top1";
        SqlParameter ccc = new SqlParameter("@month", SqlDbType.Int);
        ccc.Value = m;
        cmd.Parameters.Add(ccc);
        ccc = new SqlParameter("@day", SqlDbType.Int);
        ccc.Value = d;
        cmd.Parameters.Add(ccc);
        DataTable dt = GetDataTable(cmd);
        if (dt.Rows.Count == 1)
        {
      
            int y1 = c_int(dt.Rows[0][1].ToString());
            tmp += " <span>" + (y - y1).ToString() + "年前的今天：</span><br />";
            tmp += "<a href=\"#\" onclick=\"alertWin(\\'历史上的今天\\',\\'../../page/history.aspx?id=" + dt.Rows[0][0].ToString() + "\\',550,400);\">";
            tmp += "[" + dt.Rows[0][2].ToString() + "] " + dt.Rows[0][3].ToString() + "</a>";
            tmp = "document.getElementById('div_ran').innerHTML = '" + tmp + "';\r\n";
        }
        return tmp;
    }



    protected string get_question()
    {
        string kind = "全部";
        int id = 0;
        string tmp = "";
        DataTable dt = get_question(id, kind);
        if (dt.Rows.Count == 1)
        {

            string a = "";

            //tmxh,tmnd,tmlx,tmnr,tmdas,tmda1,tmda2,tmda3,tmda4,tmda5,tmda6,tmzqda,kind
            string tid = dt.Rows[0][0].ToString();
            string nandu = dt.Rows[0][1].ToString();
            string tmlx = dt.Rows[0][2].ToString();
            string title = dt.Rows[0][3].ToString();
            string kindt = dt.Rows[0][12].ToString();
            string tmlx2;
            if (tmlx == "2")
            {
                tmlx2 = "多选题";
            }
            else
            {
                if (tmlx == "1")
                {
                    tmlx2 = "单选题";
                }
                else
                {
                    tmlx2 = "判断题";
                }
            }

            tmp += " <span>【" + kindt + "】</span><br />";
            tmp += "<a href=\"#\" onclick=\"alertWin(\\'在线知识问答\\',\\'../../page/question.aspx?id=" + tid + "\\',550,400);\">";
            tmp += "[" + tmlx2 + "] " + title + "<br />点击进入答题>></a>";
            tmp = "document.getElementById('div_ran').innerHTML = '" + tmp + "';\r\n";

        }
        return tmp;
    }

}
