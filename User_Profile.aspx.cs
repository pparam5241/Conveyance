using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Profile : System.Web.UI.Page
{
    string deptname,statename;
    string str1="";
    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlCommand cmd1;
    string abc;
    SqlDataAdapter adapt1, adapt5;
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
        string com2 = "Select * from Conv_State";
        SqlDataAdapter adpt2 = new SqlDataAdapter(com2, con);
        DataTable dt2 = new DataTable();
        adpt2.Fill(dt2);
        DropDownList1.DataSource = dt2;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "State_Name";
        DropDownList1.DataValueField = "State_Id";
        DropDownList1.SelectedValue = null;
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "--Select--");

        SqlCommand cmd = new SqlCommand("select distinct Misc_Field_Name,Misc_Field_Value from Conv_Misc where Misc_Colomn_Name = 'Fuel_Mst_Vehical_Type'", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        CheckBoxList1.DataSource = dt;
        CheckBoxList1.DataTextField = "Misc_Field_Value";
        CheckBoxList1.DataValueField = "Misc_Field_Name";
        CheckBoxList1.DataBind();

        string com3 = "Select * from Conv_Department";
        SqlDataAdapter adpt3 = new SqlDataAdapter(com3, con);
        DataTable dt3 = new DataTable();
        adpt3.Fill(dt3);
        DropDownList2.DataSource = dt3;
        DropDownList2.DataBind();
        DropDownList2.DataTextField = "Dept_Name";
        DropDownList2.DataValueField = "Dept_Id";
        DropDownList2.SelectedValue = null;
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "--Select--");

        con.Open();
        SqlCommand cmd01 = new SqlCommand("select * from Conv_Employee_Master where Emp_code ='" + Session["username"].ToString() + "'", con);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd01);
        DataTable dt01 = new DataTable();
        adapt.Fill(dt01);
        if (dt.Rows.Count > 0)
        {
            TextBox1.Text = dt01.Rows[0]["Emp_Mst_User_Name"].ToString();
            TextBox3.Text = dt01.Rows[0]["Emp_Mst_Full_Name"].ToString();
            TextBox4.Text = dt01.Rows[0]["Emp_Mst_Location"].ToString();
            TextBox5.Text = dt01.Rows[0]["Emp_Mst_Is_Active"].ToString();
            TextBox6.Text = dt01.Rows[0]["Emp_Mst_Joining_Date"].ToString();
            TextBox7.Text = dt01.Rows[0]["Emp_Mst_Status"].ToString();
            TextBox8.Text = dt01.Rows[0]["Emp_Mst_Emp_Type"].ToString();

            SqlCommand cmd2 = new SqlCommand("select * from Conv_State where State_Name ='" + dt01.Rows[0]["Emp_Mst_State"] + "'", con);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd2);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                DropDownList1.ClearSelection();
                ListItem selected = DropDownList1.Items.FindByText(dt1.Rows[0]["State_Name"].ToString());
                selected.Selected = true;

            }
            SqlCommand cmd3 = new SqlCommand("select * from Conv_Department where Dept_Name ='" + dt01.Rows[0]["Emp_Mst_Department"] + "'", con);
            SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
            DataTable dt03 = new DataTable();
            adapt3.Fill(dt03);
            if (dt03.Rows.Count > 0)
            {
                DropDownList2.ClearSelection();
                ListItem selected = DropDownList2.Items.FindByText(dt03.Rows[0]["Dept_Name"].ToString());
                selected.Selected = true;
            }
            string strValue = dt01.Rows[0]["Emp_Mst_Vehical_Type"].ToString();
            string[] strArray = strValue.Split(',');

            for (int i = 0; i <= strArray.Length - 1; i++)
            {
                string cntry = strArray[i];
                SqlConnection con1 = new SqlConnection(str);
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from Conv_Misc where Misc_Field_Name = '" + cntry + "'", con1);
                SqlDataAdapter adapt10 = new SqlDataAdapter(cmd1);
                DataTable dt10 = new DataTable();
                adapt10.Fill(dt10);
                if (dt10.Rows.Count > 0)
                {
                    abc = dt10.Rows[0]["Misc_Field_Value"].ToString();
                    for (int j = 0; j <= CheckBoxList1.Items.Count - 1; j++)
                    {
                        if (CheckBoxList1.Items[j].Text == abc)
                        {
                            CheckBoxList1.Items[j].Selected = true;
                        }
                    }

                }
                con1.Close();
            }
        }
    }
    protected void UpdateProfile_Click(object sender, EventArgs e)
    {
        
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected == true)
            {
                SqlConnection con4 = new SqlConnection(str);
                con4.Open();
                SqlCommand cmd4 = new SqlCommand("select * from Conv_Misc where Misc_Field_Value = '" + CheckBoxList1.Items[i] + "'", con4);
                SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
                DataTable dt4 = new DataTable();
                adapt4.Fill(dt4);
                if (dt4.Rows.Count > 0)
                {
                    str1 += dt4.Rows[0]["Misc_Field_Name"].ToString() + ",";
                }
                con4.Close();
            }
        }

        SqlConnection con1 = new SqlConnection(str);
        con1.Open();
        SqlCommand cmd1 = new SqlCommand("select * from Conv_State where State_Id = '" + DropDownList1.SelectedValue + "'", con1);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            statename = dt1.Rows[0]["State_Name"].ToString();

        }
        con1.Close();
        
        SqlConnection con2 = new SqlConnection(str);
        con2.Open();
        SqlCommand cmd5 = new SqlCommand("select * from Conv_Department where Dept_Id = '" + DropDownList2.SelectedValue + "'", con2);
        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd5);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            deptname = dt2.Rows[0]["Dept_Name"].ToString();

        }
        con2.Close();
        DateTime now = DateTime.Now;
        if (profimg.HasFile)
        {
            string imgpro = System.IO.Path.GetFileName(profimg.PostedFile.FileName);
            profimg.PostedFile.SaveAs(Server.MapPath("~/images/") + imgpro);


            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("Conv_Employee_Master_Proc"))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action1", "UPDATE2");
                    cmd.Parameters.AddWithValue("@Action2", "UPDATE2");
                    cmd.Parameters.AddWithValue("@Emp_Name", Session["username"].ToString());
                    cmd.Parameters.AddWithValue("@Emp_Mst_User_Name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Emp_Mst_Full_Name", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Emp_Mst_State", statename);
                    cmd.Parameters.AddWithValue("@Emp_Mst_Department", deptname);
                    cmd.Parameters.AddWithValue("@Emp_Mst_Location", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@Emp_Mst_Is_Active", TextBox5.Text);
                    cmd.Parameters.AddWithValue("@Emp_Mst_Joining_Date", TextBox6.Text);
                    cmd.Parameters.AddWithValue("@Emp_Mst_Vehical_Type", str1);
                    cmd.Parameters.AddWithValue("@Emp_Mst_Status", "T");
                    cmd.Parameters.AddWithValue("@Emp_Mst_Datetime", now);
                    cmd.Parameters.AddWithValue("@Emp_Mst_Get_User", Session["username"].ToString());
                    cmd.Parameters.AddWithValue("@Emp_Profile_Img", imgpro);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    string loginmes = "Profile Updated Successfully!";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + updatemes + "','','success')", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + loginmes + "','','success');window.location = 'Dashboard.aspx';", true);
                    this.DisplayData();
                    con.Close();
                }
            }
        }
        else
        {
            string loginmes = "File Not been Selected Choose Profile First!";
            profimg.Focus();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + loginmes + "','','error');window.location = 'Dashboard.aspx';", true);
        }


    }

}