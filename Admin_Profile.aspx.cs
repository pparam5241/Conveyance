using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Profile : System.Web.UI.Page
{
    string password;
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnChangePass_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == ""|| TextBox3.Text =="") //this function checks for both null or empty string.
        {
            //Password Field is Empty
            //Console.WriteLine("Password empty");
            string errormes = "Password Must not be Empty!";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + errormes + "','','error')", true);
        }
        else
        {
            if (TextBox2.Text == TextBox3.Text)
            {
                SqlConnection con2 = new SqlConnection(str);
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("select * from UserLogin where UserName = '" + Session["username"].ToString() + "'", con2);
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    password = dt2.Rows[0]["Password"].ToString();

                }
                con2.Close();
                if (password == TextBox1.Text)
                {
                    using (SqlConnection con = new SqlConnection(str))
                    {
                        using (SqlCommand cmd = new SqlCommand("UserLogin_Proc"))
                        {
                            con.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@UserName", Session["username"].ToString());
                            cmd.Parameters.AddWithValue("@Password", TextBox2.Text);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            TextBox3.Text = "";
                            string errormes = "Password Changed Successfully!";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + errormes + "','','success')", true);
                            con.Close();
                        }
                    }
                }
                else
                {
                    string errormes = "Old Password Is Wrong";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + errormes + "','','error')", true);
                }
            }
            else
            {
                string errormes = "Confirm Password Not Matched";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + errormes + "','','error')", true);
            }
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
}