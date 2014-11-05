using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;

public partial class Account_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session[SESSION.AccounLoginYN] = "";
        Session[SESSION.UserName] = "";
        Session.Abandon();
        Response.Cookies.Remove("UserName");
        Response.Cookies.Remove("PassWord");
        Response.Cookies["UserName"].Expires = DateTime.Now.AddMonths(-1);
        Response.Cookies["PassWord"].Expires = DateTime.Now.AddMonths(-1);
        Session[SESSION.AccounLoginYN] = "N";
        Session[SESSION.UserName] = "";
        Response.Redirect("~/Account/Login.aspx");
    }
}