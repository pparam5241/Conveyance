<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    

    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet"/>
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet"/>
    <!-- Animate.css -->
    <link href="vendors/animate.css/animate.min.css" rel="stylesheet"/>

    <!-- Custom Theme Style -->
    <link href="css/custom.min.css" rel="stylesheet"/>


    <script src="alert/sweetalert-dev.js"></script>
    <link href="alert/sweetalert.css" rel="stylesheet" />
    <script src="alert/sweetalert.min.js"></script>
    <title>Conveyance Log </title>
</head>
<body class="login">
    <form id="form1" runat="server">
       <div >
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <%--<section class="login_content">--%>
            <div class="login_content">
            <div>
                <img src="images/HNS_logo.png" style="width: 200px;height: 100px; "/>
              <h1>Login Form</h1>
              <div>
                      <asp:TextBox ID="txtUserName" class="form-control" runat="server" placeholder="UserName" ></asp:TextBox>
                      <br />
               </div>
              <div>
                  <asp:TextBox ID="txtPassward" runat="server" class="form-control" TextMode="Password" placeholder="Password" ></asp:TextBox>
              </div>
              <%--<div>
                <a class="btn btn-default submit" href="home.php">Log in</a>
                <a class="reset_pass" href="#">Lost your password?</a>
              </div>--%>

              <div class="clearfix"></div>

              <div class="separator">
<%--                <p class="change_link">New to site?
                  <a href="#signup" class="to_register"> Create Account </a>
                </p>--%>
                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                  <br />
                    <asp:Button ID="btnLogin" class="btn btn-default submit" runat="server" Text="Login" OnClick="btnLogin_Click" />
             
                <div class="clearfix"></div>
                <br />

                <div>
                  <h1> Hard n' Soft!</h1>
                  <p>©2019 Copyright All reseved by Hard n'soft consultancy surat.</p>
                </div>
              </div>
            </div>
        </div>
          <%--</section>--%>
        </div>

    <%--    <div id="register" class="animate form registration_form">
          <section class="login_content">
            <div>
              <h1>Create Account</h1>
              <div>
                <input type="text" class="form-control" placeholder="Username" required="" />
              </div>
              <div>
                <input type="email" class="form-control" placeholder="Email" required="" />
              </div>
              <div>
                <input type="password" class="form-control" placeholder="Password" required="" />
              </div>
              <div>
                <a class="btn btn-default submit" href="index.html">Submit</a>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">Already a member ?
                  <a href="#signin" class="to_register"> Log in </a>
                </p>

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><i class="fa fa-paw"></i> Gentelella Alela!</h1>
                  <p>©2016 All Rights Reserved. Gentelella Alela! is a Bootstrap 3 template. Privacy and Terms</p>
                </div>
              </div>
            </div>
          </section>
        </div>
   --%>   </div>
    </div>
  </form>
    </body>
</html>
