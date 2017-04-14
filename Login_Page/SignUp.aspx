<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Login_Page.SignUp" %>

<!DOCTYPE html>
<html>
<head>
    <title>Sign Up</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.8/css/materialize.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.8/js/materialize.min.js"></script>
    <style>
        html {
            background: url(black.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        .center {
            transition: box-shadow .25s;
            margin: 0.5rem 0 1rem 0;
            background-color: rgba(117, 117, 117, 0.32);
            width: 378px;
            height: 718px;
            border-radius: 25px;
            position: relative;
            padding-top: 50px;
            top: 50px;
            left: 480px;
        }

        .input-field label {
            color: #fff;
        }

        .white {
            color: #fff;
        }

        .new {
            color: #ffffff;
            position: relative;
            left: 490px;
            top: 30px;
            font-size: 50px;
        }

        .new1 {
            position: relative;
            left: 1200px;
        }
    </style>
    <script>
        function validateForm() {
            var x = document.forms["myForm"]["password"].value;
            var y = document.forms["myForm"]["confirm_password"].value;
            if (x != y) {
                alert("Both passwords are not same!!!");
                return false;
            }
        }
    </script>
</head>
<body>
    <form runat="server"  method="post" onsubmit="return validateForm()" id="myForm">
        <div class="new">Sign Up For Free</div>
        <div class="center">
            <div class="row">
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s6">
                            <input name="first_name" type="text" class="validate" required="required" >
                            <label for="first_name">First Name<span class="req">*</span></label>
                        </div>
                        <div class="input-field col s6">
                           <input name="last_name" type="text" class="validate" required="required" >
                            <label for="last_name">Last Name<span class="req">*</span></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                           <input name="email" type="email" class="validate" required="required" >
                            <label for="email">Email<span class="req">*</span></label>
                             </div>

                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <input name="user_name" type="text" class="validate" required="required" >
                            <label for="user_name">Username<span class="req">*</span></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <input name="password" type="password" class="validate" required="required">
                            <label for="password">Password<span class="req">*</span></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <input name="confirm_password" type="password" class="validate" required="required">
                            <label for="password">Confirm Password<span class="req">*</span></label>
                        </div>
                    </div>
                    <div style="color: #fff;">Gender</div>
                    <div class="row">
                        <div class="col s6 ">
                            <div>
                                <asp:RadioButton  ID="MaleButton" GroupName="Gender" runat="server" Text="Male" />
                            </div>
                        </div>
                        <div class="col s6">
                            <div>
                                <asp:RadioButton ID="FemaleButton" GroupName="Gender" runat="server" Text="Female" />
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="Submit_Button" OnClick="Submit_Form" runat="server" CssClass="waves-effect waves-light btn" Text="Submit" />

                </div>
            </div>
        </div>
    </form>
</body>
</html>
