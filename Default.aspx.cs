using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{

    SqlFunction databaseFunc = new SqlFunction();
        string qry = "";
        DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["username"] != null)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
            {
                //double qty = 0.0;
                string loginmes = "Log In Successful";
                qry = "";
                qry = "select * from Conv_Employee_Master where Emp_code = '" + txtUserName.Text + "' and Emp_Mst_Password='" + txtPassward.Text.Trim() + "'";
                ds = databaseFunc.getdata(qry);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    qry+= " and (Emp_Mst_Status = 'T' or Emp_Mst_Emp_Type= 'A')";
                    ds = databaseFunc.getdata(qry);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["username"] = txtUserName.Text.Trim();
                        //ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('Logged In Successful!');window.location ='Dashboard.aspx';",true);
                        //Response.Redirect("Dashboard.aspx");
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Logged In SuccessFul!')", true);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + loginmes + "','','success');window.location = 'Dashboard.aspx';", true);
                    }
                    else {
                        string errormes = "You have no admin rights!";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + errormes + "','','error')", true);
                    }
                }
                else {
                    lblError.Text = "Username or password may be wrong";
                    txtUserName.Focus();
                }
                }   
            catch (Exception ex)
            {
                string errormes = "User name Or Password Is Invalid Type";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "sweetAlert('" + errormes + "','','error')", true);
            }
        }
    }
