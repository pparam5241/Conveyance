using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMasterPage : System.Web.UI.MasterPage
{
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlCommand cmd1;
    SqlDataAdapter adapt1, adapt5;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["username"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Label1.Text = Session["username"].ToString();
            Label2.Text = Session["username"].ToString();
        }
        SqlConnection con = new SqlConnection(str);
        con.Open();
        DataTable dt1 = new DataTable();
        // cmd1 = new SqlCommand("Select A.Emp_Mst_User_Code,B.Misc_Field_Value,B.Misc_Field_Name,* From Conv_Employee_Master A Inner Join Conv_Misc B on ',' + A.Emp_Mst_Vehical_Type + ',' Like '%,'+ B.Misc_Field_Name + ',%' And Misc_Colomn_Name = 'Fuel_Mst_Vehical_Type' Where 1=1", con);
        cmd1 = new SqlCommand("select * from Conv_Employee_Master where Emp_code = '"+Session["username"].ToString()+"'", con);
        adapt1 = new SqlDataAdapter(cmd1);
        adapt1.Fill(dt1);
        Image1.ImageUrl = "~/images/"+ dt1.Rows[0]["Emp_Profile_Img"].ToString();
        Image2.ImageUrl = "~/images/" + dt1.Rows[0]["Emp_Profile_Img"].ToString();
        con.Close();
    }
}
