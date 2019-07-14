using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View : System.Web.UI.Page
{
    string result;
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(0).AddDays(-1);
            tillDate.Text = lastDayOfMonth.ToString();
            DisplayData();
        }
    }
    private void DisplayData()
    {


        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Conveyance_Log_Proc"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Onload");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                    con.Close();

                }
              
            }
        }
        /*
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Conveyance_Log_Proc"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE1");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Conveyance_Log_Proc"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "SELECT");
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
            }
        }*/
    }
    protected void Button1_Click(object sender, EventArgs e)
     {
         using (SqlConnection con = new SqlConnection(str))
         {
             using (SqlCommand cmd = new SqlCommand("Conv_Conveyance_Log_Proc"))
             {
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@Action", "Success");
                 cmd.Parameters.AddWithValue("@Conv_Conveyance_Datetime", DateTime.Now);
                 cmd.Parameters.AddWithValue("@Conv_Conveyance_Get_User", Session["username"].ToString());
                 cmd.Connection = con;
                 con.Open();
                 cmd.ExecuteNonQuery();
                 string addmes = "Data Replaced Successfully!";
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + addmes + "','','success')", true);
                 DisplayData();
                 con.Close();
             }
         }
    }
    protected void btnImgDel_Click(object sender, ImageClickEventArgs e)
    {
        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            TextBox chk = (TextBox)Repeater1.Items[i].FindControl("TextBox1");
            if (chk!=null)
            {
                    result += (chk.Text);
            }
        }
        string delmes = "Data Deleted Successfully";
        ImageButton btnDel = (ImageButton)(sender);
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Conveyance_Log_Proc"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@Conv_Conveyance_Datetime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Conv_Conveyance_Get_User", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@Conv_Code", btnDel.CommandArgument.ToString());
                cmd.Parameters.AddWithValue("@Del_Reason", result.Trim());

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                //delmes = "Data Deleted Successfully";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + delmes + "','','success')", true);
                //Response.Write("<script>alert('Record Deleted Successfully!')</script>");
                DisplayData();
                con.Close();
            }
        }
    }
}