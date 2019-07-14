using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fuel_Type : System.Web.UI.Page
{
    String vehicalname;
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlCommand cmd1;
    SqlDataAdapter adapt1,adapt5;
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        TextBox8.Text = now.ToString();
        TextBox7.Text = now.ToString();
        if (!IsPostBack)
        {
            DisplayData();
        }
    }

    private void DisplayData()
    {
        SqlConnection con = new SqlConnection(str);
        con.Open();
        DataTable dt1 = new DataTable();
        cmd1 = new SqlCommand("select * from Conv_Fuel_Type_Master", con);
        adapt1 = new SqlDataAdapter(cmd1);
        adapt1.Fill(dt1);
        Repeater1.DataSource = dt1;
        Repeater1.DataBind();
        con.Close();
        string com2 = "Select * from Conv_Misc where Misc_Colomn_Name = 'Fuel_Mst_Vehical_Type'";
        SqlDataAdapter adpt2 = new SqlDataAdapter(com2, con);
        DataTable dt2 = new DataTable();
        adpt2.Fill(dt2);
        Dropdown1.DataSource = dt2;
        Dropdown1.DataBind();
        Dropdown1.DataTextField = "Misc_Field_Value";
        Dropdown1.DataValueField = "Misc_Field_Name";
        Dropdown1.SelectedValue = null;
        Dropdown1.DataBind();
        Dropdown1.Items.Insert(0, "--Select--");
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.ClearData();
        DisplayData();
    }
    protected void btnAddFuel_Click(object sender, EventArgs e)
    {
        String source1 = TextBox7.Text;
        String result1 = String.Join("/", source1.Split('/').Reverse());

        String source2 = TextBox8.Text;
        String result2 = String.Join("/", source2.Split('-').Reverse());
        

            DateTime now = DateTime.Now;
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Conv_Misc where Misc_Field_Name = '" + Dropdown1.SelectedValue + "'", con1);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                vehicalname = dt1.Rows[0]["Misc_Field_Name"].ToString();

            }
            con1.Close();
            string addmes, updatemes;
            updatemes = "Data Updated Successfully";
            addmes = "Data Added Successfully";

        SqlConnection con3 = new SqlConnection(str);
        string com = "select * from Conv_Fuel_Type_Master where Fuel_Mst_From_Date =  '" + result1 + "'and Fuel_Mst_To_Date =  '" + result2 + "' and Fuel_Mst_Rate = '" + TextBox9.Text + "' and Fuel_Mst_Fuel_Rate = '" + TextBox10.Text + "' and Fuel_Mst_Milege = '" + TextBox11.Text + "' and Fuel_Mst_Vehical_Type = '" + vehicalname + "'";
        SqlCommand cmd3 = new SqlCommand(com, con3);
        DataTable mlist = new DataTable();
        //string com = "select * from Conv_State where State_Name = '" + txtstatename.Text + "'";
        adapt5 = new SqlDataAdapter(cmd3);
        adapt5.Fill(mlist);
        con3.Open();
        if (mlist.Rows.Count == 0)
        {

            if (btnAddFuel.Text == "Update Fuel")
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand("Conv_Fuel_Type_Master_Proc"))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "UPDATE");
                        cmd.Parameters.AddWithValue("@Fuel_Id", ViewState["id"].ToString());
                        cmd.Parameters.AddWithValue("@Fuel_Mst_From_Date", TextBox7.Text);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_To_Date", TextBox8.Text);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Rate", TextBox9.Text);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Fuel_Rate", TextBox10.Text);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Milege", TextBox11.Text);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Vehical_Type", vehicalname);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Status", "T");
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Datetime", now);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Get_User", Session["username"].ToString());
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + updatemes + "','','success')", true);
                        this.DisplayData();
                        this.ClearData();
                        con.Close();
                    }
                }
            }
            else
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand("Conv_Fuel_Type_Master_Proc"))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "INSERT");
                        cmd.Parameters.AddWithValue("@Fuel_Mst_From_Date", TextBox7.Text);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_To_Date", TextBox8.Text);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Rate", TextBox9.Text);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Fuel_Rate", TextBox10.Text);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Milege", TextBox11.Text);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Vehical_Type", vehicalname);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Status", "T");
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Datetime", now);
                        cmd.Parameters.AddWithValue("@Fuel_Mst_Get_User", Session["username"].ToString());
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
            string errormes = "Data Already Exist";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + errormes + "','','error')", true);
        }
    }
    protected void btnImgDel_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnDel = (ImageButton)(sender);
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Fuel_Type_Master_Proc"))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@Fuel_Id", btnDel.CommandArgument.ToString());
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
    protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
    {
        this.ClearData();
        btnAddFuel.Text = "Update Fuel";
        ImageButton btnedit = (ImageButton)(sender);
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Conv_Fuel_Type_Master where Fuel_Id ='" + btnedit.CommandArgument.ToString() + "'", con);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBox7.Text = dt.Rows[0]["Fuel_Mst_From_Date"].ToString();
            TextBox8.Text = dt.Rows[0]["Fuel_Mst_To_Date"].ToString();
            TextBox9.Text = dt.Rows[0]["Fuel_Mst_Rate"].ToString();
            TextBox10.Text = dt.Rows[0]["Fuel_Mst_Fuel_Rate"].ToString();
            TextBox11.Text = dt.Rows[0]["Fuel_Mst_Milege"].ToString();

            SqlCommand cmd2 = new SqlCommand("select * from Conv_Misc where Misc_Field_Name ='" + dt.Rows[0]["Fuel_Mst_Vehical_Type"] + "'", con);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd2);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                Dropdown1.ClearSelection();
                ListItem selected = Dropdown1.Items.FindByText(dt1.Rows[0]["Misc_Field_Value"].ToString());
                selected.Selected = true;
            }
        }
        ViewState["id"] = btnedit.CommandArgument.ToString();
    }

    private void ClearData()
    {
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        Dropdown1.SelectedIndex = 0;

    }
}