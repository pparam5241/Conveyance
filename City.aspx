<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="City.aspx.cs" Inherits="City" %>

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
                <h3>City Page</h3>
              </div>

            </div>
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>City Entry Panel <small>City Details</small></h2>
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
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Select State: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="StateDropdown"  class="form-control" runat="server"></asp:DropDownList>

                 
                        </div>
                      </div>
                      
                         <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> City Name: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="txtcityname" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>
                      
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <%--<button type="submit" class="btn btn-primary">Cancel</button>
                          <button id="send" type="submit" class="btn btn-success">Submit</button>--%>
                            <asp:Button ID="btnAddCity" runat="server" class="btn btn-success" Text="Add City" OnClick="btnAddCity_Click" />
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
                    <h2>City View Panel<small>Users</small></h2>
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
                          <th>City Id</th>
                          <th>City Name</th>
                          <th>Edit</th>
                          <th>Delete</th>
                          
                        </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr>
                          <td><%# Eval("City_Id")%></td>
                          <td><%# Eval("City_Name")%></td>
                          <td><asp:ImageButton ID="btnImgEdit" runat="server" CommandArgument='<%# Eval("City_Id")%>' OnClick="btnImgEdit_Click"  Text="Edit" ImageUrl="~/images/Edit.png" /></td>
                          <td><asp:ImageButton ID="btnImgDel" runat="server" CommandArgument='<%# Eval("City_Id")%>' OnClick="btnImgDel_Click"  Text="Delete" ImageUrl="~/images/Delete.png" /></td>
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

