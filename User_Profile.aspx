<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="User_Profile.aspx.cs" Inherits="User_Profile" %>

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
                <h3>State Page</h3>
              </div>

            </div>
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Profile Entry panel <small>User Details</small></h2>
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
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Profile Image: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:FileUpload ID="profimg" class="form-control col-md-7 col-xs-12" runat="server" />

                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Mst User Name: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox1" ReadOnly="true" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
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
                            <asp:TextBox ID="TextBox5" class="form-control col-md-7 col-xs-12" readOnly="true" runat="server" Text ="Y"></asp:TextBox>
                        </div>
                      </div> 
                        
                        <div class="item form-group">
                            
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">Joining Date : <span class="required">*</span></label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class='input-group date' id='myDatepicker4'>
                                        <asp:TextBox ID="TextBox6" class="form-control col-md-7 col-xs-12" runat="server" ></asp:TextBox>
                                        <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                    </div>
                                
                            </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Employee Status : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox7" class="form-control col-md-7 col-xs-12" runat="server" ReadOnly="true" ></asp:TextBox>
                        </div>
                      </div>

                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Emp Mst Is Active: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox8" class="form-control col-md-7 col-xs-12" runat="server" readOnly="true"></asp:TextBox>
                        </div>
                      </div>
                          
                      <div class="item form-group">
                      <label class="control-label col-md-3 col-sm-3 col-xs-12">Employee Vehical Type : <span class="required">*</span></label>
                      <asp:CheckBoxList ID="CheckBoxList1" runat="server" class="checkboxdata"> </asp:CheckBoxList>
                        </div>

                                         
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <%--<button type="submit" class="btn btn-primary">Cancel</button>
                          <button id="send" type="submit" class="btn btn-success">Submit</button>--%>
                            <asp:Button ID="UpdateProfile" runat="server" class="btn btn-success" Text="Update Profile" onclick="UpdateProfile_Click" />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- /page content -->
</asp:Content>

