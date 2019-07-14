<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Area.aspx.cs" Inherits="Area" %>

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
                <h3>Area Page</h3>
              </div>

            </div>
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Area Entry Panel <small>Area Details</small></h2>
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
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Select Type : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="ddlmsttype"  class="form-control" runat="server"></asp:DropDownList>
                        </div>
                            </div>
                          

                         <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Select State : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="ddlstate"  class="form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="Dropdown1_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                      </div>
                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Select City : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="ddlcity"  class="form-control" runat="server"></asp:DropDownList>
                        </div>
                      
                      </div> 
                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Area Name : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="txtareaname" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                        </div>

                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <%--<button type="submit" class="btn btn-primary">Cancel</button>
                          <button id="send" type="submit" class="btn btn-success">Submit</button>--%>
                            <asp:Button ID="btnAddArea" runat="server" class="btn btn-success" Text="Add Area" onclick="btnAddArea_Click" />
                            <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" OnClick="btnReset_Click"/>
                        </div>
                      </div>
                  </div>
               </div>
              </div>
            
               <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Area View Panel<small>Users</small></h2>
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
                          <th>Area Mst Code</th>
                          <th>Area Mst Bp Name</th>
                          <th>Area Mst Type</th>
                          <th>Area Mst State Flow Id</th>
                          
                          <th>Edit</th>
                          <th>Delete</th>
                          <th>Area Mst City Flow Id</th>
                          <th>Area Mst Status</th>
                          <th>Area Mst Created On</th>
                          <th>Area Mst Created By</th>
                          <th>Area Mst Modified On</th>
                          <th>Area Mst Modified By</th>
                          <th>Area Mst Revision</th>
                        </tr>
                      </thead>
                      <tbody>
                      <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr>
                          <td><%# Eval("Area_Mst_Code")%></td>
                          <td><%# Eval("Area_Mst_Bp_Name")%></td>
                          <td><%# Eval("Area_Mst_Type")%></td>
                          <td><%# Eval("Area_Mst_State_Flow_Id")%></td>
                          <td><asp:ImageButton ID="btnImgEdit" runat="server" CommandArgument='<%# Eval("Area_Mst_Code")%>'  Text="Edit" OnClick="btnImgEdit_Click" ImageUrl="~/images/Edit.png" /></td>
                          <td><asp:ImageButton ID="btnImgDel" runat="server" CommandArgument='<%# Eval("Area_Mst_Code")%>'   Text="Delete" ImageUrl="~/images/Delete.png" OnClick="btnImgDel_Click" /></td>
                          <td><%# Eval("Area_Mst_City_Flow_Id")%></td>
                          <td><%# Eval("Area_Mst_Status")%></td>
                          <td><%# Eval("Area_Mst_Created_On")%></td>
                          <td><%# Eval("Area_Mst_Created_By")%></td>
                          <td><%# Eval("Area_Mst_Modified_On")%></td>
                          <td><%# Eval("Area_Mst_Modified_By")%></td>
                          <td><%# Eval("Area_Mst_Revision")%></td>
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

