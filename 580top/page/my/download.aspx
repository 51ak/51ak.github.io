<%@ Page Language="C#" AutoEventWireup="true" CodeFile="download.aspx.cs" Inherits="page_my_download" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>下载记录</title>  
       <link href="../../img/small.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server" >
    <div class="local_daohang">我的下载记录&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="jifen.aspx">我的积分</a>&nbsp;|&nbsp;<a href="../jifen.aspx">排行榜</a></div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" 
                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" 
                    ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="username" HeaderText="用户" 
                    SortExpression="username" />
                <asp:BoundField DataField="o_id" HeaderText="文件编号" SortExpression="o_id" />
                <asp:BoundField DataField="addtime" HeaderText="下载时间" 
                    SortExpression="addtime" />
                      <asp:BoundField DataField="title" HeaderText="文件名" SortExpression="title" />
                    
                    
            
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:wkf_www %>" 
                SelectCommand="wkf_lst_download" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="" Name="username" SessionField="username" 
                        Type="String" />
                
                </SelectParameters>
            </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
