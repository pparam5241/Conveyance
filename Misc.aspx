<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Misc.aspx.cs" Inherits="Misc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>        td,th {
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
                <h3>Misc Page</h3>
              </div>

            </div>
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Misc Entry Panel <small>Misc Details</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                      </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">

                    <div class="form-horizontal form-label-left" >

                      <span class="section">Enter Info</span>
                      
                         <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Misc Table Name: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="Dropdown1"  class="form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="Dropdown1_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                      </div>
                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Misc Column Name: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="Dropdown2"  class="form-control" runat="server"></asp:DropDownList>
                        </div>
                      </div>
                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Misc Field Name: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="txtmiscfieldname" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>
                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Misc Field Value: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="txtmiscfieldvalue" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>
                      
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <%--<button type="submit" class="btn btn-primary">Cancel</button>
                          <button id="send" type="submit" class="btn btn-success">Submit</button>--%>
                            <asp:Button ID="btnAddMisc" runat="server" class="btn btn-success" Text="Add Misc" onclick="btnAddMisc_Click1" />
                            <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" OnClick="btnReset_Click"/>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            
               <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Misc View Panel<small>Misc User</small></h2>
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
                          <th>Misc Id</th>
                          <th>Misc Table Name</th>
                          <th>Misc Column Name</th>
                          <th>Misc Field Name</th>
                          <th>Misc Field Value</th>
                          <th>Misc Status</th>
                          <th>Edit</th>
                          <th>Delete</th>
                          <th>Misc Created On</th>
                          <th>Misc Created By</th>
                          <th>Misc Modified On</th>
                          <th>Misc Modified By</th>
                          <th>Misc Revision</th>
                        </tr>
                      </thead>
                      <tbody>
                      <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr>
                          <td><%# Eval("Misc_Id")%></td>
                          <td><%# Eval("Misc_Table_Name")%></td>
                          <td><%# Eval("Misc_Colomn_Name")%></td>
                          <td><%# Eval("Misc_Field_Name")%></td>
                          <td><%# Eval("Misc_Field_Value")%></td>
                          <td><%# Eval("Misc_Status")%></td>
                          <td><asp:ImageButton ID="btnImgEdit" runat="server" CommandArgument='<%# Eval("Misc_Id")%>'  Text="Edit" OnClick="btnImgEdit_Click" ImageUrl="~/images/Edit.png" /></td>
                          <td><asp:ImageButton ID="btnImgDel" runat="server" CommandArgument='<%# Eval("Misc_Id")%>'   Text="Delete" ImageUrl="~/images/Delete.png" OnClick="btnImgDel_Click" /></td>
                          <td><%# Eval("Misc_Created_On")%></td>
                          <td><%# Eval("Misc_Created_By")%></td>
                          <td><%# Eval("Misc_Modified_On")%></td>
                          <td><%# Eval("Misc_Modified_By")%></td>
                          <td><%# Eval("Misc_Revision")%></td>
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

