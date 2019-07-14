using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Km_Master : System.Web.UI.Page
{
    string kmfrom, kmto;
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlCommand cmd;
    SqlDataAdapter adapt,adapt5;
    protected void Page_Load(object sender, EventArgs e)
    {
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
        cmd = new SqlCommand("select * from Conv_Km_Master", con);
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        con.Close();

        string com = "Select * from Conv_Area_Master";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt01 = new DataTable();
        adpt.Fill(dt01);
        DropdownFrom.DataSource = dt01;
        DropdownFrom.DataBind();
        DropdownFrom.DataTextField = "Area_Mst_Bp_Name";
        DropdownFrom.DataValueField = "Area_Mst_Bp_Flow_Id";
        DropdownFrom.SelectedValue = null;
        DropdownFrom.DataBind();
        DropdownFrom.Items.Insert(0, "--Select--");



        string com2 = "Select * from Conv_Area_Master";
        SqlDataAdapter adpt2 = new SqlDataAdapter(com2, con);
        DataTable dt2 = new DataTable();
        adpt2.Fill(dt2);
        DropDownTo.DataSource = dt2;
        DropDownTo.DataBind();
        DropDownTo.DataTextField = "Area_Mst_Bp_Name";
        DropDownTo.DataValueField = "Area_Mst_Bp_Flow_Id";
        DropDownTo.SelectedValue = null;
        DropDownTo.DataBind();
        DropDownTo.Items.Insert(0, "--Select--");


    }
    protected void btnAddKm_Click(object sender, EventArgs e)
    {
        
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Conv_Area_Master where Area_Mst_Bp_Flow_Id = '" + DropdownFrom.SelectedValue + "'", con1);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                kmfrom = dt.Rows[0]["Area_Mst_Bp_Name"].ToString();

            }
            con1.Close();

            con1.Open();
            SqlCommand cmd01 = new SqlCommand("select * from Conv_Area_Master where Area_Mst_Bp_Flow_Id = '" + DropdownFrom.SelectedValue + "'", con1);
            SqlDataAdapter adapt01 = new SqlDataAdapter(cmd01);
            DataTable dt01 = new DataTable();
            adapt01.Fill(dt01);
            if (dt01.Rows.Count > 0)
            {
                kmto = dt01.Rows[0]["Area_Mst_Bp_Name"].ToString();

            }
            con1.Close();
            string addmes, updatemes;
            updatemes = "Data Updated Successfully";
            addmes = "Data Added Successfully";
            DateTime now = DateTime.Now;
            SqlConnection con5 = new SqlConnection(str);
            string com = "select * from Conv_Km_Master where Km_Mst_From = '" + kmfrom + "' and Km_Mst_To = '" + kmto + "' and Km_Mst_Km ='" + txtkmnumber.Text + "' and Km_Mst_From_Name = '"+ kmfrom +"' and Km_Mst_To_Name = '"+kmto+"'";
            SqlCommand cmd3 = new SqlCommand(com, con5);
            DataTable mlist = new DataTable();
            //string com = "select * from Conv_State where State_Name = '" + txtstatename.Text + "'";
            adapt5 = new SqlDataAdapter(cmd3);
            adapt5.Fill(mlist);
            con5.Open();
            if (mlist.Rows.Count == 0)
            {
            if (btnAddKm.Text == "Update Km")
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand("Conv_Km_Master_Proc"))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "UPDATE");
                        cmd.Parameters.AddWithValue("@km_Mst_Id", ViewState["id"].ToString());
                        cmd.Parameters.AddWithValue("@Km_Mst_From", DropdownFrom.SelectedValue);
                        cmd.Parameters.AddWithValue("@Km_Mst_To", DropDownTo.SelectedValue);
                        cmd.Parameters.AddWithValue("@Km_Mst_From_Name", kmfrom);
                        cmd.Parameters.AddWithValue("@Km_Mst_To_Name", kmto);
                        cmd.Parameters.AddWithValue("@Km_Mst_Km", txtkmnumber.Text);
                        cmd.Parameters.AddWithValue("@Km_Mst_Status", "T");
                        cmd.Parameters.AddWithValue("@Km_Mst_Datetime", now);
                        cmd.Parameters.AddWithValue("@Km_Mst_Get_User", Session["username"].ToString());
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
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand("Conv_Km_Master_Proc"))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "INSERT");
                        cmd.Parameters.AddWithValue("@Km_Mst_From", DropdownFrom.SelectedValue);
                        cmd.Parameters.AddWithValue("@Km_Mst_To", DropDownTo.SelectedValue);
                        cmd.Parameters.AddWithValue("@Km_Mst_From_Name", kmfrom);
                        cmd.Parameters.AddWithValue("@Km_Mst_To_Name", kmto);
                        cmd.Parameters.AddWithValue("@Km_Mst_Km", txtkmnumber.Text);
                        cmd.Parameters.AddWithValue("@Km_Mst_Status", "T");
                        cmd.Parameters.AddWithValue("@Km_Mst_Datetime", now);
                        cmd.Parameters.AddWithValue("@Km_Mst_Get_User", Session["username"].ToString());
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
            string errormes = "Data Already Entered";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + errormes + "','','error')", true);
        }
        con5.Close();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
    {
        btnAddKm.Text = "Update Km";
        ImageButton btnedit = (ImageButton)(sender);
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Conv_Km_Master where Km_Mst_Id ='" + btnedit.CommandArgument.ToString() + "'", con);

        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtkmnumber.Text = dt.Rows[0]["Km_Mst_Km"].ToString();
            SqlCommand cmd2 = new SqlCommand("select * from Conv_Area_Master where Area_Mst_Bp_Flow_Id ='" + dt.Rows[0]["Km_Mst_From"] + "'", con);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd2);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                DropdownFrom.ClearSelection();
                ListItem selected = DropdownFrom.Items.FindByText(dt1.Rows[0]["Area_Mst_Bp_Name"].ToString());
                selected.Selected = true;
            }

            SqlCommand cmd02 = new SqlCommand("select * from Conv_Area_Master where Area_Mst_Bp_Flow_Id='" + dt.Rows[0]["Km_Mst_To"] + "'", con);
            SqlDataAdapter adapt01 = new SqlDataAdapter(cmd02);
            DataTable dt01 = new DataTable();
            adapt01.Fill(dt01);
            if (dt01.Rows.Count > 0)
            {
                DropDownTo.ClearSelection();
                ListItem selected = DropDownTo.Items.FindByText(dt01.Rows[0]["Area_Mst_Bp_Name"].ToString());
                selected.Selected = true;
            }
        }

        ViewState["id"] = btnedit.CommandArgument.ToString();
    }
    protected void btnImgDel_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnDel = (ImageButton)(sender);
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Km_Master_Proc"))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@Km_Mst_Id", btnDel.CommandArgument.ToString());
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
    private void ClearData()
    {
        DropdownFrom.SelectedIndex = 0;
        DropDownTo.SelectedIndex = 0;
        txtkmnumber.Text = "";
        btnAddKm.Text = "Insert Km";
    }
}