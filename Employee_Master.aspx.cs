using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employee_Master : System.Web.UI.Page
{
    string statename, deptname, jobstatus, imgpro;
    string str1 = "";

    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlCommand cmd1;
    SqlDataAdapter adapt1,adapt5;
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox2.TextMode = TextBoxMode.Password;
        TextBox6.Text = DateTime.Now.ToString();
        if (!IsPostBack)
        {
            DisplayData();
        }

    }
    private void DisplayData()
    {
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 Emp_code FROM Conv_Employee_Master ORDER BY Emp_code DESC", con);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            // profimg. = dt.Rows[0]["Emp_Profile_Img"].ToString();
            TextBox8.Text = (1+Int32.Parse(dt.Rows[0]["Emp_code"].ToString())).ToString();
            Label1.Text = "Last Code = " + dt.Rows[0]["Emp_code"].ToString();
        }
        con.Close();

        con.Open();
        DataTable dt1 = new DataTable();
       // cmd1 = new SqlCommand("Select A.Emp_Mst_User_Code,B.Misc_Field_Value,B.Misc_Field_Name,* From Conv_Employee_Master A Inner Join Conv_Misc B on ',' + A.Emp_Mst_Vehical_Type + ',' Like '%,'+ B.Misc_Field_Name + ',%' And Misc_Colomn_Name = 'Fuel_Mst_Vehical_Type' Where 1=1", con);
        cmd1 = new SqlCommand("select * from Conv_Employee_Master_View", con);
        adapt1 = new SqlDataAdapter(cmd1);
        adapt1.Fill(dt1);
        Repeater1.DataSource = dt1;
        Repeater1.DataBind();
        con.Close();



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

        SqlCommand cmd10 = new SqlCommand("select distinct Misc_Field_Name,Misc_Field_Value from Conv_Misc where Misc_Colomn_Name = 'Fuel_Mst_Vehical_Type' and Misc_Table_Name = 'Conv_Fuel_Type_Master'", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd10);
        DataTable dt10 = new DataTable();
        sda.Fill(dt10);
        CheckBoxList1.DataSource = dt10;
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
        DateTime now = DateTime.Now;
        TextBox6.Text = now.ToString();

        SqlCommand cmd2 = new SqlCommand("select distinct * from Conv_Misc where Misc_Colomn_Name = 'Emp_Job_Status'", con);
        SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
        DataTable dt02 = new DataTable();
        sda2.Fill(dt02);
        DropDownList4.DataSource = dt02;
        DropDownList4.DataBind();
        DropDownList4.DataTextField = "Misc_Field_Value";
        DropDownList4.DataValueField = "Misc_Field_Name";
        DropDownList4.SelectedValue = null;
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, "--Select--");


    }
    protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
    {
        
        string abc;
        this.ClearData();
        btnAddEmp.Text = "Update Employee";
        ImageButton btnedit = (ImageButton)(sender);
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Conv_Employee_Master where Emp_Mst_User_Code ='" + btnedit.CommandArgument.ToString() + "'", con);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            // profimg. = dt.Rows[0]["Emp_Profile_Img"].ToString();
            TextBox1.Text = dt.Rows[0]["Emp_Mst_User_Name"].ToString();
            TextBox2.Text = dt.Rows[0]["Emp_Mst_Password"].ToString();
            TextBox3.Text = dt.Rows[0]["Emp_Mst_Full_Name"].ToString();
            TextBox4.Text = dt.Rows[0]["Emp_Mst_Location"].ToString();
            TextBox5.Text = dt.Rows[0]["Emp_Mst_Is_Active"].ToString();
            TextBox6.Text = dt.Rows[0]["Emp_Mst_Joining_Date"].ToString();
            TextBox9.Text = dt.Rows[0]["Emp_Mst_Birth_Date"].ToString();
            TextBox7.Text = dt.Rows[0]["Emp_Salary"].ToString();
            TextBox8.Text = dt.Rows[0]["Emp_code"].ToString();

            SqlCommand cmd2 = new SqlCommand("select * from Conv_State where State_Name ='" + dt.Rows[0]["Emp_Mst_State"] + "'", con);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd2);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                DropDownList1.ClearSelection();
                ListItem selected = DropDownList1.Items.FindByText(dt1.Rows[0]["State_Name"].ToString());
                selected.Selected = true;

            }
            SqlCommand cmd02 = new SqlCommand("select * from Conv_Misc where Misc_Field_Value ='" + dt.Rows[0]["Emp_Job_Status"] + "'", con);
            SqlDataAdapter adapt01 = new SqlDataAdapter(cmd02);
            DataTable dt01 = new DataTable();
            adapt01.Fill(dt01);
            if (dt01.Rows.Count > 0)
            {
                DropDownList4.ClearSelection();
                ListItem selected = DropDownList4.Items.FindByText(dt01.Rows[0]["Misc_Field_Value"].ToString());
                selected.Selected = true;

            }

            DropDownList3.SelectedValue = dt.Rows[0]["Emp_Mst_Emp_Type"].ToString();
            SqlCommand cmd3 = new SqlCommand("select * from Conv_Department where Dept_Name ='" + dt.Rows[0]["Emp_Mst_Department"] + "'", con);
            SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            adapt3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                DropDownList2.ClearSelection();
                ListItem selected = DropDownList2.Items.FindByText(dt3.Rows[0]["Dept_Name"].ToString());
                selected.Selected = true;
            }
            string strValue = dt.Rows[0]["Emp_Mst_Vehical_Type"].ToString();
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
            string selectradio= dt.Rows[0]["Emp_Mst_Status"].ToString().Trim();

            if (selectradio == "F")
            {
                RadioButtonList1.Items[0].Selected = true;
            }
            else if(selectradio == "T")
            {
                RadioButtonList1.Items[1].Selected = true;
            }
        }
        ViewState["id"] = btnedit.CommandArgument.ToString();
        TextBox2.TextMode = TextBoxMode.SingleLine;
        this.TextBox2.Text = TextBox2.Text;
        TextBox8.Enabled = false;
    }
    protected void btnImgDel_Click(object sender, ImageClickEventArgs e)
    {
        string delmes = "Data Deleted Successfully";
        ImageButton btnDel = (ImageButton)(sender);
        using (SqlConnection con = new SqlConnection(str))
        {
            using (SqlCommand cmd = new SqlCommand("Conv_Employee_Master_Proc"))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action1", "DELETE");
                cmd.Parameters.AddWithValue("@Action2", "DELETE");
                cmd.Parameters.AddWithValue("@Emp_Mst_User_Code", btnDel.CommandArgument.ToString());
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
    protected void btnAddEmp_Click(object sender, EventArgs e)
    {


        string value = RadioButtonList1.SelectedItem.Value.ToString();
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

            if (profimg.HasFile)
            {
                imgpro = System.IO.Path.GetFileName(profimg.PostedFile.FileName);
                profimg.PostedFile.SaveAs(Server.MapPath("~/images/") + imgpro);
            }

            SqlConnection con002 = new SqlConnection(str);
            con002.Open();
            SqlCommand cmd05 = new SqlCommand("select * from Conv_Misc where Misc_Field_Name = '" + DropDownList4.SelectedValue + "'", con002);
            SqlDataAdapter adapt02 = new SqlDataAdapter(cmd05);
            DataTable dt02 = new DataTable();
            adapt02.Fill(dt02);
            string s;
            if (dt02.Rows.Count > 0)
            {
                jobstatus = dt02.Rows[0]["Misc_Field_Value"].ToString();

            }
            con002.Close();



            DateTime now = DateTime.Now;
            string addmes, updatemes;
            string type = DropDownList3.SelectedValue.ToString();
            updatemes = "Data Updated Successfully";
            addmes = "Data Added Successfully";


            SqlConnection con02 = new SqlConnection(str);
            DataTable mlist = new DataTable();
            //statename deptnamejobstatus
            string com = "select * from Conv_Employee_Master where Emp_Mst_User_Name = '" + TextBox1.Text + "' and Emp_Mst_Full_Name = '" + TextBox3.Text + "' and Emp_Mst_State = '" + statename + "' and Emp_Mst_Department = '" + deptname + "' and Emp_Mst_Location = '" + TextBox4.Text + "'and Emp_Mst_Is_Active = '" + TextBox5.Text + "' and Emp_Mst_Vehical_Type = '" + str1 + "' and Emp_Mst_Status = '" + value + "' and Emp_Mst_Emp_Type = '"+ type +"'";
            SqlCommand cmd2 = new SqlCommand(com, con02);
            adapt5 = new SqlDataAdapter(cmd2);
            adapt5.Fill(mlist);
            con02.Close();

            con02.Open();
            if (mlist.Rows.Count == 0)
            {



                if (jobstatus.Trim() == "Probation")
                {
                    if (btnAddEmp.Text == "Update Employee")
                    {
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            using (SqlCommand cmd = new SqlCommand("Conv_Employee_Master_Proc"))
                            {
                                con.Open();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Action1", "Probation");
                                cmd.Parameters.AddWithValue("@Action2", "UPDATE");
                                cmd.Parameters.AddWithValue("@Emp_Mst_User_Code", ViewState["id"].ToString());
                                cmd.Parameters.AddWithValue("@Emp_Mst_User_Name", TextBox1.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Password", TextBox2.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Full_Name", TextBox3.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_State", statename);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Department", deptname);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Location", TextBox4.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Is_Active", TextBox5.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Vehical_Type", str1);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Datetime", now);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Get_User", Session["username"].ToString());
                                cmd.Parameters.AddWithValue("@Emp_Mst_Status_Login", value);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Emp_Type", type);
                                cmd.Parameters.AddWithValue("@Emp_Job_Status", jobstatus);
                                cmd.Parameters.AddWithValue("@Emp_Salary", TextBox7.Text);
                                cmd.Parameters.AddWithValue("@Emp_Salary_Per_Hour", Convert.ToDouble(TextBox7.Text) / 150);
                                cmd.Parameters.AddWithValue("@Emp_Profile_Img", imgpro);
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
                            using (SqlCommand cmd = new SqlCommand("Conv_Employee_Master_Proc"))
                            {
                            
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Action1", "Probation");
                                cmd.Parameters.AddWithValue("@Action2", "INSERT");
                                cmd.Parameters.AddWithValue("@Emp_Code", TextBox8.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Birth_Date", TextBox9.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_User_Name", TextBox1.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Password", TextBox2.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Full_Name", TextBox3.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_State", statename);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Department", deptname);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Location", TextBox4.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Is_Active", TextBox5.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Joining_Date", TextBox6.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Vehical_Type", str1);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Datetime", now);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Get_User", Session["username"].ToString());
                                cmd.Parameters.AddWithValue("@Emp_Mst_Status_Login", value);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Emp_Type", type);
                                cmd.Parameters.AddWithValue("@Emp_Job_Status", jobstatus);
                                cmd.Parameters.AddWithValue("@Emp_Salary", TextBox7.Text);
                                cmd.Parameters.AddWithValue("@Emp_Salary_Per_Hour", Convert.ToDouble(TextBox7.Text) / 150);
                                cmd.Parameters.AddWithValue("@Emp_Profile_Img", imgpro);
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
                else if (jobstatus.Trim() == "Conformation")
                {
                    if (btnAddEmp.Text == "Update Employee")
                    {
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            using (SqlCommand cmd = new SqlCommand("Conv_Employee_Master_Proc"))
                            {
                                con.Open();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Action1", "Conformation");
                                cmd.Parameters.AddWithValue("@Action2", "UPDATE");
                                cmd.Parameters.AddWithValue("@Emp_Mst_User_Code", ViewState["id"].ToString());
                                cmd.Parameters.AddWithValue("@Emp_Mst_User_Name", TextBox1.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Password", TextBox2.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Full_Name", TextBox3.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_State", statename);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Department", deptname);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Location", TextBox4.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Is_Active", TextBox5.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Vehical_Type", str1);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Datetime", now);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Get_User", Session["username"].ToString());
                                cmd.Parameters.AddWithValue("@Emp_Mst_Status_Login", value);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Emp_Type", type);
                                cmd.Parameters.AddWithValue("@Emp_Job_Status", jobstatus);
                                cmd.Parameters.AddWithValue("@Emp_Salary", TextBox7.Text);
                                cmd.Parameters.AddWithValue("@Emp_Salary_Per_Hour", Convert.ToDouble(TextBox7.Text) / 150);
                                cmd.Parameters.AddWithValue("@Emp_Profile_Img", imgpro);
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + updatemes + "','','success')", true);
                                this.DisplayData();
                                this.ClearData();
                                con.Close();
                            }
                        }
                    }
                }
                else if (jobstatus.Trim() == "Resigned" || jobstatus.Trim() == "Terminate")
                {
                    if (btnAddEmp.Text == "Update Employee")
                    {
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            using (SqlCommand cmd = new SqlCommand("Conv_Employee_Master_Proc"))
                            {
                                con.Open();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Action1", "Resigned");
                                cmd.Parameters.AddWithValue("@Action2", "UPDATE");
                                cmd.Parameters.AddWithValue("@Emp_Mst_User_Code", ViewState["id"].ToString());
                                cmd.Parameters.AddWithValue("@Emp_Mst_User_Name", TextBox1.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Password", TextBox2.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Full_Name", TextBox3.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_State", statename);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Department", deptname);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Location", TextBox4.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Is_Active", TextBox5.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Vehical_Type", str1);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Datetime", now);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Get_User", Session["username"].ToString());
                                cmd.Parameters.AddWithValue("@Emp_Mst_Status_Login", value);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Emp_Type", type);
                                cmd.Parameters.AddWithValue("@Emp_Job_Status", jobstatus);
                                cmd.Parameters.AddWithValue("@Emp_Salary", TextBox7.Text);
                                cmd.Parameters.AddWithValue("@Emp_Salary_Per_Hour", Convert.ToDouble(TextBox7.Text) / 150);
                                cmd.Parameters.AddWithValue("@Emp_Profile_Img", imgpro);
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + updatemes + "','','success')", true);
                                this.DisplayData();
                                this.ClearData();
                                con.Close();
                            }
                        }
                    }
                }
                else if (jobstatus.Trim() == "On Notice Period")
                {
                    if (btnAddEmp.Text == "Update Employee")
                    {
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            using (SqlCommand cmd = new SqlCommand("Conv_Employee_Master_Proc"))
                            {
                                con.Open();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Action1", "On Notice Period");
                                cmd.Parameters.AddWithValue("@Action2", "UPDATE");
                                cmd.Parameters.AddWithValue("@Emp_Mst_User_Code", ViewState["id"].ToString());
                                cmd.Parameters.AddWithValue("@Emp_Mst_User_Name", TextBox1.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Password", TextBox2.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Full_Name", TextBox3.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_State", statename);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Department", deptname);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Location", TextBox4.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Is_Active", TextBox5.Text);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Vehical_Type", str1);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Datetime", now);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Get_User", Session["username"].ToString());
                                cmd.Parameters.AddWithValue("@Emp_Mst_Status_Login", value);
                                cmd.Parameters.AddWithValue("@Emp_Mst_Emp_Type", type);
                                cmd.Parameters.AddWithValue("@Emp_Job_Status", jobstatus);
                                cmd.Parameters.AddWithValue("@Emp_Salary", TextBox7.Text);
                                cmd.Parameters.AddWithValue("@Emp_Salary_Per_Hour", Convert.ToDouble(TextBox7.Text) / 150);
                                cmd.Parameters.AddWithValue("@Emp_Profile_Img", imgpro);
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + updatemes + "','','success')", true);
                                this.DisplayData();
                                this.ClearData();
                                con.Close();
                            }
                        }
                    }
                }
            }
        else
        {
            string errormes = "Employee Already Exist";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + errormes + "','','error')", true);
        }
        con02.Close();
    }

    private void ClearData()
    {
        TextBox8.Enabled = true;
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 Emp_code FROM Conv_Employee_Master ORDER BY Emp_code DESC", con);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            // profimg. = dt.Rows[0]["Emp_Profile_Img"].ToString();
            TextBox8.Text = (1 + Int32.Parse(dt.Rows[0]["Emp_code"].ToString())).ToString();
            Label1.Text = "Last Code = " + dt.Rows[0]["Emp_code"].ToString();
        }
        con.Close();
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        DropDownList4.SelectedIndex = 0;
        CheckBoxList1.ClearSelection(); 

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}