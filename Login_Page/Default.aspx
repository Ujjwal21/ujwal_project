<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Login_Page.Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>LOGIN PAGE</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css" />
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.8/css/materialize.min.css">
    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.8/js/materialize.min.js"></script>
    <style>
        html {
            background: url(nit_kkr.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        .new21 {
            color: #ffffff;
            position: absolute;
            left: 610px;
            top: 450px;
        }

        .center2 {
            transition: box-shadow .25s;
            padding-top: 20px;
            margin: 0.5rem 0 1rem 0;
            background-color: white;
            width: 491px;
            height: 567px;
            position: absolute;
            top: 50px;
            left: 450px;
        }

        .center {
            transition: box-shadow .25s;
            padding-top: 50px;
            margin: 0.5rem 0 1rem 0;
            border-radius: 2px;
            background-color: rgba(255, 241, 118, 0.54);
            width: 378px;
            height: 490px;
            border-radius: 25px;
            position: relative;
            top: 50px;
            left: 480px;
        }

        .center1 {
            transition: box-shadow .25s;
            padding-top: 50px;
            margin: 0.5rem 0 1rem 0;
            border-radius: 1px;
            background-color: rgb(241, 241, 241);
            width: 491px;
            height: 567px;
            border-radius: 25px;
            position: absolute;
            top: 50px;
            left: 450px;
        }

        .input-field label {
            color: #fff;
        }

        .new {
            color: #ffffff;
            position: relative;
            left: 1100px;
            top: 30px;
        }

        .new1 {
            position: relative;
            left: 1200px;
        }

        .close:hover,
        .close:focus {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form runat="server" novalidate>
        <asp:ScriptManager ID="ScriptManager1" runat="server" AllowCustomErrorsRedirect="true" />
        <div class="new">New To Site?</div>
        <asp:Button runat="server" ID="Sign_Up_Button" OnClick="Sign_Up" Text="Sign Up" CssClass="waves-effect waves-light btn new1" />
        <div class="center" runat="server" id="myForm">
            <div class="row">
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s12 ">
                            <input name="user_name" type="text" class="validate">
                            <label for="user_name">Username</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <input name="password" type="password" class="validate">
                            <label for="password">Password</label>
                        </div>
                    </div>
                    <br>
                    <asp:LinkButton runat="server" ID="forgetPassword" Text="Forget Password" onclick="Forget_Password_Block" CssClass="waves-effect waves-light "></asp:LinkButton>
                    <div id="id02" runat="server" class="w3-modal background">
                        <div runat="server" class="w3-modal-content center2">
                            <div runat="server" class="w3-container">
                                <span onclick="document.getElementById('id02').style.display='none'" class="w3-closebtn w3-hover-red w3-container w3-padding-8 w3-display-topright" title="Close">&times;</span>
                                <h2>Password Change</h2>
                                <br>
                                <br>
                                <div class="row">
                                    <div class="col s12">
                                        <div class="row">
                                            <div class="input-field col s12">
                                                <input name="new_password" type="password" class="validate" required />
                                                <label for="new_password">New Password<span class="req">*</span></label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="input-field col s12">
                                                <input name="confirm_password" type="password" class="validate" required>
                                                <label for="confirm_password">Confirm New Password<span class="req">*</span></label>
                                            </div>
                                        </div>
                                        <br>
                                        <asp:Button runat="server" ID="Change_Password_Button2" OnClick="Change_New_Password" Text="Change" CssClass="waves-effect waves-light btn position2" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="id01" class="w3-modal background">
                        <div class="w3-modal-content center1">
                            <div class="w3-container">
                                <span onclick="document.getElementById('id01').style.display='none'" class="w3-closebtn w3-hover-red w3-container w3-padding-8 w3-display-topright" title="Close Modal">&times;</span>
                                <h2>Password Reset</h2>
                                <br>
                                <div class="row">
                        <div class="input-field col s12 ">
                            <input name="user_name1" type="text" class="validate">
                            <label for="user_name1">Username</label>
                        </div>
                    </div>
                                <br>
                                <div class="row">
                                    <div class="col s12">
                                        <asp:Button runat="server" ID="Send_Email_Button" OnClick="Send_Email" Text="Send on Registered Email" CssClass="waves-effect waves-light btn" />

                                        <br>
                                        <div class="row">
                                            <div class="input-field col s12">
                                                <input name="otp" type="text" class="validate">
                                                <label for="otp">Enter the OTP</label>
                                            </div>
                                        </div>
                                        <a href="www.fb.com" class="waves-effect waves-light ">Resend</a>
                                    </div>
                                    <br>
                                    <br>
                                    <br>
                                    <br>
                                    <asp:Button runat="server" ID="Change_Password_Button" OnClick="Change__Password" Text="Change Password" CssClass="waves-effect waves-light btn" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br>
        <br>
        <br>
        <asp:Button runat="server" ID="Log_In_Button" OnClick="LogInToMainPage" Text="Log In" CssClass="waves-effect waves-light btn new21" />
    </form>
</body>
</html>
