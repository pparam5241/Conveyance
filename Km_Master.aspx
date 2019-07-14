<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Km_Master.aspx.cs" Inherits="Km_Master" %>

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
                <h3>Km Master Page</h3>
              </div>

            </div>
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Km Master Entry Panel <small>Km Details</small></h2>
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
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> From: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            
                            <asp:DropDownList ID="DropdownFrom"  class="form-control" runat="server"></asp:DropDownList>
                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> To: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <%--<asp:TextBox ID="txtkmto" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="DropDownTo"  class="form-control" runat="server"></asp:DropDownList>
                        </div>
                      </div>
                      
                         <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Kilometer: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="txtkmnumber" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>
                      
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <%--<button type="submit" class="btn btn-primary">Cancel</button>
                          <button id="send" type="submit" class="btn btn-success">Submit</button>--%>
                            <asp:Button ID="btnAddKm" runat="server" class="btn btn-success" Text="Add Km" OnClick="btnAddKm_Click" />
                            <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" onclick="btnReset_Click"/>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            
               <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Table View of City<small>Users</small></h2>
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
                          <th>Km Mst Id</th>
                          <th>Km Mst From Name</th>
                          <th>Km Mst To Name</th>
                          <th>Km Mst Km</th>
                          <th>Edit</th>
                          <th>Delete</th>
                          <th>Km Mst Created On</th>
                          <th>Km Mst Created By</th>
                          <th>Km Mst Modified On</th>
                          <th>Km Mst Modified By</th>
                          <th>Km Mst Revision</th>
                            
                          
                        </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr>
                          <td><%# Eval("Km_Mst_Id")%></td>
                          <td><%# Eval("Km_Mst_From_Name")%></td>
                          <td><%# Eval("Km_Mst_To_Name")%></td>
                          <td><%# Eval("Km_Mst_Km")%></td>
                          <td><asp:ImageButton ID="btnImgEdit" runat="server" CommandArgument='<%# Eval("Km_Mst_Id")%>' OnClick="btnImgEdit_Click"  Text="Edit" ImageUrl="~/images/Edit.png" /></td>
                          <td><asp:ImageButton ID="btnImgDel" runat="server" CommandArgument='<%# Eval("Km_Mst_Id")%>' OnClick="btnImgDel_Click"  Text="Delete" ImageUrl="~/images/Delete.png" /></td>
                          <td><%# Eval("Km_Mst_Created_On")%></td>
                          <td><%# Eval("Km_Mst_Created_By")%></td>
                          <td><%# Eval("Km_Mst_Modified_On")%></td>
                          <td><%# Eval("Km_Mst_Modified_By")%></td>
                          <td><%# Eval("Km_Mst_Revision")%></td>
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

