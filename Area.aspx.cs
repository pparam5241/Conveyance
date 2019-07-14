using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Area : System.Web.UI.Page
{
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlCommand cmd;
    SqlDataAdapter adapt,adapt5;
    public int ID = 0;
    string insmes, updmes, delmes;
    string areatype,areastate,areacity;
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
        cmd = new SqlCommand("select * from Conv_Area_Master", con);
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        con.Close();
        string com = "Select * from Conv_Misc where Misc_Table_Name = 'Conv_Area_Master'";
        SqlDataAdapter adpt1 = new SqlDataAdapter(com, con);
        DataTable dt1 = new DataTable();
        adpt1.Fill(dt1);
        ddlmsttype.DataSource = dt1;
        ddlmsttype.DataBind();
        ddlmsttype.DataTextField = "Misc_Field_Name";
        ddlmsttype.DataValueField = "Misc_Id";
        //ddlmsttype.SelectedValue = null;
        ddlmsttype.DataBind();
        ddlmsttype.Items.Insert(0, "--Select--");
        string com2 = "Select * from Conv_State";
        SqlDataAdapter adpt2 = new SqlDataAdapter(com2, con);
        DataTable dt2 = new DataTable();
        adpt2.Fill(dt2);
        ddlstate.DataSource = dt2;
        ddlstate.DataBind();
        ddlstate.DataTextField = "State_Name";
        ddlstate.DataValueField = "State_Flow_Id";
        //ddlstate.SelectedValue = null;
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, "--Select--");
    }
    protected void btnAddArea_Click(object sender, EventArgs e)
    {
        
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Conv_Misc where Misc_Id = '" + ddlmsttype.SelectedValue + "'", con1);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                areatype = dt1.Rows[0]["Misc_Field_Name"].ToString();

            }
            con1.Close();

            SqlConnection con2 = new SqlConnection(str);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("select * from Conv_State where State_Flow_Id = '" + ddlstate.SelectedValue + "'", con2);
            SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapt2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                areastate = dt2.Rows[0]["State_Name"].ToString();

            }
            con2.Close();


            SqlConnection con3 = new SqlConnection(str);
            con3.Open();
            SqlCommand cmd3 = new SqlCommand("select * from Conv_City where City_Flow_Id = '" + ddlcity.SelectedValue + "'", con3);
            SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            adapt3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                areacity = dt3.Rows[0]["City_Name"].ToString();
            }
            con2.Close();
            string addmes, updatemes;
            DateTime now = DateTime.Now;


            SqlConnection con01 = new SqlConnection(str);
            DataTable mlist = new DataTable();
            string com = "select * from Conv_Area_Master where Area_Mst_Bp_Name ='" + txtareaname.Text + "' and Area_Mst_Type = '"+ areatype +"' and Area_Mst_State_Flow_Id = '"+ areastate +"' and Area_Mst_City_Flow_id = '" + areacity + "'";
            SqlCommand cmd5 = new SqlCommand(com, con01); 
            adapt5 = new SqlDataAdapter(cmd5);
            adapt5.Fill(mlist);
            con01.Close();

            con01.Open();
            if (mlist.Rows.Count == 0)
            {
                if (btnAddArea.Text == "Update Area")
                {
                    using (SqlConnection con = new SqlConnection(str))
                    {
                        using (SqlCommand cmd = new SqlCommand("Conv_Area_Master_Proc"))
                        {
                            updatemes = "Data Updated Successfully";
                            con.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Action", "UPDATE");
                            cmd.Parameters.AddWithValue("@Area_Mst_Code", ViewState["id"].ToString());
                            cmd.Parameters.AddWithValue("@Area_Mst_Type", areatype);
                            cmd.Parameters.AddWithValue("@Area_Mst_State_Flow_Id", areastate);
                            cmd.Parameters.AddWithValue("@Area_Mst_City_Flow_Id", areacity);
                            cmd.Parameters.AddWithValue("@Area_Mst_Bp_Name", txtareaname.Text);
                            cmd.Parameters.AddWithValue("@Area_Mst_Status", "T");
                            cmd.Parameters.AddWithValue("@Area_Mst_Datetime", now);
                            cmd.Parameters.AddWithValue("@Area_Mst_Get_User", Session["username"].ToString());
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
                        using (SqlCommand cmd = new SqlCommand("Conv_Area_Master_Proc"))
                        {
                            addmes = "Data Added Successfully";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Action", "INSERT");
                            cmd.Parameters.AddWithValue("@Area_Mst_Type", areatype);
                            cmd.Parameters.AddWithValue("@Area_Mst_State_Flow_Id", areastate);
                            cmd.Parameters.AddWithValue("@Area_Mst_City_Flow_Id", areacity);
                            cmd.Parameters.AddWithValue("@Area_Mst_Bp_Name", txtareaname.Text);
                            cmd.Parameters.AddWithValue("@Area_Mst_Status", "T");
                            cmd.Parameters.AddWithValue("@Area_Mst_Datetime", now);
                            cmd.Parameters.AddWithValue("@Area_Mst_Get_User", Session["username"].ToString());
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
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Area Already Entered')", true);
        }
        con01.Close();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void Dropdown1_SelectedIndexChanged(object sender, EventArgs e)
    {
        onchangecity();
    }

    private void onchangecity()
    {
        SqlConnection con = new SqlConnection(str);
        string com2 = "SELECT * FROM Conv_City where State_Flow_Id = '" + ddlstate.SelectedValue + "'";
        SqlDataAdapter adpt2 = new SqlDataAdapter(com2, con);
        DataTable dt2 = new DataTable();
        adpt2.Fill(dt2);
        ddlcity.DataSource = dt2;
        ddlcity.DataBind();
        ddlcity.DataTextField = "City_Name";
        ddlcity.DataValueField = "City_Flow_Id";
        //Dropdown2.SelectedValue = null;
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, "--Select--");
    }
    protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
    {
        btnAddArea.Text = "Update Area";
        ImageButton btnedit = (ImageButton)(sender);
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Conv_Area_Master where Area_Mst_Code ='" + btnedit.CommandArgument.ToString() + "'", con);

        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtareaname.Text = dt.Rows[0]["Area_Mst_Bp_Name"].ToString();
            //txtmiscfieldvalue.Text = dt.Rows[0]["Misc_Field_Value"].ToString();

            SqlCommand cmd2 = new SqlCommand("select * from Conv_Misc where Misc_Field_Name ='" + dt.Rows[0]["Area_Mst_Type"] + "'", con);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd2);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                ddlmsttype.ClearSelection();
                ListItem selected1 = ddlmsttype.Items.FindByText(dt1.Rows[0]["Misc_Field_Name"].ToString());
                selected1.Selected = true;

            }


            SqlCommand cmd3 = new SqlCommand("select * from Conv_State where State_Name ='" + dt.Rows[0]["Area_Mst_State_Flow_Id"] + "'", con);
            SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            adapt3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                ddlstate.ClearSelection();
                ListItem selected2 = ddlstate.Items.FindByText(dt3.Rows[0]["State_Name"].ToString());
                selected2.Selected = true;

                onchangecity();
                SqlCommand cmd4 = new SqlCommand("select * from Conv_City where City_Name ='" + dt.Rows[0]["Area_Mst_City_Flow_Id"] + "'", con);
                SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
                DataTable dt4 = new DataTable();
                adapt4.Fill(dt4);
                if (dt4.Rows.Count > 0)
                {
                    ddlcity.ClearSelection();
                    ListItem selected3 = ddlcity.Items.FindByText(dt4.Rows[0]["City_Name"].ToString());
                    selected3.Selected = true;
                }
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
            using (SqlCommand cmd = new SqlCommand("Conv_Area_Master_Proc"))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@Area_Mst_Code", btnDel.CommandArgument.ToString());
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                //delmes = "Data Deleted Successfully";
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + delmes + "','','success')", true);
                //Response.Write("<script>alert('Record Deleted Successfully!')</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + delmes + "','','success')", true);
                DisplayData();
                con.Close();
            }
        }
    }
    private void ClearData()
    {
        ddlmsttype.SelectedIndex = 0;
        ddlstate.SelectedIndex = 0;
        ddlcity.Items.Clear();
        txtareaname.Text = "";
        btnAddArea.Text = "Insert Area";
    }
}