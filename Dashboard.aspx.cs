using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Overall_Dashboard_Proc"))
            {
                cmd.Parameters.AddWithValue("@Action", "KMWEEK");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Label1.Text = dt.Rows[0]["Km"].ToString();
                    }
                }
            }
        }
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Overall_Dashboard_Proc"))
            {
                cmd.Parameters.AddWithValue("@Action", "KMMONTH");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Label2.Text = dt.Rows[0]["Km"].ToString();
                    }
                }
            }
        }
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Overall_Dashboard_Proc"))
            {
                cmd.Parameters.AddWithValue("@Action", "AMOUNTWEEK");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Label3.Text = dt.Rows[0]["Amount"].ToString();
                    }
                }
            }
        }
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Overall_Dashboard_Proc"))
            {
                cmd.Parameters.AddWithValue("@Action", "AMT_MONTH");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Label4.Text = dt.Rows[0]["Last_mth_total_Amount"].ToString();
                        }
                    }
                }
            }
        }
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Overall_Dashboard_Proc"))
            {
                cmd.Parameters.AddWithValue("@Action", "ACTIVEEMP");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Label5.Text = dt.Rows[0]["TotalEmp"].ToString();
                    }
                }
            }
        }
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Overall_Dashboard_Proc"))
            {
                cmd.Parameters.AddWithValue("@Action", "NEWEMP");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Label6.Text = dt.Rows[0]["Newuser"].ToString();
                    }
                }
            }
        }

    }
}