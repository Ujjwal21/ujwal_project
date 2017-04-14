<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Login_Page.About" %>

<!DOCTYPE html>
<html>
<head>
    <title>ABOUT</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css" />
    <style>
        html {
            background: url(black.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }
          textarea {
          overflow: auto;
          font-size: small;
        }
        .waves-effect {
            position: relative;
            cursor: pointer;
            display: inline-block;
            overflow: hidden;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            -webkit-tap-highlight-color: transparent;
            vertical-align: middle;
            z-index: 1;
            will-change: opacity, transform;
            transition: .3s ease-out;
        }

        .btn {
            text-decoration: none;
            color: #fff;
            background-color: #26a69a;
            text-align: center;
            letter-spacing: .5px;
            transition: .2s ease-out;
            cursor: pointer;
            border: none;
            border-radius: 2px;
            display: inline-block;
            height: 36px;
            line-height: 36px;
            padding: 0 2rem;
            text-transform: uppercase;
            vertical-align: middle;
            -webkit-tap-highlight-color: transparent;
        }

        .center {
            transition: box-shadow .25s;
            padding-top: 40px;
            background-color: #F5F5F5;
            width: 500px;
            height: 600px;
            position: absolute;
            top: 100px;
            left: 420px;
            overflow-y: auto;
        }

        .about_title {
            position: absolute;
            top: 35px;
            left: 430px;
            font-size: 50px;
            color: white;
        }

        .about_label {
            position: relative;
            padding-top: 40px;
            left: 20px;
            font-size: 20px;
            color: black;
        }

        .about_textbox {
            position: absolute;
            left: 250px;
            height: 40px;
            width: 200px;
        }
         button, input {
         overflow: visible;
         font-size: small;
         } 
        .position {
            position: relative;
            /* align-content: center; */
            left: 170px;
            top: 40px;
        }

        }
    </style>
</head>
<body>
    <form runat="server" novalidate>
        <div class="about_title">About...</div>
        <div class="center" runat="server" id="myForm">
            <div class="about_label">
                Birthday
                 <asp:TextBox runat="server" ID="BirthdayTextbox" CssClass="about_textbox" />
            </div>
            <div class="about_label">
                Phone Number
                 <asp:TextBox runat="server" ID="TextBox1" CssClass="about_textbox" />
            </div>
            <div class="about_label">
                Interested In
                 <asp:TextBox runat="server" ID="TextBox2" CssClass="about_textbox" TextMode="multiline" />
            </div>
            <div class="about_label">
                Profession
                 <asp:TextBox runat="server" ID="TextBox3" CssClass="about_textbox" TextMode="multiline" />
            </div>
            <div class="about_label">
                Studied At
                 <asp:TextBox runat="server" ID="TextBox4" CssClass="about_textbox" TextMode="multiline" />
            </div>
            <div class="about_label">
                Lives In
                 <asp:TextBox runat="server" ID="TextBox5" CssClass="about_textbox" TextMode="multiline" />
            </div>
            <div class="about_label">
                From
                 <asp:TextBox runat="server" ID="TextBox6" CssClass="about_textbox" TextMode="multiline" />
            </div>
            <asp:Button runat="server" ID="Button1"  OnClick="Save_Info" Text="Change" CssClass="waves-effect  btn position" />
        </div>
    </form>
</body>
</html>
