<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Other_Home.aspx.cs" Inherits="Login_Page.Other_Home" %>

<!DOCTYPE html>
<html>
    <title>Other's Home</title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css">
<head>
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.8/css/materialize.min.css">
    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.8/js/materialize.min.js"></script>
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



        nav .input-field {
            margin: 0;
            height: 76px;
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
            left: 125px;
            top: 378px;
        }

        .new3 {
            position: absolute;
            left: 76px;
            top: 435px;
        }
        .new6 {
            position: absolute;
            left: 182px;
            top: 475px;
            text-decoration: underline;
            color: black;
            font-size: large;
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

        .posts1 {
            border: 3px solid #021a40;
            transition: box-shadow .25s;
            padding-top: 50px;
            margin: 0.5rem 0 1rem 0;
            background-color: #fff;
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

        .center2 {
            transition: box-shadow .25s;
            padding-top: 20px;
            margin: 0.5rem 0 1rem 0;
            background-color: white;
            width: 491px;
            height: 576px;
            position: absolute;
            top: 50px;
            left: 450px;
            overflow:auto;
        }

        .position1 {
            position: absolute;
            top: 500px;
            left: 190px;
        }

        .position2 {
            position: absolute;
            top: 500px;
            left: 190px;
        }

        .like {
            width: 50px;
            height: 50px;
            left: 60px;
            top: 380px;
            position: absolute;
        }

        .unlike {
            width: 50px;
            height: 50px;
            left: 140px;
            top: 380px;
            position: absolute;
        }

        .w3-closebtn1 {
            text-decoration: none;
            float: right;
            font-size: 24px;
            font-weight: bold;
            color: white;
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
         .profilepic {
            position: absolute;
            width: 350px;
            height: 400px;
            left: 50px;
            top: 50px;
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

        .commentbox1 {
            display: inline-block;
            width: 490px;
            background-color: white;
        }

        .image_icon {
            position: relative;
            width: 50px;
            height: 50px;
            top: 10px;
            left: 10px;
        }
            .likes {
            left: 489px;
            top: 110px;
            position: absolute;
            font-family: Arial;
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
            top: 125px;
            left: 452px;
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
            width: 361px;
            height: 400px;
            top: 13px;
            left: 10px;
            position: relative;
        }
         .profilepicholder {
            background-color: black;
            position: absolute;
            width: 450px;
            height: 500px;
            left: 0px;
            top: 0px;
        }
          .postPictureButton {
            position: absolute;
            left: 645px;
            top: 329px;
        }
          .insertComment{
                position: relative;
    top: 123px;
    left: 754px;
    text-decoration: underline;
    color: blue;
          }
          .info_title{
              position:relative;
              left:30px;
          }
          .infoLabel{
                     position: relative;
    left: 170px;
    height: 30px;
    width: 275px;
    /* word-wrap: break-word; */
    border-width: inherit;
    top:-5px;

          }
    </style>
</head>
<body>
    <form runat="server" novalidate>
        <asp:ScriptManager ID="ScriptMgr" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <ul>
            <li><a href="file:///C:/Ujwal%20Project/signup.html">Log Out</a></li>
            <li class="dropdown1">
                <a class="dropbtn1">Settings</a>
                <div class="dropdown1-content">
                    <a onclick="document.getElementById('id03').style.display='block'">Password Change</a>
                    <a href="#">Personal Info </a>

                </div>
            </li>
            <li><a href="#">Messages</a></li>
            <li><a href="#about">Friend Requests</a></li>
            <li><a class="active" href="#home">Home</a></li>
        </ul>
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
        <div id="id04" runat="server" class="w3-modal background">
            <div class="w3-modal-content center2">
                <div class="w3-container">
                    <span onclick="document.getElementById('id04').style.display='none'" class="w3-closebtn w3-hover-red w3-container w3-padding-8 w3-display-topright" title="Close Modal">&times;</span>
                    <h3>Info..</h3>
                      <div class="info_title" style="top:20px">Name </div> 
                          <asp:TextBox  TextMode="MultiLine" runat="server" Columns="50" Rows="1" ID="nameTextBox" CssClass="infoLabel" ReadOnly="true" />
                     
                    <div class="info_title" style="top:20px">Birthday  </div>
                         <asp:TextBox  TextMode="MultiLine" runat="server" Columns="50" Rows="1" ID="birthdayTextBox" CssClass="infoLabel" ReadOnly="true" />
                    
                    <div class="info_title" style="top:20px">Phone Number  </div>
                         <asp:TextBox  TextMode="MultiLine" runat="server" Columns="50" Rows="1" ID="phoneTextBox" CssClass="infoLabel" ReadOnly="true" />
                    
                    <div class="info_title" style="top:20px">Profession  </div>
                         <asp:TextBox  TextMode="MultiLine" runat="server" Columns="50" Rows="1" ID="professionTextBox" CssClass="infoLabel" ReadOnly="true" />
                    
                    <div class="info_title" style="top:20px">Studies(d)  </div>
                         <asp:TextBox  TextMode="MultiLine" runat="server" Columns="50" Rows="1" ID="studiedTextBox" CssClass="infoLabel" ReadOnly="true" />
                    
                    <div class="info_title" style="top:20px">Lives In  </div>
                         <asp:TextBox  TextMode="MultiLine" runat="server" Columns="50" Rows="1" ID="livesInTextBox" CssClass="infoLabel" ReadOnly="true" />
                    
                    <div class="info_title" style="top:20px">From  </div>
                         <asp:TextBox  TextMode="MultiLine" runat="server" Columns="50" Rows="1" ID="fromTextBox" CssClass="infoLabel" ReadOnly="true" />
                    
                    <div class="info_title" style="top:20px">Interests  </div>
                         <asp:TextBox  TextMode="MultiLine" runat="server" Columns="50" Rows="1" ID="interestTextBox" CssClass="infoLabel" style="height:90px" ReadOnly="true" />
                      
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
       <asp:FileUpload ID="FileUpload2" runat="server" CssClass="postPictureButton"  />
        <asp:ImageButton runat="server" ID="ProfilePic" CssClass="image1" ImageUrl="profile1.png" OnClick="DisplayEnlargedPic" />

          <div runat="server" id="id02" class="w3-modal background">
                <div class="w3-modal-content center4">
                    <div class="w3-container">
                        <span onclick="document.getElementById('id02').style.display='none'" class="w3-closebtn w3-hover-red w3-container w3-padding-8 w3-display-topright" title="Close Modal">&times;</span>
                        <div runat="server" class="profilepicholder" id="Profile_Pic_Location">
                            <asp:Image runat="server" ID="Enlarged_Profile_Picture" ImageUrl="profile1.png" CssClass="profilepic" />
                            <asp:LinkButton runat="server" Text="Comment" ID="Enter_Comment" OnClick="Enter_The_Comment" CssClass="insertComment"></asp:LinkButton>
                            <asp:ImageButton runat="server" CssClass="like" OnClick="LikeImage" ID="Like_Button" ImageUrl="like.png" />
                        </div>
                        <asp:UpdatePanel runat="server" ID="updatepanel" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Like_Button" />
                                <asp:AsyncPostBackTrigger ControlID="Enter_Comment" />
                           
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

        <asp:Button runat="server" ID="Check_Info_Button" CausesValidation="false" OnClick="Check_Info" Text="Info" CssClass="waves-effect waves-light btn new2 borders" />
        <asp:Button runat="server" ID="Send_Request_Button" CausesValidation="false" OnClick="Send_Request" Text="Send Request" CssClass="waves-effect waves-light btn new3 borders" />
        <asp:LinkButton runat="server" ID="Cancel_Link" Visible="false" CausesValidation="false" OnClick="Cancel_Request" Text="Cancel Request" CssClass=" new6" />
        <asp:TextBox ID="TextArea1" TextMode="multiline" Columns="50" Rows="5" CssClass="posts" runat="server" Placeholder="Whats On Your Mind!!"/>
        <asp:Button runat="server" ID="Post_Button" CausesValidation="false" OnClick="Post_Matter" Text="Post" CssClass="waves-effect waves-light btn new4 borders" />
        <div class="posttext">Posts.....</div>
        <asp:UpdatePanel runat="server" ID="updatepanel2" UpdateMode="Conditional">
                <Triggers>
                    <asp:PostBackTrigger ControlID="Post_Button" />
                    
                </Triggers>
                <ContentTemplate>
                    <div class="posts1" runat="server" id="postArea">
                        <asp:DataList ID="dlPosts" runat="server" CellPadding="3" CellSpacing="0">
                            <ItemTemplate runat="server">
                                <div class="commentbox1">
                                    <asp:Image ID="profileImage" runat="server" CssClass="image_icon" ImageUrl='<%# "~\\Profile_Pics\\"+ Eval("profile_pic") %>' />
                                    <asp:Label ID="lblFriendName" CssClass="post_pic_name" runat="server" ForeColor="Black" Text='<%# Eval("user_to").ToString()==Eval("user_from").ToString()?Eval("user_from"):Eval("user_from") + "  ->  " +Eval("user_to") %>'></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label Autosize="false" Dock="fill" ID="Comment" CssClass="post_style" runat="server" ForeColor="Black" Text='<%# Eval("post") %>'></asp:Label>
                                    <asp:ImageButton runat="server" CommandArgument='<%# Bind("post_pic") %>'  CommandName="DisplayEnlargedPic"
                                     CssClass="post_pics" ID="post_picture" Visible='<%# Eval("post_pic").ToString()==""?false:true %>' ImageUrl='<%# "~\\Profile_Pics\\"+ Eval("post_pic") %>' />
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

    </form>
</body>
</html>

