<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Employee_Master.aspx.cs" Inherits="Employee_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>        td,th {
            text-align:left;
            padding-left:5px;
        }

               .Tabledata {
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- page content -->
        <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>Employee Master Page</h3>
              </div>

            </div>
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Employee Master Entry panel <small>Employee Details</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                      </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content" >

                    <div class="form-horizontal form-label-left" >

                      <span class="section">Enter Info</span>
                      
                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Profile Image: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:FileUpload ID="profimg" class="form-control col-md-7 col-xs-12" runat="server" />

                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Code: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox8" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Mst User Name: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox1" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Emp Mst Password: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox2" TextMode="Password" class="form-control col-md-7 col-xs-12" runat="server" ></asp:TextBox>
                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Mst Full Name : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox3" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Mst State : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="DropDownList1"  class="form-control" runat="server" ></asp:DropDownList>
                        </div>
                            </div>

                            <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Mst Department : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="DropDownList2"  class="form-control" runat="server"  ></asp:DropDownList>
                        </div>
                                </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Mst Location: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox4" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Mst Is Active: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox5" class="form-control col-md-7 col-xs-12" runat="server" Text ="Y"></asp:TextBox>
                        </div>
                      </div> 
                        
                        <div class="item form-group">
                            
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">Joining Date : <span class="required">*</span></label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class='input-group date' id='myDatepicker4'>
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox6" class="form-control col-md-7 col-xs-12" runat="server" ></asp:TextBox>
                                        <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                    </div>
                                
                            </div>
                        <div class="item form-group">
                            
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">Birth Date : <span class="required">*</span></label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class='input-group date' id='Div1'>
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox9" class="form-control col-md-7 col-xs-12" runat="server" ></asp:TextBox>
                                        <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                    </div>
                                
                            </div>

                          
                      <div class="item form-group">
                      <label class="control-label col-md-3 col-sm-3 col-xs-12">Employee Vehical Status : <span class="required">*</span></label>
                      <asp:CheckBoxList ID="CheckBoxList1" runat="server" class="checkboxdata"> </asp:CheckBoxList>
                        </div>

                        <div class="item form-group">
                             <label class="control-label col-md-3 col-sm-3 col-xs-12">Employee Status : <span class="required">*</span></label>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem Text="F" Value="F" ></asp:ListItem>
                            <asp:ListItem Text="T" Value="T"></asp:ListItem>
                        </asp:RadioButtonList>
                            </div>


                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Employee Type: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="DropDownList3"  class="form-control" runat="server"  >
                                     <asp:ListItem Text="--Select--" Value="select"></asp:ListItem>
                                     <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                 </asp:DropDownList>
                        </div>
                                </div>

                                   
                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Job Status : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="DropDownList4"  class="form-control" runat="server"  ></asp:DropDownList>
                        </div>
                                </div>
                        
                              <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Salary : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox7" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div> 
                          
                                         
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <%--<button type="submit" class="btn btn-primary">Cancel</button>
                          <button id="send" type="submit" class="btn btn-success">Submit</button>--%>
                            <asp:Button ID="btnAddEmp" runat="server" class="btn btn-success" Text="Add Employee" onclick="btnAddEmp_Click" />
                            <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" OnClick="btnReset_Click"/>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            
               <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel" >
                  <div class="x_title">
                    <h2>Employee Master View Panel<small>Users</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                      </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    
			        
                    <table id="datatable-buttons" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                      <thead>
                        <tr>
                            <th class="Tabledata">Emp_code</th>
                            <th class="Tabledata">User_Code</th>
                            <th class="Tabledata">Emp_Mst_User_Name</th>
                            <th class="Tabledata">Emp_Mst_Password</th>
                            <th class="Tabledata">Emp_Mst_Full_Name</th>
                            <th class="Tabledata">Emp_Mst_State</th>
                            <th class="Tabledata">Edit</th>
                            <th class="Tabledata">Delete</th>
                            <th class="Tabledata">Emp_Mst_Department</th>
                            <th class="Tabledata">Emp_Mst_Location</th>
                            <th class="Tabledata">Emp_Mst_Is_Active</th>
                            <th class="Tabledata">Emp_Mst_Joining_Date</th>
                            <th class="Tabledata">Emp_Mst_Birth_Date</th>
                            <th class="Tabledata">Emp_Mst_Vehical_Type</th>
                            <th class="Tabledata">Emp_Mst_Status</th>
                            <th class="Tabledata">Emp_Mst_Created_On</th>
                            <th class="Tabledata">Emp_Mst_Created_By</th>
                            <th class="Tabledata">Emp_Mst_Modified_On</th>
                            <th class="Tabledata">Emp_Mst_Modified_By</th>
                            <th class="Tabledata">Emp_Mst_Revision</th>
                            <th class="Tabledata">Emp_Mst_Emp_Type</th>
                            <th class="Tabledata">Emp_Job_Status</th>
                            <th class="Tabledata">Emp_Resign_Date</th>
                            <th class="Tabledata">Emp_Conformation_Date</th>
                            <th class="Tabledata">Emp_Notice_Period_Date</th>
                            <th class="Tabledata">Emp_Salary</th>
                            <th class="Tabledata">Emp_Salary_Per_Hour</th>
                            <th class="Tabledata">Is_Conform</th>
                            <th class="Tabledata">Profile Image</th>
                        </tr>
                      </thead>
                      <tbody>
                      <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr>
                            <td class="Tabledata"><%# Eval("Emp_code")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_User_Code")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_User_Name")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Password")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Full_Name")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_State")%></td>
                            <td class="Tabledata"><asp:ImageButton ID="btnImgEdit" runat="server" CommandArgument='<%# Eval("Emp_Mst_User_Code")%>'  Text="Edit" OnClick="btnImgEdit_Click" ImageUrl="~/images/Edit.png" /></td>
                            <td class="Tabledata"><asp:ImageButton ID="btnImgDel" runat="server" CommandArgument='<%# Eval("Emp_Mst_User_Code")%>'   Text="Delete" ImageUrl="~/images/Delete.png" OnClick="btnImgDel_Click" /></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Department")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Location")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Is_Active")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Joining_Date")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Birth_Date")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Vehical_Type")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Status")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Created_On")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Created_By")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Modified_On")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Modified_By")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Revision")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Emp_Type")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Job_Status")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Resign_Date")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Conformation_Date")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Notice_Period_Date")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Salary")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Salary_Per_Hour")%></td>
                            <td class="Tabledata"><%# Eval("Is_Conform")%></td>
                            <td class="Tabledata">

                                <asp:Image ID="Image1" ImageUrl= '<%# "~/images/"+Eval("Emp_Profile_Img")%>' runat="server" />
                            
                                </td>
                        </tr>
                        </ItemTemplate>
                      </asp:Repeater>
                      </tbody>
                    </table>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- /page content -->
</asp:Content>

