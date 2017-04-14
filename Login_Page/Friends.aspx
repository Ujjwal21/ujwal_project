<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="Login_Page.Friends" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.8/css/materialize.min.css" />
    <!-- Compiled and minified JavaScript -->
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
            padding-top: 0px;
            margin: 0.5rem 0 1rem 0;
            background-color: transparent;
            width: 491px;
            height: 600px;
            position: absolute;
            top: 100px;
            left: 450px;
            overflow: auto;
        }

        .image_icon {
            height: 100px;
            width: 100px;
        }

        .pad {
            padding-top: 20px;
            padding-bottom: 20px;
        }

        .title {
            text-align: center;
            font-size: 60px;
            color: white;
        }
        .centerbutton{
            position:relative;
              
    left: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" novalidate="novalidate">
        <div class="title">Friend Requests....</div>
        <div runat="server" class="center">
            <asp:DataList ID="dlFriends" runat="server" CellPadding="3" CellSpacing="2">
                <ItemTemplate runat="server">
                    <div class="w3-card-2 w3-round w3-white w3-center pad">
                        <div class="w3-container">
                            <asp:Image ID="profileImage" runat="server" CssClass="image_icon" ImageUrl='<%# "~\\Profile_Pics\\"+ Eval("profile_pic") %>' />
                            <br />
                            <asp:Label ID="lblFriendName" runat="server" ForeColor="Black" Text='<%# Eval("user_name") %>'></asp:Label>
                            <br />
                            <br />
                            <asp:Label runat="server" ID="Label1" CssClass="centerbutton" Visible="false" Text="accepted"></asp:Label>
                            <div class="w3-row w3-opacity">
                                
                                <div class="w3-half">
                                    <asp:Button runat="server" ID="Accept_Button" Text="Accept" ToolTip="Accept" BackColor="ForestGreen" OnClick="Accept_Click"
                                        CommandArgument='<%# Bind("user_name") %>' CssClass="waves-effect waves-light btn " />
                                </div>
                                <div class="w3-half">
                                    <asp:Button runat="server" ID="Reject_Button" ToolTip="Reject" OnClick="Reject_Click"
                                        CommandArgument='<%# Bind("user_name") %>' BackColor="Red" Text="Decline" CssClass="waves-effect waves-light btn " />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
