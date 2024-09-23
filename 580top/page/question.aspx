<%@ Page Language="C#" AutoEventWireup="true" CodeFile="question.aspx.cs" Inherits="question" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>回答问题</title>  
       <link href="../img/small.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server" >
    <div class="local_daohang">
       <table width="100%"><tr><td>  已回答：<asp:Label ID="lb_count_all" runat="server" Text="0" ForeColor="Red"></asp:Label>题&nbsp;
        答对：<asp:Label ID="lb_count_right" runat="server" Text="0" ForeColor="Red"></asp:Label>题&nbsp; 
       <asp:Label ID="lb_reg" runat="server"></asp:Label> 
       </td>
       <td width="140"><span class="f_right">    <a href="my/jifen.aspx">我的积分记录</a>&nbsp;|&nbsp;<a href="jifen.aspx">排行榜</a></span></td>
       </tr></table>
       
    </div>
    <div >
        <asp:Label ID="lb_tile" runat="server" CssClass="zc_999"></asp:Label></div>
    <div>
        <asp:RadioButtonList ID="dp_xx" runat="server" Visible="False" 
            CssClass="zc_666">
        </asp:RadioButtonList>
        <asp:CheckBoxList ID="chk_xx" runat="server" Visible="False" CssClass="zc_666">
        </asp:CheckBoxList>
    </div>
    <div>
        <asp:Label ID="lb_answer" runat="server" CssClass="zc_margin10" ></asp:Label>
    </div>
    <div class="hrdt"></div>
    <div >
        <asp:Button ID="btn_huida" runat="server" Text="开始答题" Width="73px" 
            onclick="btn_huida_Click" />
            &nbsp;&nbsp;
            <asp:LinkButton ID="link_get_answer" runat="server" onclick="link_get_answer_Click1" 
           >查看答案</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="link_get_next" runat="server" 
            onclick="link_get_next_Click">跳过</asp:LinkButton></div>
   
    <asp:HiddenField ID="hid_id" runat="server" Visible="false" />   
      <asp:HiddenField ID="hid_a" runat="server" Visible="false" />   
    </form>
</body>
</html>
