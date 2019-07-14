using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Misc : System.Web.UI.Page
{
    string obid;
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlCommand cmd;
    SqlDataAdapter adapt5;
    string misctbl,misccol;
    public string ddl;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayData();
        }
    }
    protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
    {
        btnAddMisc.Text = "Update Misc";
        ImageButton btnedit = (ImageButton)(sender);
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Conv_Misc where Misc_Id='" + btnedit.CommandArgument.ToString() + "'", con);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtmiscfieldname.Text = dt.Rows[0]["Misc_Field_Name"].ToString();
            txtmiscfieldvalue.Text = dt.Rows[0]["Misc_Field_Value"].ToString();
            
            SqlCommand cmd2 = new SqlCommand("select * from HNS_Conveyance_log.sys.tables where name ='" + dt.Rows[0]["Misc_Table_Name"] + "'", con);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd2);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                Dropdown1.ClearSelection();
                ListItem selected = Dropdown1.Items.FindByText(dt1.Rows[0]["name"].ToString());
                obid = dt1.Rows[0]["object_id"].ToString();
                selected.Selected = true;
                Ddl2change();
                SqlCommand cmd3 = new SqlCommand("select * from HNS_Conveyance_log.sys.columns where name = '" + dt.Rows[0]["Misc_Colomn_Name"] + "'", con);
                SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                adapt3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    Dropdown2.ClearSelection();
                    //Dropdown2.DataValueField = dt.Rows[0]["Misc_Colomn_Name"].ToString();
                    ListItem selected2 = Dropdown2.Items.FindByText(dt3.Rows[0]["name"].ToString());
                    selected2.Selected = true;
                }


            }

            
        }
        ViewState["id"] = btnedit.CommandArgument.ToString();
    }
    protected void btnImgDel_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnDel = (ImageButton)(sender);
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Misc_Proc"))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@Misc_Id", btnDel.CommandArgument.ToString());
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
    private void DisplayData()
    {

        SqlConnection con = new SqlConnection(str);
        con.Open();
        DataTable dt = new DataTable();
        cmd = new SqlCommand("select * from Conv_Misc", con);
        adapt5 = new SqlDataAdapter(cmd);
        adapt5.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        con.Close();
        string com = "SELECT * FROM HNS_Conveyance_log.sys.tables";
        SqlDataAdapter adpt2 = new SqlDataAdapter(com, con);
        DataTable dt2 = new DataTable();
        adpt2.Fill(dt2);
        Dropdown1.DataSource = dt2;
        Dropdown1.DataTextField = "name";
        Dropdown1.DataValueField = "object_id";
        Dropdown1.DataBind();
        Dropdown1.Items.Insert(0, "--Select--");
        //ViewState["name"] = Dropdown1.SelectedValue;


    }
    protected void btnAddMisc_Click1(object sender, EventArgs e)
    {
        
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from HNS_Conveyance_log.sys.tables where object_id = '" + Dropdown1.SelectedValue + "'", con1);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                misctbl = dt.Rows[0]["name"].ToString();
                obid = dt.Rows[0]["object_id"].ToString();
            }
            con1.Close();

            SqlConnection con2 = new SqlConnection(str);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("select name from HNS_Conveyance_log.sys.columns where column_id= '" + Dropdown2.SelectedValue + "' and object_id = '"+obid +"'", con2);
            SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapt2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                misccol = dt2.Rows[0]["name"].ToString();

            }
            con2.Close();

            string addmes, updatemes;
            updatemes = "Data Updated Successfully";
            addmes = "Data Added Successfully";
            DateTime now = DateTime.Now;

        SqlConnection con3 = new SqlConnection(str);
        string com = "select * from Conv_Misc where  Misc_Table_Name = '"+ misctbl +"' and Misc_Colomn_Name = '"+ misccol +"' and Misc_Field_Name ='" + txtmiscfieldname.Text + "' and Misc_Field_Value ='" + txtmiscfieldvalue.Text + "'";
        SqlCommand cmd3 = new SqlCommand(com, con3);
        DataTable mlist = new DataTable();
        //string com = "select * from Conv_State where State_Name = '" + txtstatename.Text + "'";
        adapt5 = new SqlDataAdapter(cmd3);
        adapt5.Fill(mlist);
        con3.Open();
        if (mlist.Rows.Count == 0)
        {
            if (btnAddMisc.Text == "Update Misc")
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand("Conv_Misc_Proc"))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "UPDATE");
                        cmd.Parameters.AddWithValue("@Misc_Id", ViewState["id"].ToString());
                        cmd.Parameters.AddWithValue("@Misc_Table_Name", misctbl);
                        cmd.Parameters.AddWithValue("@Misc_Column_Name", misccol);
                        cmd.Parameters.AddWithValue("@Misc_Field_Name", txtmiscfieldname.Text);
                        cmd.Parameters.AddWithValue("@Misc_Field_Value", txtmiscfieldvalue.Text);
                        cmd.Parameters.AddWithValue("@Misc_Datetime", now);
                        cmd.Parameters.AddWithValue("@Misc_Get_User", Session["username"].ToString());
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
                    using (SqlCommand cmd = new SqlCommand("Conv_Misc_Proc"))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "INSERT");
                        cmd.Parameters.AddWithValue("@Misc_Table_Name", misctbl);
                        cmd.Parameters.AddWithValue("@Misc_Column_Name", misccol);
                        cmd.Parameters.AddWithValue("@Misc_Field_Name", txtmiscfieldname.Text);
                        cmd.Parameters.AddWithValue("@Misc_Field_Value", txtmiscfieldvalue.Text);
                        cmd.Parameters.AddWithValue("@Misc_Status", "T");
                        cmd.Parameters.AddWithValue("@Misc_Datetime", now);
                        cmd.Parameters.AddWithValue("@Misc_Get_User", Session["username"].ToString());
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
        con3.Close();
    }
    private void ClearData()
    {
        Dropdown1.SelectedIndex = 0;
        Dropdown2.Items.Clear();
        txtmiscfieldname.Text = "";
        txtmiscfieldvalue.Text = "";
        btnAddMisc.Text = "Insert Data";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void Dropdown1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Ddl2change();
    }

    private void Ddl2change()
    {
        SqlConnection con = new SqlConnection(str);
        string com2 = "SELECT * FROM HNS_Conveyance_log.sys.columns WHERE object_id = '" + Dropdown1.SelectedValue + "'";
        SqlDataAdapter adpt2 = new SqlDataAdapter(com2, con);
        DataTable dt2 = new DataTable();
        adpt2.Fill(dt2);
        Dropdown2.DataSource = dt2;
        Dropdown2.DataBind();
        Dropdown2.DataTextField = "name";
        Dropdown2.DataValueField = "column_id";
        Dropdown2.SelectedValue = null;
        Dropdown2.DataBind();
        Dropdown2.Items.Insert(0, "--Select--");
    }


}