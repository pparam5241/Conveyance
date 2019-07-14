using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class State : System.Web.UI.Page
{
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlCommand cmd;
    SqlDataAdapter adapt;
    public int ID = 0;
    string insmes, updmes, delmes;
    protected void Page_Load(object sender, EventArgs e)
    {
        //innerID.InnerHTML = "";
        if (!IsPostBack)
        {
            DisplayData();
        }
    }
    private void DisplayData()
    {
        SqlConnection con = new SqlConnection(str);
        con.Open();
        DataTable dt = new DataTable();
        cmd = new SqlCommand("select * from Conv_State", con);
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        con.Close();
    }


    protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
    {

            btnAddState.Text = "Update State";

            ImageButton btnedit = (ImageButton)(sender);
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Conv_State where State_Id='" + btnedit.CommandArgument.ToString() + "'", con);

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtstatename.Text = dt.Rows[0]["State_Name"].ToString();

            }
            ViewState["id"] = btnedit.CommandArgument.ToString();
        }
        //txtstatename.Text="prachi";

    protected void btnImgDel_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnDel = (ImageButton)(sender);
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_State_Proc"))
            {
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@State_Id", btnDel.CommandArgument.ToString());
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                string delmes = "Data Deleted Successfully";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + delmes + "','','success')", true);
                //Response.Write("<script>alert('Record Deleted Successfully!')</script>");
                
                DisplayData();
                con.Close();
            }
        }
    }
    protected void btnAddState_Click(object sender, EventArgs e)
    {
        SqlConnection con2 = new SqlConnection(str);
        DataTable mlist = new DataTable();
        SqlCommand cmd2 = new SqlCommand("select * from Conv_State where State_Name = '" + txtstatename.Text + "'", con2);
        //string com = "select * from Conv_State where State_Name = '" + txtstatename.Text + "'";
        adapt = new SqlDataAdapter(cmd2);
        adapt.Fill(mlist);

        con2.Open();
        string addmes, updatemes;
        if (mlist.Rows.Count == 0)
        {
            if (btnAddState.Text == "Update State")
            {
                updatemes = "Data Updated Successfully";
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand("Conv_State_Proc"))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "UPDATE");
                        cmd.Parameters.AddWithValue("@State_Id", ViewState["id"].ToString());
                        cmd.Parameters.AddWithValue("@State_Name", txtstatename.Text);
                        cmd.Connection = con;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + updatemes + "','','success')", true);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        this.DisplayData();
                        this.ClearData();

                    }
                }
            }
            else
            {
                string state_name = txtstatename.Text;
                addmes = "Data Added Successfully";
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand("Conv_State_Proc"))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "INSERT");
                        cmd.Parameters.AddWithValue("@State_Name", state_name);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + addmes + "','','success')", true);
                        this.DisplayData();
                        this.ClearData();
                        con.Close();
                    }
                }
            }
        }
        else
        {
            string errormes = "Data Already Entered!";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + errormes + "','','error')", true);
        }
    }
    private void ClearData()
    {
        txtstatename.Text = "";
        btnAddState.Text = "Insert Data";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}