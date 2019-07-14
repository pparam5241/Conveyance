<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Conv_Status.aspx.cs" Inherits="Conv_Status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>        td,th {
            text-align:left;
            padding-left:5px;
        }

               .Tabledata {
            text-align:center;
        }
               .abc {
    color : transparent;
    
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>Conveyance Page</h3>
              </div>
            </div>
            <div class="clearfix"></div>
            <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Table View of Conveyance<small>Data</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                      </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                      <div class="form-horizontal form-label-left" >
			        <div class="item form-group">
                            
                            </div> 
                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> Last Date of Last Month : <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="State" required="required" type="text">--%>
                            <asp:TextBox ID="TextBox6" class="form-control col-md-7 col-xs-12" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                        </div>

                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <%--<button type="submit" class="btn btn-primary">Cancel</button>
                          <button id="send" type="submit" class="btn btn-success">Submit</button>--%>
                            <asp:Button ID="btnShowStatus" runat="server" class="btn btn-success" Text="View Data" OnClick="btnShowStatus_Click" />
                        </div>
                          <br />
                          <br />
                      </div>
			        
                    <table id="Table1" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                      <thead>
                        <tr>
                            <th class="Tabledata">Pay_Date</th>
                            <th class="Tabledata">Conv_User_Name</th>
                            <th class="Tabledata">Conv_User_Km</th>
                            <th class="Tabledata">Amount</th>
                            <th class="Tabledata">Check</th>

                            
                        </tr>
                      </thead>
                      <tbody>
                      <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                        <tr>
                            <td class="Tabledata"><%# Eval("Pay_Date")%></td>
                                <td class="Tabledata"><%# Eval("Conv_User_Name")%></td>
                                <td class="Tabledata"><%# Eval("Conv_User_Km")%></td>
                                <td class="Tabledata"><%# Eval("Amount")%></td>
                            <td class="Tabledata">
                                <asp:CheckBox ID="CheckBox1" runat="server" class="abc" Text='<%# Eval("Conv_User_Name") %>'/>

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
                            <asp:Button ID="btnPay" runat="server" class="btn btn-success" Text="Pay" OnClick="btnPay_Click"/>
                        </div>
                          <br />
                          <br />
                      </div>

                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
         </div>
</asp:Content>

