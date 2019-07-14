<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Fuel_Type.aspx.cs" Inherits="Fuel_Type" %>

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
                <h3>Fuel Type Page</h3>
              </div>

            </div>
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel" >
                  <div class="x_title">
                    <h2>Fuel Type Entry Panel <small>Fuel Details</small></h2>
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
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Fuel Mst Vehical Type : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                                 <asp:DropDownList ID="Dropdown1"  class="form-control" runat="server"></asp:DropDownList>
                        </div>
                      </div>

                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">Fuel Mst From Date : <span class="required">*</span></label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class='input-group date' id='myDatepicker4'>
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox7" class="form-control col-md-7 col-xs-12" runat="server" ></asp:TextBox>
                                        <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                    </div>
                            </div>

                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">Fuel Mst To Date : <span class="required">*</span></label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class='input-group date' id='myDatepicke4'>
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox8" class="form-control col-md-7 col-xs-12" runat="server" ></asp:TextBox>
                                        <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                    </div>
                            </div>
    

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Fuel Mst Rate : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox9" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Fuel Mst Fuel Rate : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox10" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Fuel Mst Milege : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox11" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                        </div>
                      </div>

                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <%--<button type="submit" class="btn btn-primary">Cancel</button>
                          <button id="send" type="submit" class="btn btn-success">Submit</button>--%>
                            <asp:Button ID="btnAddFuel" runat="server" class="btn btn-success" Text="Add Fuel" onclick="btnAddFuel_Click" />
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
                            <th class="Tabledata">Fuel_Id</th>
                            <th class="Tabledata">Fuel_Mst_From_Date</th>
                            <th class="Tabledata">Fuel_Mst_To_Date</th>
                            <th class="Tabledata">Fuel_Mst_Vehical_Type</th>
                            
                            <th class="Tabledata">Fuel_Mst_Fuel_Rate</th>
                            <th class="Tabledata">Edit</th>
                            <th class="Tabledata">Delete</th>
                            <th class="Tabledata">Fuel_Mst_Rate</th>
                            <th class="Tabledata">Fuel_Mst_Milege</th>
                            <th class="Tabledata">Fuel_Mst_Status</th>
                            <th class="Tabledata">Fuel_Mst_Created_On</th>
                            <th class="Tabledata">Fuel_Mst_Created_By</th>
                            <th class="Tabledata">Fuel_Mst_Modified_On</th>
                            <th class="Tabledata">Fuel_Mst_Modified_By</th>
                            <th class="Tabledata">Fuel_Mst_Revision</th>
                        </tr>
                      </thead>
                      <tbody>
                      <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr>
                            <td class="Tabledata"><%# Eval("Fuel_Id")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_From_Date")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_To_Date")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_Vehical_Type")%></td>
                            
                            <td class="Tabledata"><%# Eval("Fuel_Mst_Fuel_Rate")%></td>
                            <td class="Tabledata"><asp:ImageButton ID="btnImgEdit" runat="server" CommandArgument='<%# Eval("Fuel_Id")%>'  Text="Edit" OnClick="btnImgEdit_Click" ImageUrl="~/images/Edit.png" /></td>
                            <td class="Tabledata"><asp:ImageButton ID="btnImgDel" runat="server" CommandArgument='<%# Eval("Fuel_Id")%>'   Text="Delete" ImageUrl="~/images/Delete.png" OnClick="btnImgDel_Click" /></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_Rate")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_Milege")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_Status")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_Created_On")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_Created_By")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_Modified_On")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_Modified_By")%></td>
                            <td class="Tabledata"><%# Eval("Fuel_Mst_Revision")%></td>
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

