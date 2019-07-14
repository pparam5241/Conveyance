<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="View" %>

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
    <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>View Data</h3>
              </div>

            </div>
            <div class="clearfix"></div>

            <div class="row">            
               <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Last Month Data View Panel<small>Data</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                      </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                      <div class="form-horizontal form-label-left" >

                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Till Date : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="tillDate" readOnly="true" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>

                    </div>
                    <table id="datatable-fixed-header" class="table table-striped table-bordered" cellspacing="0" width="100%">
                      <thead>
                        <tr>
                            <th class="Tabledata">Update</th>
                            <th class="Tabledata">Sr.</th>
                            <th class="Tabledata">User_Name</th>
                            <th class="Tabledata">Conv_Date</th>
                            <th class="Tabledata">Conv_From</th>
                            <th class="Tabledata">Conv_To</th>
                            <th class="Tabledata">Vehical</th>
                            <th class="Tabledata">Conv_Km</th>
                            <th class="Tabledata">Fuel Rate</th>
                            <th class="Tabledata">Amount</th>
                            <th class="Tabledata">Department</th>
                            <th class="Tabledata">Location</th>
                            <th class="Tabledata">Enter Reason</th>
                            
                            
                        </tr>
                      </thead>
                      <tbody>
                      <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr>
                            <td class="Tabledata"><asp:ImageButton ID="btnImgDel" runat="server" CommandArgument='<%# Eval("Conv_Code")%>' OnClick="btnImgDel_Click" Text="Delete" ImageUrl="~/images/Delete.png" /></td>
                            <td class="Tabledata"><%# Eval("Conv_Code")%></td>
                            <td class="Tabledata"><%# Eval("Conv_User_Name")%></td>
                            <td class="Tabledata"><%# Eval("Conv_Date")%></td>
                            <td class=""><%# Eval("Conv_From")%></td>
                            <td class=""><%# Eval("Conv_To")%></td>
                            <td class="Tabledata"><%# Eval("Misc_Field_Value")%></td>
                            <td class="Tabledata"><%# Eval("Conv_User_Km")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_mst_Rate")%></td>
                            <td class="Tabledata"><%# Eval("Amount")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Department")%></td>
                            <td class="Tabledata"><%# Eval("Emp_Mst_Location")%></td>
                            <td class="Tabledata">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                            
                        </tr>
                        </ItemTemplate>
                      </asp:Repeater>
                      </tbody>
                    </table>


                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <%--<button type="submit" class="btn btn-primary">Cancel</button>
                          <button id="send" type="submit" class="btn btn-success">Submit</button>--%>
                            <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Checked All" OnClick="Button1_Click"/>
                        </div>
                          <br />
                          <br />
                      </div>
                      
                      <br />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
</asp:Content>

