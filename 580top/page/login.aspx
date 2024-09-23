<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="page_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录</title>
      <link href="../img/small.css" rel="stylesheet" type="text/css" />
<style type="text/css">
body
{
   background-image:none;
}

/*登录*/
#div_login
{
	margin-left:15px;
	line-height:120%;}
#div_login p
{
    margin: 5px 0 ;
	margin-left:15px;
	line-height:120%;}
#div_login .formt { margin-top:15px;  font-weight:bold; color:#777; letter-spacing:1px;  }
#div_login #username,#password {
	background:#fff;
	border:1px solid #ccc;
	color:#006633;
	font-size:14px;
	width:186px;
	height:25px;
	padding-left:20px;
	line-height:25px;
	letter-spacing:1px;
	font-weight:400;
}
#div_login #username { background:url(../img/username.gif) no-repeat 2px 5px;}
#div_login #password { background:url(../img/password.gif) no-repeat 2px 5px;}
#div_login #forget{ line-height:28px;}
#div_login .imgbutton {margin-top:7px; margin-left:22px; 
                       cursor:pointer;
                       }

.margin8
{
margin:8px 0;
}
.margin18
{
margin:18px 0;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="pl_login" runat="server">
     <div id="div_login">	<span class="formt">用户名</span>  
       <p>
           <asp:TextBox ID="username" runat="server"></asp:TextBox>
      </p>  
               <span class="formt">密码</span>  
                <p> <asp:TextBox ID="password" runat="server"></asp:TextBox></p>  
                  <asp:ImageButton ID="img_save" runat="server" 
                ImageUrl="../img/loginin.gif" CssClass="imgbutton" 
                onclick="ImageButton1_Click" /> 
                <img alt="注册会员" onclick="parent.alertWin('注册会员','/page/reg.aspx',550,400);" src="../img/regin.gif" class="imgbutton" />
    <div class="margin18"><a href="#" onclick="parent.alertWin('同步到新浪微博','/page/weibo/default.aspx',550,400);">用新浪微博登录</a></div> 
    </div> 
    </asp:Panel>
    <asp:Panel ID="pl_my" runat="server">
                <div class="margin8">欢迎  <asp:Label ID="lb_username" runat="server" 
                        Font-Bold="True" ></asp:Label>！<span style="float:right"><a href="/page/loginout.aspx">安全退出</a></span></div>
            <div class="margin8">我的积分：<asp:Label ID="lb_jifen" runat="server" Text="0" 
                    ForeColor="Red"></asp:Label>分</div>
            <table width="100%" cellspacing="7">
            <tr>
            <td><a href="#" onclick="parent.alertWin('我的收藏','/page/my/shoucang.aspx',550,400);">我的收藏</a></td>
            <td><a href="#" onclick="parent.alertWin('我的消息','/page/my/xiaoxi.aspx',550,400);">我的消息</a></td>
            </tr>
            <tr>
            <td><a href="#" onclick="parent.alertWin('我的课程包','/page/my/kecheng.aspx',550,400);">我的课程包</a></td>
            <td><a href="#" onclick="parent.alertWin('我的学习记录','/page/my/xuexi.aspx',550,400);">学习记录</a></td>
                </tr>
               <tr>
               <td><a href="#" onclick="parent.alertWin('我的答题记录','/page/question.aspx',550,400);">进入答题</a></td>
               <td><a href="#" onclick="parent.alertWin('我的积分记录','/page/my/jifen.aspx',550,400);">我的积分记录</a></td>
               </tr>
               <tr>
               <td><a href="#" onclick="parent.alertWin('我的阅读记录','/page/my/view.aspx',550,400);">我的阅读记录</a></td>
               <td>&nbsp;</td>
               </tr>
            </table>
    </asp:Panel>
</form>
    
</body>
</html>
