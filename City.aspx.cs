using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class City : System.Web.UI.Page
{
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlCommand cmd;
    SqlDataAdapter adapt,adapt5;
    public int ID = 0;
    string insmes, updmes, delmes;
    string flowid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayData();
            SqlConnection con = new SqlConnection(str);
            string com = "Select * from Conv_State";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            StateDropdown.DataSource = dt;
            StateDropdown.DataBind();
            StateDropdown.DataTextField = "State_Name";
            StateDropdown.DataValueField = "State_Id";
            StateDropdown.SelectedValue = null;
            StateDropdown.DataBind();
            StateDropdown.Items.Insert(0, "--Select--");
        }
    }

    private void DisplayData()
    {

        SqlConnection con = new SqlConnection(str);
        con.Open();
        DataTable dt = new DataTable();
        cmd = new SqlCommand("select * from Conv_City", con);
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        con.Close();
    }
    protected void btnAddCity_Click(object sender, EventArgs e)
    {
        
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select State_Flow_Id from Conv_State where State_Id = '" + StateDropdown.SelectedValue + "'", con1);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                flowid = dt.Rows[0]["State_Flow_Id"].ToString();

            }
            con1.Close();
            string addmes, updatemes;

        SqlConnection con2 = new SqlConnection(str);
        DataTable mlist = new DataTable();
        string com = "select * from Conv_City where City_Name = '" + txtcityname.Text + "' and State_Flow_Id = '"+ flowid +"'";
        SqlCommand cmd2 = new SqlCommand(com, con2);
        //string com = "select * from Conv_State where State_Name = '" + txtstatename.Text + "'";
        adapt5 = new SqlDataAdapter(cmd2);
        adapt5.Fill(mlist);
        con2.Open();
        if (mlist.Rows.Count == 0)
        {
            if (btnAddCity.Text == "Update City")
            {
                updatemes = "Data Updated Successfully";
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand("Conv_City_Proc"))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "UPDATE");
                        cmd.Parameters.AddWithValue("@City_Id", ViewState["id"].ToString());
                        cmd.Parameters.AddWithValue("@City_Name", txtcityname.Text);
                        cmd.Parameters.AddWithValue("@State_Flow_Id", flowid);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + updatemes + "','','success')", true);
                        con.Close();
                        this.DisplayData();
                        this.ClearData();

                    }
                }
            }
            else
            {
                //btnReset.Text = flowid.ToString();
                addmes = "Data Added Successfully";
                string city_name = txtcityname.Text;
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand("Conv_City_Proc"))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "INSERT");
                        cmd.Parameters.AddWithValue("@City_Name", city_name);
                        cmd.Parameters.AddWithValue("@State_Flow_Id", flowid);
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
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('City Already Entered')", true);
        }
        con2.Close();

    }
    protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
    {
        btnAddCity.Text = "Update City";
        ImageButton btnedit = (ImageButton)(sender);
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Conv_City where City_Id='" + btnedit.CommandArgument.ToString() + "'", con);

        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtcityname.Text = dt.Rows[0]["City_Name"].ToString();
            SqlCommand cmd2 = new SqlCommand("select * from Conv_State where State_Flow_Id='" + dt.Rows[0]["State_Flow_Id"] + "'", con);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd2);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                StateDropdown.ClearSelection();
                ListItem selected = StateDropdown.Items.FindByText(dt1.Rows[0]["State_Name"].ToString());
                selected.Selected = true;
            }

        }
        
        ViewState["id"] = btnedit.CommandArgument.ToString();
    }
    protected void btnImgDel_Click(object sender, ImageClickEventArgs e)
    {
        string delmes = "Data Deleted Successfully";
        ImageButton btnDel = (ImageButton)(sender);
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_City_Proc"))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@City_Id", btnDel.CommandArgument.ToString());
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
    private void ClearData()
    {
        txtcityname.Text = "";
        btnAddCity.Text = "Insert Data";
        StateDropdown.SelectedIndex = 0;
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}