using System;
using System.Web;


public partial class page_ip : zt
{
    protected void Page_Load(object sender, EventArgs e)
    {
       Response.Write(GetUserIp());
    }
}
