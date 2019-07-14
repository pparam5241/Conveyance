using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("username");
        Response.Redirect("Default.aspx");
        if (Session["username"] == null)
        {
            string logoutmes = "Loggedout Successful!";
            Response.Redirect("Default.aspx");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + logoutmes + "','','success')", true);
        }
    }
}