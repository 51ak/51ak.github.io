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
using System.Data.SqlClient;

public partial class question :zt
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        
        if (!IsPostBack)
        {            
            if (Request["id"] != null)
            {
                id = c_int(Request["id"]);
            }
            bind_page(id);
            bind_reg();  
        }

      
    }

    protected void bind_reg()
    {
        if (wkf_login())
        {
            this.lb_reg.Text = " 用户：<strong>" + Session["username"].ToString() + "</strong>&nbsp; &nbsp;积分：<font color=\"red\">" + Session["jifen"].ToString() + "</font>分";
        }
        else
        {
            this.lb_reg.Text = "访客，无法增加积分！<a href=\"reg.aspx\">注册</a> <a href=\"login.aspx\">登录</a> ";
        }
    }
    protected void bind_page(int id)
    {
        string kind = "全部";

        this.dp_xx.Enabled = true;
        this.chk_xx.Enabled = true;
        this.lb_answer.Text = "";
        DataTable dt = get_question(id, kind);
        if (dt.Rows.Count == 1)
        {
            this.chk_xx.Items.Clear();
            this.dp_xx.Items.Clear();
            string a = "";
            
            //tmxh,tmnd,tmlx,tmnr,tmdas,tmda1,tmda2,tmda3,tmda4,tmda5,tmda6,tmzqda,kind
            this.hid_id.Value = dt.Rows[0][0].ToString();
            string nandu = dt.Rows[0][1].ToString();
            string tmlx = dt.Rows[0][2].ToString();
            string title = dt.Rows[0][3].ToString();
            int num = c_int(dt.Rows[0][4].ToString());
            string answer = dt.Rows[0][11].ToString();
            string kindt = dt.Rows[0][12].ToString();

            string s_answer = "";
            string tmlx2;
            if (tmlx == "2")
            {
                this.chk_xx.Visible = true;
                this.dp_xx.Visible = false;
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
                this.chk_xx.Visible = false;
                this.dp_xx.Visible = true;
            }
            for (int num1 = 0; num1 < num; num1++)
            {
                char cb =Convert.ToChar(65 + num1);
                string cbt;
                if (tmlx != "3")
                {
                    cbt = cb + "." + dt.Rows[0][5 + num1].ToString();
                }
                else
                {

                    cbt = dt.Rows[0][5 + num1].ToString();

                }

                if (tmlx == "2")
                {

                    this.chk_xx.Items.Add(cbt);
                }
                else
                {
                    this.dp_xx.Items.Add(cbt);
                }
                s_answer += answer[num1];
            }
            this.hid_a.Value = s_answer;


            this.lb_answer.Text = "";
            this.lb_tile.Text ="<span class=\"zc_966\">"+ tmlx2+"</span> 【" + kindt + "】<span class=\"zc_title\">" + title + "</a></span>(难度:" + nandu + ")";
            this.btn_huida.Text = "回答问题";
        //    this.lb_count_all.Text = (c_int(this.lb_count_all.Text) + 1).ToString();
            
        }
    }




    protected void link_get_next_Click(object sender, EventArgs e)
    {
        bind_page(0);
    }
  
    protected void get_answer(bool isshow)
    {
        this.dp_xx.Enabled = false;
        this.chk_xx.Enabled = false;
        this.btn_huida.Text = "下一题>";
        string xianshi="";
        string a1 = this.hid_a.Value;
        //Response.Write(a1);
        //Response.Write(this.hid_id.Value);
        //Response.End();
        bool isright = true;
        bool isduoxuan=false;
        string zqda = "";
       
        if(this.chk_xx.Visible==true)
        {
            isduoxuan=true;
           
        }
        for (int i = 0; i < a1.Length; i++)
        {
            bool c1;
            if (a1[i] == '1')
            {
                c1 = true;
            }
            else
            {
                c1 = false;
            }
            bool c2;
            if (isduoxuan)
            {
                c2 = this.chk_xx.Items[i].Selected;  
            }
            else
            {
                c2 = this.dp_xx.Items[i].Selected;
               
            }
            if (c1 != c2)
            {
                 isright = false;
            }
           
            if (c1)
            {
                if (isduoxuan)
                {
                    zqda += this.chk_xx.Items[i].Text.Substring(0, 1) + "&nbsp;";
                }
                else
                {
                    zqda = this.dp_xx.Items[i].Text;

                }
            }
        }
        if (isshow)
        {
            int allcount = c_int(this.lb_count_all.Text);
            int rightcount = c_int(this.lb_count_right.Text);

            if (isright)
            {
                xianshi += "回答 <font class=\"zc_s3\">正确！</font><br />";
                //if (rightcount % 10 == 9)
                //{
                    if (wkf_login())
                    {
                        int jifen = c_int(Session["jifen"]);                      
                        add_jifen(Session["username"].ToString(), 1,"回答问题");
                        jifen = jifen + 1;
                        refresh_user();
                        bind_reg();
                    }

                //}
                rightcount++;

                this.lb_count_right.Text = rightcount.ToString();
            }
            else
            {
                xianshi += "回答 <font class=\"zc_red\">错误！</font> <br />";
            }
            allcount++;
            this.lb_count_all.Text = allcount.ToString();
        }
        xianshi += "正确答案是:<font class=\"zc_blue\">" + zqda + "</font>";
        this.lb_answer.Text = xianshi;

    }
    protected void link_get_answer_Click1(object sender, EventArgs e)
    {
        get_answer(false);
    }
    protected void btn_huida_Click(object sender, EventArgs e)
    {
        if (this.btn_huida.Text == "回答问题")
        {
            get_answer(true);
        }
        else
        {
            bind_page(0);
        }
    }    

}
