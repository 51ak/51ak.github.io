<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="page_weibo_default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>分享到我的微博</title>
<link href="../../img/small.css" rel="stylesheet" type="text/css" />
   
</head>
<body>
    <form id="form1" runat="server">
    <%--未登陆界面--%>
    <asp:Panel ID="plUnLogon" runat="server">
        <a href="#" runat="server" id="aLogon">
            <img src="../../img/login_48.png" alt="登陆新浪微博" />
        </a>
    </asp:Panel>
    <%--已登陆界面--%>
    <asp:Panel ID="plHasLogon" runat="server" Visible="false">       
        <div class="local_daohang">

        <table width="100%"><tr><td>  
         <asp:Image ID="img_mypic" runat="server" ImageAlign="Middle" Width="30" Height="30" />
       </td>
       <td width="140"><span class="f_right"> <asp:Literal ID="lt_link" runat="server"></asp:Literal></span></td>
       </tr></table>   
       </div>
      <div><asp:Label ID="lb_mess" runat="server" EnableViewState="False"></asp:Label></div>

     <asp:Panel ID="pl_my" runat="server" Visible="false">                      
               
                <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>    
     </asp:Panel>
    
      
       <asp:Panel ID="pl_send" runat="server" Visible="false">
    <asp:TextBox ID="txt_weibocontent" runat="server" MaxLength="140" Text="" Height="65px" 
            Width="465px" TextMode="MultiLine"></asp:TextBox>
   <br />
   <br />
   <asp:Button ID="btn_up" runat="server" Text="发送微博" OnClick="btnUpdate_Click" />
   </asp:Panel>
    
    </asp:Panel>
    </form>
</body>
</html>
