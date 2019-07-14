using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Conv_Status : System.Web.UI.Page
{
    string result;
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlCommand cmd;
    SqlDataAdapter adapt;
    string s1;
    protected void Page_Load(object sender, EventArgs e)
    {

        if(TextBox6.Text=="")
        {
            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(0).AddDays(-1);

            TextBox6.Text = lastDayOfMonth.ToString();
            //TextBox6.Text = DateTime.Now.ToString();
        }
    }
    protected void btnShowStatus_Click(object sender, EventArgs e)
    {
        DisplayData();
    }
    private void DisplayData()
    {
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Convenyance_log_with_Curr_data"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "View");
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
        }
    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)Repeater1.Items[i].FindControl("CheckBox1");
            if (chk.Checked)
            {
                    result += (chk.Text + ",");
            }
        }


        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Convenyance_log_with_Curr_data"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Pay");
                    cmd.Parameters.AddWithValue("@UserName", result);
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
        }
    }
}