using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WeiBo.WSinaAPI;
using WeiBo.WSinaAPI.SinaControllers;
using WeiBo.WSinaAPI.SinaModels;
using ajaxpr02;


public partial class page_weibo_default : BasePageFist
{
    long myid = 0;
    string myname = "";
    long gzcount = 0;
    long fscount = 0;
    long weibocount = 0;
    string mypic = "";
     string connstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (SinaBase.HasAccess == false)  //未登陆状态
            {
                #region WSinaApiSDK 第二步，用户认证(包含获取request token)
                try
                {
                    string callBack = string.Format("http://{0}:{1}/page/weibo/SinaApiCallBack.ashx?myapp={2}", Request.Url.Host, Request.Url.Port, SinaBase.Key.AppName);  //新浪重定向地址(myapp是自定义,新浪会原型返回)
                    string authLink = SinaBase.AuthorizationGet(callBack); //第二步，用户认证(包含获取request token)
                    aLogon.HRef = authLink; //输出跳转URL

                 
                }
                catch
                {
                    Response.Write("服务器繁忙，请稍候访问");
                    Response.End();
                }
                #endregion
                if (SinaBase.HasAccess == false)  //未登陆状态
                {                
                    plUnLogon.Visible = true;   //显示未登陆界面
                    plHasLogon.Visible = false; //隐藏已登陆界面
                }
                else //已登陆状态
                {
                    //tbText.Text = STATUS;
                    plUnLogon.Visible = false;  //隐藏未登陆界面
                    plHasLogon.Visible = true;  //显示已登陆界面


                }
            }
            else //已登陆状态
            {
                //tbText.Text = STATUS;
                plUnLogon.Visible = false;  //隐藏未登陆界面
                plHasLogon.Visible = true;  //显示已登陆界面


            }
        }
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings["wkf_weibo"].ToString();

        initPl();
    }

    protected bool refresh_user(string username, long uid)
    {
        pwd_ pc = new pwd_("weibo213","wokofo");
        string password = pc.Encode(uid.ToString()); 
        //再到数据库里核对
        if (username.Length > 2 && password.Length > 10)
        {
            sql_ ooc = new sql_(System.Configuration.ConfigurationManager.ConnectionStrings["wkf_www"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "wkf_login";
            SqlParameter ccc = new SqlParameter("@username", SqlDbType.VarChar, 50);
            ccc.Value = username;
            cmd.Parameters.Add(ccc);
            ccc = new SqlParameter("@password", SqlDbType.VarChar, 50);
            ccc.Value = password;
            cmd.Parameters.Add(ccc);
            DataTable dt = ooc.get_datatable(cmd);
            if (dt.Rows.Count == 1)
            {

                Cookie cCookie = new Cookie();
                cCookie.setCookie("username", username);
                cCookie.setCookie("password", password);
                if (username.Contains("@"))
                {
                    Session["isweibo"] = "sina";
                    if (c_.c_int(dt.Rows[0][4]) == 1)
                    {
                        get_userinfo(uid);
                    }
                }

                int r_int = c_.c_int(dt.Rows[0][0]);
                Session["jifen"] = c_.c_int(dt.Rows[0][1]);
                Session["username"] = dt.Rows[0][2].ToString();
                Session["password"] = dt.Rows[0][3].ToString();
                Session["uid"] = r_int;
                return true;
            }
        }
        return false;
    }
    protected string get_userinfo(long fuserid)
    {
        try
        {
            SinaMUsers userd = UserController.GetUser(fuserid); //获取当前用户信息

            try
            {
                SqlCommand cmd_user = new SqlCommand();
                cmd_user.CommandText = "usp_wkf_weibo_c_userinfo_add";
                cmd_user.CommandType = CommandType.StoredProcedure;
                SqlParameter ccc = new SqlParameter("@_userid", SqlDbType.BigInt);
                ccc.Value = userd.id;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_screen_name", SqlDbType.NVarChar, 50);
                ccc.Value = userd.screen_name;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_name", SqlDbType.NVarChar, 50);
                ccc.Value = userd.name;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_url", SqlDbType.VarChar, 255);
                ccc.Value = userd.url;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_profile_image_url", SqlDbType.VarChar, 255);
                ccc.Value = userd.profile_image_url;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_domain", SqlDbType.VarChar, 255);
                ccc.Value = userd.domain;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_gender", SqlDbType.VarChar, 50);
                ccc.Value = userd.gender;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_followers_count", SqlDbType.BigInt);
                ccc.Value = userd.followers_count;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_friends_count", SqlDbType.BigInt);
                ccc.Value = userd.friends_count;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_statuses_count", SqlDbType.BigInt);
                ccc.Value = userd.statuses_count;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_favourites_count", SqlDbType.BigInt);
                ccc.Value = userd.favourites_count;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_created_at", SqlDbType.DateTime);
                ccc.Value = userd.created_at;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_following", SqlDbType.Bit);
                ccc.Value = userd.following;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_verified", SqlDbType.Bit);
                ccc.Value = userd.verified;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_province", SqlDbType.NVarChar, 20);
                ccc.Value = userd.province;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_city", SqlDbType.NVarChar, 20);
                ccc.Value = userd.city;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_location", SqlDbType.NVarChar, 50);
                ccc.Value = userd.location;
                cmd_user.Parameters.Add(ccc);
                ccc = new SqlParameter("@_description", SqlDbType.NVarChar, 500);
                ccc.Value = userd.description;
                cmd_user.Parameters.Add(ccc);
                sql_ ooo = new sql_(connstr);
                string k = ooo.exe_sql_pro(cmd_user);
            }
            catch
            {

            }
            return userd.screen_name;
        }
        catch
        {
            return fuserid.ToString();
        }

    }
    protected void add_log(string mess)
    {
        viewlog(mess);
    }

    protected void initPl()
    {
        if (SinaBase.HasAccess)//登陆状态
        {
            get_my();          
            string action = c_.c_string(Request["action"]);
            string av = c_.c_string(Request["av"]);
            switch (action)
            {
                case "send":
                    {
                        this.pl_my.Visible = false;
                        this.pl_send.Visible = true;
                        if (av.Length > 0)
                        {
                           // av = HttpUtility.UrlDecode(av);
                            this.txt_weibocontent.Text = av;                          
                        }
                        break;
                    }
                default:
                    {
                        this.pl_my.Visible = true;
                        this.pl_send.Visible = false;
                        break;
                    }
            }
        }
    }

    #region 页面操作


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //发微博          
        add_weibo(this.txt_weibocontent.Text);
    }

  


    #endregion
    #region 包装的方法
  

    /// <summary>
    /// 获取个人信息
    /// </summary>
    protected void get_my()
    {
        try
        {
            SinaMUsers user = UserController.GetUser(); //获取当前用户信息             
            myid = user.id;
            myname = user.screen_name;
            gzcount = user.followers_count;
            fscount = user.friends_count;
            weibocount = user.statuses_count;
            mypic = user.profile_image_url;
            this.lt_link.Text = string.Format("<a href=\"http://www.weibo.com/{1}\" target=\"_blank\">{0}</a>|粉丝数:{3}", myname, myid, gzcount, fscount, weibocount);
            this.img_mypic.ImageUrl = mypic;
            this.lblUserName.Text = string.Format("{0}绑定微博帐号成功！ 你可以<a href=\"/page/question.aspx\">进入答题</a> 或 <a href=\"#\" onclick=\"parent.location.reload();\">返回</a>", myname, c_.c_string(Session["uid"]), myid.ToString());
            if (!refresh_user("@" + myname, myid))
            {           
                viewlog("绑定用户失败");
            }
        }
        catch (Exception ex)
        {
            viewlog(ex.Message);
        }
    }
    /// <summary>
    /// 发微博
    /// </summary>
    /// <param name="mess"></param>
    protected void add_weibo(string mess)
    {
        try
        {
            long weiboid = StatusController.Update(mess);
            //发送信息
            if (weiboid > 0)
            {
                viewlog("发送成功");
            }
        }
        catch (Exception ex)
        {
            viewlog(ex.Message);// "发送内容重复了";
        }
    }
   
    /// <summary>
    /// 显示在页面上的消息
    /// </summary>
    /// <param name="mess"></param>
    protected void viewlog(string mess)
    {
        this.lb_mess.Text = mess;
    }


    #endregion


}