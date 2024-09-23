<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file.aspx.cs" Inherits="page_file" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>下载文件</title>  
       <link href="../img/small.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server" >
    <div class="local_daohang">下载文件&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="my/download.aspx">我的下载记录</a>&nbsp;|&nbsp;<a href="my/jifen.aspx">我的积分记录</a></div>
    <div>
    
        下载文件：<asp:HyperLink ID="hy_title" runat="server"></asp:HyperLink>
        <br />
        我的积分：<asp:Label ID="lb_jifen" runat="server" ForeColor="Red" Text="0"></asp:Label>
        分<br />
        扣除积分：<asp:Label ID="lb_kc" runat="server" ForeColor="Red" Text="0"></asp:Label>
        分<br />
    
    </div>
    </form>
</body>
</html>
