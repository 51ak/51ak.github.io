<%@ WebHandler Language="C#" CodeBehind="SinaApiCallBack.ashx.cs" Class="SinaApiCallBack" %>
/*
 This file was create by Wokofo at 2011.03.20
 */
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

using WeiBo.WSinaAPI;
using WeiBo.WSinaAPI.SinaControllers;


    /// <summary>
    /// Summary description for SinaApiCallBack
    /// </summary>
public class SinaApiCallBack : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        string oauth_token = context.Request["oauth_token"];
        string oauth_verifier = context.Request["oauth_verifier"];
        string myapp = context.Request["myapp"];
        string redirectUrl = String.Empty;

        #region WSinaAPI 第二步 判断返回来的是哪个Key (myapp是自定义,新浪会原型返回)
        /* if (myapp == ConfigKey.AppKey_2.ToString())
            {
                //第二应用
                SinaBase.Key = SinaApiConfig.AppKeyGet(ConfigKey.AppKey_2.ToString());  //设置当前AppKey,必需
                redirectUrl = "Second.aspx";
            }
            else*/
        {  //第一应用
            SinaBase.Key = SinaApiConfig.AppKeyGet(ConfigKey.AppKey_1.ToString());  //设置当前AppKey,必需
            redirectUrl = "/page/weibo/default.aspx";
        }
        #endregion

        #region WSinaAPI 第二步 根据返回callBack获取access token
        if (!string.IsNullOrEmpty(oauth_token) && !string.IsNullOrEmpty(oauth_verifier))
        {
            SinaBase.AccessTokenGet(oauth_token, oauth_verifier);
        }
        if (SinaBase.HasAccess)
        {
            //缓存用户名(网站需要)
            long user_id = Convert.ToInt64(SinaBase.oAuth.AccessUesrID);
            context.Session["UserID"] = user_id;
            //获取关注关系
            SinaOwer.hasFollowing = AccountController.FriendshipsExists(SinaOwer.id, user_id);
        }
        #endregion

        context.Response.Redirect(redirectUrl);

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}