<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Self_Home.aspx.cs" EnableEventValidation="false" Inherits="Login_Page.Self_Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>HOME PAGE</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.8/css/materialize.min.css" />
    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.8/js/materialize.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script>

        function onSuccessMethod() {
            alert("success");
            // add this result into the div tag which is to be appended
        }
        function onFailMethod(err) {
            alert("Error");
        }
        function handleKeyPress(e) {
            var key = e.keyCode || e.which;
            if (key == 13) {
                PageMethods.abc(onSuccessMethod, onFailMethod);
            }
        }
    </script>
    <style>
        ul {
            list-style-type: none;
            margin: 0;
            padding-top: 10px;
            position: absolute;
            left: 378px;
            height: 76px;
            width: 990px;
            background-color: #333;
        }

        .input-field1 input[type=search] {
            display: block;
            line-height: inherit;
            padding-top: 10px;
            padding-left: 4rem;
            width: calc(100% - 4rem);
            height: 46px;
        }

        html {
            background: url(nit_kkr.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        li {
            float: right;
        }

            li a, .dropbtn1 {
                display: inline-block;
                color: white;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
                font-size: 20px;
            }

            li > a:hover:not(.active) {
                background-color: #111;
            }

        .active {
            background-color: #4CAF50;
        }

        .searchbar {
            padding-left: 20px;
            width: 567px;
            left: 76px;
        }

        .bgwhite {
            background-color: #fff;
        }

        .nav-wrappers {
            color: #fff;
            background-color: #333;
            width: 378px;
            height: 76px;
            left: 95px;
            padding-left: 20px;
            line-height: 56px;
        }

        .pad {
            padding-left: 0px;
        }

        .image {
            position: absolute;
            width: 76px;
            height: 76px;
            left: 605px;
            top: 0px;
        }

        .image1 {
            position: absolute;
            width: 189px;
            height: 227px;
            left: 76px;
            top: 113px;
            border: 2px solid #021a40;
        }

        .new2 {
            position: absolute;
            left: 45px;
            top: 378px;
        }

        .new3 {
            position: absolute;
            left: 113px;
            top: 435px;
        }

        .new4 {
            position: absolute;
            left: 870px;
            top: 321px;
        }

        .new5 {
            position: absolute;
            left: 1050px;
            top: 240px;
            z-index: -5;
        }

        .posts {
            border: 3px solid #021a40;
            transition: box-shadow .25s;
            padding-top: 30px;
            margin: 0.5rem 0 1rem 0;
            background-color: #fff;
            width: 567px;
            height: 189px;
            position: absolute;
            top: 120px;
            left: 400px;
            overflow: auto;
            padding-left: 30px;
            padding-right: 30px;
            padding-bottom: 30px;
        }

        .posts3 {
            height: 400px;
            width: 374px;
            display: block;
            position: absolute;
            background-color: white;
            top: 75px;
            left: 973px;
            z-index: 10;
            display: none;
            overflow: auto;
        }

        .posts1 {
            transition: box-shadow .25s;
            margin: 0.5rem 0 1rem 0;
            background-color: transparent;
            width: 567px;
            height: 378px;
            position: absolute;
            top: 450px;
            left: 400px;
            overflow: auto;
            padding-left: 30px;
            padding-right: 30px;
            padding-bottom: 30px;
        }

        .posts2 {
            border: 3px solid #021a40;
            transition: box-shadow .25s;
            padding-top: 30px;
            margin: 0.5rem 0 1rem 0;
            background-color: #fff;
            width: 378px;
            height: 189px;
            position: absolute;
            top: 280px;
            left: 60px;
            overflow: auto;
            padding-left: 30px;
            padding-right: 30px;
            padding-bottom: 30px;
        }

        .borders {
            border: 1px solid #021a40;
        }

        .posttext {
            position: absolute;
            color: black;
            font-size: 48px;
            top: 380px;
            left: 400px;
        }

        .dropdown1 {
            position: relative;
            display: inline-block;
            z-index: 20;
        }

        .dropdown1-content {
            display: none;
            position: absolute;
            background-color: #f9f9f9;
            width: 210px;
            right: 0;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
        }

            .dropdown1-content a {
                color: green;
                padding: 12px 16px;
                text-decoration: none;
                display: block;
            }

                .dropdown1-content a:hover {
                    background-color: black;
                }

        .dropdown1:hover .dropdown1-content {
            display: block;
        }

        .dropdown1:hover .dropbtn1 {
            background-color: #3e8e41;
        }

        .center1 {
            transition: box-shadow .25s;
            padding-top: 20px;
            margin: 0.5rem 0 1rem 0;
            border-radius: 1px;
            background-color: rgb(241, 241, 241);
            width: 491px;
            height: 567px;
            position: absolute;
            top: 50px;
            left: 450px;
        }

        ::-webkit-input-placeholder { /* WebKit browsers */
            color: black;
        }

        :-moz-placeholder { /* Mozilla Firefox 4 to 18 */
            color: black;
        }

        ::-moz-placeholder { /* Mozilla Firefox 19+ */
            color: black;
        }

        :-ms-input-placeholder { /* Internet Explorer 10+ */
            color: black;
        }

        .input-field input[type=search] {
            display: block;
            line-height: inherit;
            padding-left: 4rem;
            width: calc(100% - 4rem);
            height: 41px;
            padding-top: 15px;
        }

        .center4 {
            transition: box-shadow .25s;
            padding-top: 20px;
            margin: 0.5rem 0 1rem 0;
            background-color: rgb(241, 241, 241);
            width: 850px;
            height: 500px;
            position: absolute;
            top: 50px;
            left: 260px;
        }

        .profilepicholder {
            background-color: black;
            position: absolute;
            width: 450px;
            height: 500px;
            left: 0px;
            top: 0px;
        }

        .profilepic {
            position: absolute;
            width: 350px;
            height: 400px;
            left: 50px;
            top: 50px;
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

        .position1 {
            position: absolute;
            top: 500px;
            left: 190px;
        }

        .like {
            width: 50px;
            height: 50px;
            left: 489px;
            top: 51px;
            position: absolute;
        }

        .unlike {
            width: 50px;
            height: 50px;
            left: 570px;
            top: 51px;
            position: absolute;
        }

        .w3-closebtn1 {
            text-decoration: none;
            float: right;
            font-size: 24px;
            font-weight: bold;
            color: white;
        }

        .profile {
            position: absolute;
            width: 250px;
            height: 250px;
            left: 120px;
            top: 250px;
        }

        .postPictureButton {
            position: absolute;
            left: 645px;
            top: 329px;
        }

        .position3 {
            position: absolute;
            left: 170px;
            top: 520px;
        }

        .likes {
            left: 489px;
            top: 110px;
            position: absolute;
            font-family: Arial;
        }

        .comments {
            left: 570px;
            top: 110px;
            position: absolute;
            font-family: Arial;
        }

        .profilepiccomment {
            width: 330px;
            height: 280px;
            overflow-y: auto;
            left: 489px;
            top: 200px;
            position: absolute;
            background-color: white;
            padding-top: 10px;
        }

        .commentbox {
            display: inline-block;
            width: 230px;
            background-color: white;
           
        }

        .commentbox2 {
            display: inline-block;
            width: 364px;
            background-color: #f5f5f5;
            border: 1px solid;
        }

        .commentbox1 {
            display: inline-block;
            width: 490px;
            background-color: #f5f5f5;
            border: 1px solid;
        }

        .image_icon {
            position: relative;
            width: 50px;
            height: 50px;
            top: 10px;
            left: 10px;
        }

        .profile_pic_name {
            position: relative;
            font-size: 20px;
            font-family: initial;
            top: -20px;
            left: 23px;
            text-decoration: underline;
        }

        td {
            padding: 3px 5px;
            display: table-cell;
            text-align: left;
            vertical-align: middle;
            border-radius: 2px;
        }

        .comment_style {
            position: relative;
            left: 72px;
            top: -40px;
            word-wrap: break-word;
        }

        .enterComment {
            position: relative;
            width: 320px;
            top: 120px;
            left: 452px;
            overflow: auto;
        }
        .CommentImage1{
                position: relative;
    top: 19px;
    left: 10px;
    height: 45px;
    width: 45px;
        }
        .enterComment1{
                   position: relative;
    width: 301px;
    top: 24px;
    left: 17px;
    overflow: auto;
        }

        .CommentImage {
            position: relative;
            top: 120px;
            left: 451px;
            height: 45px;
            width: 45px;
        }

        .post_style {
            position: relative;
            left: 30px;
            top: -8px;
            word-wrap: break-word;
        }

        .post_pic_name {
            position: relative;
            font-size: 20px;
            font-family: initial;
            top: -5px;
            left: 23px;
            text-decoration: underline;
        }

        .post_pics {
                width: 467px;
    height: 402px;
    top: 0px;
    left: 10px;
    position: relative;
        }

        .commentbox3{
                display: inline-block;
    width: 365px;
    background-color: white;
    border: 1px solid;
        }
        .center5 {
            position: absolute;
            width: 372px;
            height: 570px;
            top: 76px;
            left: 977px;
            background-color: white;
            display:none;
        }

        .center6 {
                position: relative;
    width: 373px;
    height: 403px;
    top: 29px;
    background-color: rgba(224, 224, 224, 0.55);
    overflow: auto;
        }
        .deleteMessage{
                position: relative;
    top: -68px;
    left: 297px;
    text-decoration: underline;
    color:blue;

        }
        .Send{
               position: relative;
    font-size: 16px;
    top: 18px;
    left: 307px;
        }
         .insertComment{
                position: relative;
    top: 123px;
    left: 754px;
    text-decoration: underline;
    color: blue;
          }
         .view_post{
                 font-size: small;
    text-decoration: underline;
    left: 308px;
    top: -34px;
    position: relative;
         }

         .postcomments{
           background-color:white;
               width:100px;
             height:100px;
             position:relative;
         }
    </style>
</head>
<body>

    <form runat="server" novalidate="novalidate">
        <asp:ScriptManager ID="ScriptMgr" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div runat="server" id="MessageBoxDropDown" class="posts3">
            <asp:DataList ID="dlMessages" runat="server" CellPadding="3" CellSpacing="0">
                <ItemTemplate runat="server">
                    <div class="commentbox2">
                        <asp:Image ID="profileImage" runat="server" CssClass="image_icon" ImageUrl='<%# "~\\Profile_Pics\\"+ Eval("profile_pic") %>' />
                        <asp:Label ID="lblFriendName" CssClass="post_pic_name" runat="server" ForeColor="Black" Text='<%# Eval("u") %>'></asp:Label>
                        <br />
                        <br />
                        <asp:LinkButton Autosize="false" Dock="fill" ID="Comment" CssClass="post_style" runat="server" ForeColor="Black" OnClick="Open_MessageBox"
                            CommandArgument='<%# Bind("u") %>' Text='<%# Eval("c") + " unread messages" %>'></asp:LinkButton>

                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <ul>
                <li><a href="file:///C:/Ujwal%20Project/signup.html"></a></li>
                <li class="dropdown1">
                    <i class="material-icons" style="font-size: 60px; color: white;">arrow_drop_down</i>
                    <div class="dropdown1-content">
                        <a onclick="document.getElementById('id03').style.display='block'">Password Change</a>
                        <a href="#">Personal Info</a>
                        <a runat="server" id="Log_Out" href="#">Log Out</a>
                    </div>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="Messages_Show" Text="Messages" OnClick="abcd" /><span runat="server" id="badge" class="w3-badge w3-green"></span></li>
                <li>
                    <asp:LinkButton ID="btnLogout" Text="Friend Request" OnClick="Friend_Request" runat="server" /><span runat="server" id="badge1" class="w3-badge w3-green"></span></li>
                <li><a class="active" style="padding-right: 30px;">Home            </a></li>
            </ul>
            <div id="id01" class="w3-modal background">
                <div class="w3-modal-content center1">
                    <div class="w3-container">
                        <span onclick="document.getElementById('id01').style.display='none'" class="w3-closebtn w3-hover-red w3-container w3-padding-8 w3-display-topright" title="Close Modal">&times;</span>
                        <h2>Message</h2>
                        <br>
                        <br>
                        <div class="row">
                            <div class="col s12">
                                <div class="row">
                                    <div class="input-field col s12">
                                        <input name="to" type="text" class="validate">
                                        <label for="to">To</label>
                                    </div>
                                </div>
                                <br>
                                <asp:TextBox ID="TextArea3" TextMode="multiline" Columns="50" Rows="5" CssClass="posts2" runat="server" />
                                <asp:Button runat="server" ID="Message_Send_Button" OnClick="Send_Message" Text="Send" CssClass="waves-effect waves-light btn position1" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="id06" runat="server" class="center5">
                <span onclick="document.getElementById('id06').style.display='none'" class="w3-closebtn w3-hover-red w3-container w3-padding-8 w3-display-topright" title="Close Modal">&times;</span>
                <h3>Messages...</h3>
                <asp:Image runat="server" CssClass="CommentImage1" ID="Image2" />
                <asp:TextBox Placeholder="Write a Message..." onkeydown="commentTextBox_KeyDown" TextMode="multiline" Columns="50" Rows="5" ID="TextBox2" CssClass="enterComment1" runat="server" />
               <asp:LinkButton runat="server" ID="SendMessage" CssClass="Send" OnClick="send_The_Message" text="Send" Style="color:blue"></asp:LinkButton>
            
             <asp:UpdatePanel runat="server" ID="updatepanel1" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <Triggers>
                                
                            </Triggers>
                            <ContentTemplate>
                <div runat="server" id="id07" class="center6">
                    <asp:DataList ID="dlMessageBox" runat="server" CellPadding="3" CellSpacing="0">
                        <ItemTemplate runat="server">
                            <div class="commentbox3">
                                <asp:Image ID="profileImage" runat="server" CssClass="image_icon" ImageUrl='<%# "~\\Profile_Pics\\"+ Eval("profile_pic") %>' />
                                <asp:Label ID="lblFriendName" CssClass="profile_pic_name" runat="server" ForeColor="Black" Text='<%# Eval("user_from") %>'></asp:Label>
                                <br />
                                <br />
                                <asp:LinkButton Autosize="false"  Dock="fill" ID="msgDeleteButton" CssClass="deleteMessage" runat="server" ForeColor="Black" OnClick="msgDeleteButton"
                            CommandArgument='<%# Eval("msg_id") + "," + Eval("user_from") %>' style="color:blue" Text='Delete'></asp:LinkButton>
                                <asp:Label Autosize="false" Dock="fill" ID="Comment" CssClass="comment_style" runat="server" ForeColor="Black" Text='<%# Eval("msg") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            
                                </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


            <div runat="server" id="id02" class="w3-modal background">
                <div class="w3-modal-content center4">
                    <div class="w3-container">
                        <span onclick="document.getElementById('id02').style.display='none'" class="w3-closebtn w3-hover-red w3-container w3-padding-8 w3-display-topright" title="Close Modal">&times;</span>
                        <div runat="server" class="profilepicholder" id="Profile_Pic_Location">
                            <asp:Image runat="server" ID="Enlarged_Profile_Picture" ImageUrl="profile1.png" CssClass="profilepic" />
                          <asp:LinkButton runat="server" Text="Comment" ID="Enter_Comments" OnClick="Enter_The_Comment" CssClass="insertComment"></asp:LinkButton>
                             <asp:ImageButton runat="server" CssClass="like" OnClick="LikeImage" ID="Like_Button" ImageUrl="like.png" />
                        </div>
                        <asp:UpdatePanel runat="server" ID="updatepanel" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Like_Button" />
                                <asp:AsyncPostBackTrigger ControlID="Enter_Comments" />
                            </Triggers>
                            <ContentTemplate>
                                <span runat="server" class="likes">Likes: <span runat="server" id="noOfLikes">0</span></span>
                                <span runat="server" class="comments">Comments:<span runat="server" id="noOfComments">0</span></span>
                               <asp:Image runat="server" CssClass="CommentImage" ID="Comment_Image" />
                                <asp:TextBox Placeholder="Write a Comment..." onkeydown="commentTextBox_KeyDown" TextMode="multiline" Columns="50" Rows="5" ID="commentTextBox" CssClass="enterComment" runat="server" />
                                <div runat="server" id="picCommentSection" class="profilepiccomment">
                                    <asp:DataList ID="dlComments" runat="server" CellPadding="3" CellSpacing="0">
                                        <ItemTemplate runat="server">
                                            <div class="commentbox">
                                                <asp:Image ID="profileImage" runat="server" CssClass="image_icon" ImageUrl='<%# "~\\Profile_Pics\\"+ Eval("profile_pic") %>' />
                                                <asp:Label ID="lblFriendName" CssClass="profile_pic_name" runat="server" ForeColor="Black" Text='<%# Eval("first_name") %>'></asp:Label>
                                                <br />
                                                <br />
                                                <asp:Label Autosize="false" Dock="fill" ID="Comment" CssClass="comment_style" runat="server" ForeColor="Black" Text='<%# Eval("Comment") %>'></asp:Label>

                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <div id="id03" class="w3-modal background">
                <div class="w3-modal-content center2">
                    <div class="w3-container">
                        <span onclick="document.getElementById('id03').style.display='none'" class="w3-closebtn w3-hover-red w3-container w3-padding-8 w3-display-topright" title="Close Modal">&times;</span>
                        <h2>Password Change</h2>
                        <br>
                        <br>
                        <div class="row">
                            <div class="col s12">
                                <div class="row">
                                    <div class="input-field col s12">
                                        <input name="password" type="password" class="validate" required>
                                        <label for="password">Old Password<span class="req">*</span></label>
                                    </div>
                                </div>
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
                                <asp:Button runat="server" ID="Change_Password_Button" OnClick="Change_Password" Text="Change" CssClass="waves-effect waves-light btn position2" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="id04" class="w3-modal background">
                <div class="w3-modal-content center1">
                    <div class="w3-container">
                        <span onclick="document.getElementById('id04').style.display='none'" class="w3-closebtn w3-hover-red w3-container w3-padding-8 w3-display-topright" title="Close">&times;</span>
                        <h2>Change Profile Pic</h2>
                        <br>
                        <br>
                        <asp:FileUpload ID="FileUpload1" runat="server" OnChange="Change_Pic" />
                        <asp:Image runat="server" ID="Image1" CssClass="profile" ImageUrl="profile1.png" />
                        <asp:Button runat="server" ID="Button1" OnClick="Selected_Profile_Pic" Text="Change" CssClass="waves-effect waves-light btn position3" />
                    </div>
                </div>
            </div>
             
            
            <nav>
                <div class="nav-wrappers pad bgwhite">
                    <div>
                        <div class="input-field searchbar pad bgwhite">
                            <input class="bgwhite pad" name="search" type="search">
                            <label for="search"><i class="material-icons"></i></label>
                            <i class="material-icons"></i>
                        </div>
                        <asp:ImageButton runat="server" CssClass="image" OnClick="Search_Name" ID="Search_Button" ImageUrl="search.png" />
                    </div>
                </div>
            </nav>
            
              <div runat="server" id="id05" class="w3-modal background"  style="display:none;">
                <div class="w3-modal-content center4">
                    <div class="w3-container">
                        <span onclick="document.getElementById('id05').style.display='none'" class="w3-closebtn w3-hover-red w3-container w3-padding-8 w3-display-topright" title="Close Modal">&times;</span>
                        <div runat="server" class="profilepicholder" id="Post_Pic_Location">
                            <asp:Image runat="server" ID="Enlarged_Post_pic" ImageUrl="profile1.png" CssClass="profilepic" />
                            <asp:LinkButton runat="server" Text="Comment" ID="Enter_Comment" OnClick="Enter_The_Comment1" CssClass="insertComment"></asp:LinkButton>
                            <asp:ImageButton runat="server" CssClass="like" OnClick="LikeImage" ID="Like_Button1" ImageUrl="like.png" />
                        </div>
                        <asp:UpdatePanel runat="server" ID="updatepanel3" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Enter_Comment" />
                            </Triggers>
                            <ContentTemplate>
                                <span runat="server" class="likes">Likes: <span runat="server" id="noOfLikesPost">0</span></span>
                                <span runat="server" class="comments">Comments:<span runat="server" id="noOfCommentsPost">0</span></span>
                                <asp:Image runat="server" CssClass="CommentImage" ID="Post_Comment_Pic" />
                                <asp:TextBox Placeholder="Write a Comment..." onkeydown="commentTextBox_KeyDown" TextMode="multiline" Columns="50" Rows="5" ID="TextBox1" CssClass="enterComment" runat="server" />
                                <div runat="server" id="Div3" class="profilepiccomment">
                                    <asp:DataList ID="dlPosts1" runat="server" CellPadding="3" CellSpacing="0">
                                        <ItemTemplate runat="server">
                                            <div class="commentbox">
                                                <asp:Image ID="profileImage" runat="server" CssClass="image_icon" ImageUrl='<%# "~\\Profile_Pics\\"+ Eval("profile_pic") %>' />
                                                <asp:Label ID="lblFriendName" CssClass="profile_pic_name" runat="server" ForeColor="Black" Text='<%# Eval("first_name") %>'></asp:Label>
                                                <br />
                                                <br />
                                                <asp:Label Autosize="false" Dock="fill" ID="Comment" CssClass="comment_style" runat="server" ForeColor="Black" Text='<%# Eval("comment") %>'></asp:Label>
                                                
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <asp:ImageButton runat="server" ID="ProfilePic" CssClass="image1" ImageUrl="profile1.png" OnClick="DisplayEnlargedProfilePic" />

            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="postPictureButton" />
            <a onclick="document.getElementById('id04').style.display='block'" class="waves-effect waves-light btn new2 borders">Change Profile Pic</a>
            <asp:Button runat="server" ID="Info_Button" OnClick="ChangeInfo" Text="Info" CssClass="waves-effect waves-light btn new3 borders" />
            <a onclick="document.getElementById('id01').style.display='block'" class="waves-effect waves-light btn new5 borders">Send Message</a>
            <asp:TextBox ID="TextArea1" TextMode="multiline" Columns="50" Rows="5" CssClass="posts" runat="server" Placeholder="Whats On Your Mind" />
            <asp:Button runat="server" ID="Post_Button" OnClick="Post_Content" Text="Post" CssClass="waves-effect waves-light btn new4 borders" />
            <div class="posttext">Posts.....</div>
            
            <asp:UpdatePanel runat="server" ID="updatepanel2" UpdateMode="Conditional" ChildrenAsTriggers="false" >
                
                <ContentTemplate>
                    <div class="posts1" runat="server" id="postArea">
                        <asp:DataList ID="dlPosts" runat="server" CellPadding="3" CellSpacing="0"  >
                            <ItemTemplate runat="server">
                                <div class="commentbox1">
                                    <asp:Image ID="profileImage" runat="server" CssClass="image_icon" ImageUrl='<%# "~\\Profile_Pics\\"+ Eval("profile_pic") %>' />
                                    <asp:Label ID="lblFriendName" CssClass="post_pic_name" runat="server" ForeColor="Black" Text='<%# Eval("user_to").ToString()==Eval("user_from").ToString()?Eval("user_from"):Eval("user_from") + "  ->  " +Eval("user_to") %>'></asp:Label>
                                    <br />
                                    <asp:LinkButton CommandArgument='<%# Eval("post_id") + "\\"+ Eval("post_pic") %>' runat="server" ID="viewComments" CssClass="view_post" Text="View Comments And Likes" OnClick="View_Post"></asp:LinkButton>
                                    <br />
                                    <asp:Label Autosize="false" Dock="fill" ID="Comment" CssClass="post_style" runat="server" ForeColor="Black" Text='<%# Eval("post") %>'></asp:Label>
                                    <asp:ImageButton runat="server" CommandArgument='<%# Eval("post_id") + "\\" + Eval("post_pic") %>' OnCommand="DisplayEnlargedPic" 
                                        CssClass="post_pics" ID="post_picture" Visible='<%# Eval("post_pic").ToString()==""?false:true %>' ImageUrl='<%# "~\\Profile_Pics\\"+ Eval("post_pic") %>' />
                                   <asp:LinkButton runat="server" ID="postLike" Text="Like" OnClick="ujwal"></asp:LinkButton>
                                                <asp:Panel runat="server" id="PostComments" class="postcomments" visible="false"></asp:Panel>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

</body>
</html>
