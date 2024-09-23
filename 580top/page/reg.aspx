<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg.aspx.cs" Inherits="page_reg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户注册</title>
         <link href="../img/small.css" rel="stylesheet" type="text/css" />
         <style type="text/css">
.buttom{
    padding:1px 10px;
    font-size:12px;
    border:1px #006633 solid;
    background:#D0F0FF;
}
#formwrapper {
    width:400px;
    margin:10px auto;
    padding:20px;
    text-align:left;
  /*  border:1px #1E7ACE solid;*/
}

fieldset {
    padding:10px;
    margin-top:5px;
    border:1px solid #3dae88;
    background:#fff;
}

fieldset legend {
    
    font-weight:bold;
    padding:3px 20px 3px 20px;
    border:1px solid #3dae88;    
    background:#fff;
}
.btncss
{
	padding:1px 10px;
    font-size:12px;
    border:1px #006633 solid;
    background:#D0F0FF;

}


-->
</style>
</head>
<body>
<form id="form1" runat="server">
  <div id="formwrapper">
    <fieldset>
        <legend>用户注册</legend>
        <div>&nbsp;</div>
        <div>
            <asp:Label ID="lb_msg" runat="server" Text="<span class=riqi>*注册会员 </span>"></asp:Label></div>
        <asp:Panel ID="pl_reg_main" runat="server">      
           <table cellpadding="4" cellspacing="1"  >
              <tr><td>用户名：</td>
              <td><asp:TextBox ID="txt_username" runat="server"></asp:TextBox>*<asp:RequiredFieldValidator 
                      ID="r1" runat="server" ErrorMessage="必填" Display="Dynamic" 
                      ControlToValidate="txt_username"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="r_username" runat="server" 
                        ControlToValidate="txt_username" Display="Dynamic" ErrorMessage="格式出错" 
                        ValidationExpression="^[a-zA-Z]{1}[a-zA-Z0-9_]{3,15}$"></asp:RegularExpressionValidator>
                  (4-16字符)</td>
              </tr>
                <tr><td>电子邮箱：</td><td>
                    <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
                    *<asp:RequiredFieldValidator ID="r2" runat="server" 
                        ControlToValidate="txt_email" Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rmail" runat="server" 
                        ControlToValidate="txt_email" Display="Dynamic" ErrorMessage="格式出错" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td></tr>
              <tr><td>密码：</td>
              <td><asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>*<asp:RequiredFieldValidator 
                      ID="r3" runat="server" ErrorMessage="必填" 
                      ControlToValidate="txt_password"></asp:RequiredFieldValidator>
                      </td>
              </tr>
              <tr><td>重复密码：</td>
              <td><asp:TextBox ID="txt_cpassword" runat="server" TextMode="Password"></asp:TextBox>*<asp:RequiredFieldValidator 
                      ID="r4" runat="server" ErrorMessage="必填" ControlToValidate="txt_cpassword" 
                      Display="Dynamic"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="r5" runat="server" ControlToCompare="txt_password" 
                      ControlToValidate="txt_cpassword" Display="Dynamic" ErrorMessage="两次密码不一致"></asp:CompareValidator>
                  </td>
              </tr>
              <tr><td>&nbsp;</td>
              <td>
                  <asp:Button ID="btn_reg" runat="server" CssClass="btncss" 
                      onclick="btn_reg_Click" Text="注册" />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
              </tr>             
           </table>           
         </asp:Panel>
      
    </fieldset>
</div>
    </form>
</body>
</html>
