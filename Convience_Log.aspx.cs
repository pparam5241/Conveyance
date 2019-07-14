using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Convience_Log : System.Web.UI.Page
{
    

    protected void BtnView_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnAddEmp_Click(object sender, EventArgs e)
    {
        Session["dateData"] = txtdate.Text;
        Response.Redirect("View.aspx");        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        txtdate.Text = DateTime.Now.ToString();
    }
}