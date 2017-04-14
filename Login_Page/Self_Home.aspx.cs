using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login_Page
{
    public partial class Self_Home : System.Web.UI.Page
    {
        static string MessageUser = "";//To store whose msg is currently being read used to insert
        public  string postId="";
        string Username = "";
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                Username = Session["username"].ToString();
            if (!Page.IsPostBack)
            {
                initializeProfilePics();
                //  initializeLikesAndComments();
                // Show_Comments_Profile_Pic(imageUrl);
                Show_Posts();
            }
          //  this.RegisterAsyncPostBackControl();
        }
        /*private void RegisterAsyncPostBackControl()
        {
            foreach (DataListItem item in dlPosts.Items)
            {
                LinkButton lnkFull = item.FindControl("viewComments") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lnkFull);
            }
        }*/
        private void Show_Posts()
        {
            MySqlDataReader reader;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select post_id,user_from,user_to,profile_pic,post_pic,post from posts,users where user_name=user_from and (user_from=@id1 or user_from in(select user_one from friends where user_two=@id1 and status=1 UNION SELECT user_two from friends where user_one=@id1 and status=1)) order by post_id desc;";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dlPosts.DataSource = reader;
                    dlPosts.DataBind();
                    
                    databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void buttonTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }
        private void commentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonTest_Click(this, new EventArgs());
            }
        }
        private void initializeLikesAndComments()
        {
            noOfLikes.InnerHtml = calculateLikes();
            noOfComments.InnerHtml = calculateComments();
        }
        private string calculateLikes()
        {
            string likes = "";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select count(*) from profile_pic_like where user_whose=@id1 AND image=@id2 AND action='like';";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", getProfilePic());
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    likes = reader.GetString(0);
                    reader.Close();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return likes;
        }
        private string calculateComments()
        {
            string comments = "";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select count(*) from pic_comment where user_whose=@id1 AND image=@id2;";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", getProfilePic());
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    comments = reader.GetString(0);
                    reader.Close();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return comments;
        }
        private void initializeProfilePics()
        {
            string imageUrl = getProfilePic();
            ProfilePic.ImageUrl = "~\\Profile_Pics\\" + imageUrl;
            //Enlarged_Profile_Picture.ImageUrl = ProfilePic.ImageUrl;
            //Comment_Image.ImageUrl = ProfilePic.ImageUrl;
        }
        private string getProfilePic()
        {
            string ImageUrl = "";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select profile_pic from users where user_name=@id1 ;";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    ImageUrl = reader.GetString(0);
                    reader.Close();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ImageUrl;
        }
        protected void DisplayEnlargedProfilePic(object sender, EventArgs e)
        {
            Enlarged_Profile_Picture.ImageUrl = ProfilePic.ImageUrl;
            Comment_Image.ImageUrl = ProfilePic.ImageUrl;
            initializeLikesAndComments();
            id02.Style.Add("display", "block");
            id06.Style.Add("display", "none");
            Show_Comments_Profile_Pic(getProfilePic());
        }
        protected void Selected_Profile_Pic(object sender, EventArgs e)
        {
            string fileName = "";
            if (FileUpload1.HasFile)
            {
                fileName = SaveFile(FileUpload1.PostedFile, FileUpload1);
                SaveInDatabase(fileName);
                //ProfilePic.ImageUrl =@"~\Profile_Pics\" + FileUpload1.FileName;
                //Enlarged_Profile_Picture.ImageUrl = @"~\Profile_Pics\" + FileUpload1.FileName; 
                ProfilePic.ImageUrl = @"~\Profile_Pics\" + fileName;
                Enlarged_Profile_Picture.ImageUrl = @"~\Profile_Pics\" + fileName;
            }
        }
        public string SaveFile(HttpPostedFile file, FileUpload FileUpload)
        {
            string savePath = @"C:\Users\Ujwal Gupta\Documents\Visual Studio 2013\Projects\Login_Page\Login_Page\Profile_Pics\";
            // Get the name of the file to upload.
            string fileName = FileUpload.FileName;
            string safe = fileName;
            string[] a = fileName.Split('.');
            
            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;
            fileName = a[0];
            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";
            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = fileName + counter.ToString() + "." + a[1];
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }
                fileName = tempfileName;
            }
            if (fileName == a[0])
                fileName = safe;
            // Append the name of the file to upload to the path.
            savePath += fileName;
            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            FileUpload.SaveAs(savePath);
            return fileName;
            //SaveInDatabase(fileName);
        }

        private void Show_Comments_Profile_Pic(string imageurl)
        {
            MySqlDataReader reader;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select profile_pic,Comment,first_name from users as u,pic_comment as p where p.user_from=u.user_name and p.user_whose= '" + Username + "' and image = '" + imageurl + "'order by cmt_id desc;";
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dlComments.DataSource = reader;
                    dlComments.DataBind();
                    databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SaveInDatabase(string fileName)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "update users set profile_pic = '" + fileName + "' where user_name=@id1 ;";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Change_Pic()
        {
            MessageBox.Show("Selected");
        }
        protected void ChangeInfo(object sender, EventArgs e)
        {
            Session["username"] = Username;
            Response.Redirect("~/About.aspx", false);
        }
        protected void Change_Password(object sender, EventArgs e)
        {
            string olp=Request.Form["password"];
            string newp = Request.Form["new_password"];
            string cnewp = Request.Form["confirm_password"];
            if (!iscorrectpassword(olp))
                MessageBox.Show("Enter the Correct Password!!!");
            else
            {
                if (newp != cnewp)
                    MessageBox.Show("Passwords Didn't Match :/:/");
                else
                    Change_The_Password_Finally(newp);
            }
           
        }

        private void Change_The_Password_Finally(string newp)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "update users set password=@id2 where user_name=@id1";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", newp);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
                MessageBox.Show("Password Changed Succesfully!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool iscorrectpassword(string olp)
        {
            string result = "";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select password from users where user_name=@id1";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.GetString(0);
                    reader.Close();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (result == olp)
                return true;
            return false;

        }
     /*   protected void dlPosts_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DisplayEnlargedPic")
            {
                MessageBox.Show("postImageUrl");
                //DataListItem item = dlPosts.Items[3] as DataListItem;
                //ImageButton imgbtn = item.FindControl("post_picture") as ImageButton;         
            }
        }*/
        protected void DisplayEnlargedPic(object sender,  CommandEventArgs e)
        {
            //MessageBox.Show("postImageUrl");
            id05.Style.Add("display", "block");
            string msg = ((ImageButton)sender).CommandArgument.ToString();
           // MessageBox.Show(msg);
            string[] p = msg.Split('\\');
            string p2 = p[1];
            string p1 = p[0];
            Enlarged_Post_pic.ImageUrl = "~\\Profile_Pics\\" + p2;
            Post_Comment_Pic.ImageUrl = "~\\Profile_Pics\\" + getProfilePic();
            
            noOfLikesPost.InnerHtml = calculateLikesPosts(p1);
            noOfCommentsPost.InnerHtml = calculateCommentsPosts(p1);
            Show_Comments_Posts(p1);
           // id05.Style.Add("display", "block");
            //string postImageUrl = (((System.Web.UI.WebControls.Button)sender).CommandArgument).ToString();
            //MessageBox.Show(postImageUrl);

        }
        protected void Search_Name(object sender, EventArgs e)
        {
            string UserTo = Request.Form["search"];
            Session["User_from"] = Username;
            Session["User_to"] = UserTo;
            Response.Redirect("~/Other_Home.aspx", false);
        }
        protected void Enter_The_Comment(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "insert into pic_comment (user_whose,image,user_from,Comment) values('" + Username + "','" + getProfilePic() + "','" + Username + "','" + commentTextBox.Text + "');";
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            commentTextBox.Text = "";
            Show_Comments_Profile_Pic(getProfilePic());
            initializeLikesAndComments();
        }
        private string getActionStatus(string imageurl)
        {
            string action = "";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select action from profile_pic_like where user_whose=@id1 AND user_from=@id2 and image=@id3;";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", Username);
            commandDatabase.Parameters.AddWithValue("@id3", imageurl);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    action = reader.GetString(0);
                    reader.Close();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return action;

        }
        private void deleteFromRecord(string p, string imageurl)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "delete from profile_pic_like where user_whose =@id1 and image=@id2 and user_from=@id3 and action=@id4;";
            commandDatabase.Parameters.AddWithValue("@id3", Username);
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", imageurl);
            commandDatabase.Parameters.AddWithValue("@id4", p);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected void LikeImage(object sender, EventArgs e)
        {
            string action = getActionStatus(getProfilePic());
            if (action == "like")
            {
                Like_Button.BorderWidth = 0;
                deleteFromRecord("like", getProfilePic());
            }
            //else if (action == "unlike")
            //{
            //  Like_Button.BorderWidth = 2;
            //Unlike_Button.BorderWidth = 0;
            //ChangeInLikesRecord("like", imageUrl);
            //}
            else
            {
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = databaseConnection.CreateCommand();
                commandDatabase.CommandText = "insert into profile_pic_like (user_whose,image,user_from,action) values(@id1,@id2,@id3,'like');";
                commandDatabase.Parameters.AddWithValue("@id3", Username);
                commandDatabase.Parameters.AddWithValue("@id1", Username);
                commandDatabase.Parameters.AddWithValue("@id2", getProfilePic());
                MySqlDataReader reader;
                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Show_Comments_Profile_Pic(getProfilePic());
            initializeLikesAndComments();
        }
        //protected void UnlikeImage(object sender, EventArgs e)
        //{
          //    <asp:ImageButton runat="server" CssClass="unlike" OnClick="UnlikeImage" ID="Unlike_Button" ImageUrl="unlike.jpg" />
                           
            //Change_Pic_Button.Text = "Changed";
        //}
        protected void Enlarge_The_Profile_Pic(object sender, EventArgs e)
        {
            id02.Visible = true;
        }
        protected void abcd(object sender, EventArgs e)
        {
            InitializeMessageBox();
            DeleteViews();
        }
        private void DeleteViews()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "drop view " + Username + 1 + "," + Username + 2 + "," + Username + 3 + "," + Username + 4 + "," + Username + 5 + "," + Username + 6 + "," + Username + 7 + "," + Username + 8 + "," + Username + 9 + "," + Username + 10 + " ";
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitializeMessageBox()
        {
            id02.Style.Add("display", "none");
            id06.Style.Add("display", "none");
            MessageBoxDropDown.Style.Add("display", "block");
            MySqlDataReader reader;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "create view " + Username + 1 + " as " +
            " SELECT user_from as u,msg_id as m from messages where user_from not in (SELECT DISTINCT user_to FROM messages where user_from='" + Username + "')" +
            "and user_to='" + Username + "' and msg_status=0;" +
            "create view " + Username + 2 + " AS " +
            " SELECT user_from as u,msg_id as m from messages where user_from in (SELECT DISTINCT user_to FROM messages where user_from='" + Username + "')" +
            "and user_to='" + Username + "' and msg_status=0;" +
            "CREATE view " + Username + 3 + " AS " +
            "SELECT user_from as u,msg_id as m from messages as m WHERE user_from not in (SELECT DISTINCT user_to FROM messages where user_from='" + Username + "') and" +
            "(SELECT count(*) from messages where user_from=m.user_from and msg_status=0 and user_to='" + Username + "') = 0 and user_to='" + Username + "';" +
            "CREATE view " + Username + 4 + " AS " +
            "SELECT user_from as u,msg_id as m from messages as m WHERE user_from in (SELECT DISTINCT user_to FROM messages where user_from='" + Username + "') and" +
            "(SELECT count(*) from messages where user_from=m.user_from and msg_status=0 and user_to='" + Username + "') = 0 and user_to='" + Username + "';" +
            "create view " + Username + 5 + " AS " +
            "SELECT user_to as u,msg_id as m from messages as m where user_from='" + Username + "' and (SELECT count(*) from messages where user_from=m.user_to and user_to='" + Username + "')=0;" +
            "create view " + Username + 6 + " AS " +
            "SELECT * from " + Username + 1 + " UNION SELECT * from " + Username + 2 + ";" +
            "create view " + Username + 7 + " AS " +
            "SELECT * from " + Username + 3 + " UNION SELECT * from " + Username + 4 + " UNION SELECT * from " + Username + 5 + ";" +
            "CREATE view " + Username + 8 + " AS " +
            "select u,max(m) as msg,count(*) as c from " + Username + 6 + " GROUP by u;" +
            "CREATE view " + Username + 9 + " AS " +
            "select u,max(m) as msg,(SELECT count(*) from messages where user_from='" + Username + "' and user_to='" + Username + "') as c from " + Username + 7 + " GROUP by u;" +
            "CREATE view " + Username + 10 + " AS " +
            "SELECT * from " + Username + 8 + " UNION SELECT * from " + Username + 9 + ";" +
            "SELECT profile_pic,u,msg,c from " + Username + 10 + ",users where users.user_name=" + Username + 10 + ".u order by msg desc;";
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dlMessages.DataSource = reader;
                    dlMessages.DataBind();
                    databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected void Post_Content(object sender, EventArgs e)
        {
            string fileName = "";
            if (FileUpload2.HasFile)
            {
                fileName = SaveFile(FileUpload2.PostedFile, FileUpload2);
            }
            string post = Request.Form["TextArea1"];
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "insert into posts (`user_to`, `user_from`, `post`,`post_pic`,`dateadded`) values ('" + Username + "','" + Username + "','" + post + "','" + fileName + "','" + DateTime.Now.ToString() + "');";
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TextArea1.Text = "";
            Show_Posts();
        }
        protected void Open_MessageBox(object sender, EventArgs e)
        {
            string x=((LinkButton)sender).CommandArgument.ToString();
            MessageUser = x;
            MessageBoxDropDown.Style.Add("display", "none");
            OpenMessageBoxOfUser(x);
        }
        protected void send_The_Message(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString();
            string message=TextBox2.Text;
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "insert into messages (user_from,user_to,msg,date_sent,msg_status) values(@id1,@id2,@id3,@id4,0);";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", MessageUser);
            commandDatabase.Parameters.AddWithValue("@id3", message);
            commandDatabase.Parameters.AddWithValue("@id4", date);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            openMessages(MessageUser);

        }
        protected void msgDeleteButton(object sender, EventArgs e)
        {
            DataListItem item = dlMessageBox.Items[0] as DataListItem;
            LinkButton imgbtn = item.FindControl("msgDeleteButton") as LinkButton;
            imgbtn.Text = "Deleted";
            AsyncPostBackTrigger lTrigger = new AsyncPostBackTrigger();
            lTrigger.ControlID = imgbtn.ID;
            AsyncPostBackTrigger lTrigger1 = new AsyncPostBackTrigger();
            lTrigger1.ControlID = SendMessage.ID;
            updatepanel1.Triggers.Add(lTrigger);
            updatepanel1.Triggers.Add(lTrigger1);

            /* <asp:AsyncPostBackTrigger ControlID="SendMessage" />*/
            string msg = ((LinkButton)sender).CommandArgument.ToString();
            string [] a=msg.Split(',');
            string x= a[0];           
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "delete from messages where msg_id='" + x + "'";
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string user_from = getUserFromMsgId(a[0],a[1]);
            openMessages(user_from);
        }

        private string getUserFromMsgId(string x,string y)
        {
            string user = "";
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select user_to from messages where user_from ='" + y + "' and msg_id='" + x + "' UNION select user_from from messages where user_to ='" + y + "' and msg_id='" + x + "' ";
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user = reader[0].ToString();
                    reader.Close();
                    databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return user;
        }
        
        private void OpenMessageBoxOfUser(string x)
        {
            Image2.ImageUrl = ProfilePic.ImageUrl;
            id06.Style.Add("display", "block");
            //Mark all as read
            MarkAllAsRead(x);
            //Then open all messages
            openMessages(x);
        }

        private void openMessages(string x)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "SELECT msg_id,user_from ,profile_pic,msg,date_sent from users,messages where users.user_name=user_from and ((user_to=@id1 and user_from=@id2) OR (user_from=@id1 and user_to=@id2)) order by msg_id desc;";
            commandDatabase.Parameters.AddWithValue("@id1", x);
            commandDatabase.Parameters.AddWithValue("@id2", Username);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dlMessageBox.DataSource = reader;
                    dlMessageBox.DataBind();
                    databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MarkAllAsRead(string x)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "update messages set msg_status=1 where user_from='"+ x +"' and user_to='" + Username + "' and msg_status=0";
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected void Send_Message(object sender, EventArgs e)
        {
            string To = Request.Form["to"];
            string msg = TextArea3.Text;
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "insert into messages(user_from,user_to,msg,msg_status,date_sent)values(@id1,@id2,@id3,'0',@id4); ";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", To);
            commandDatabase.Parameters.AddWithValue("@id3", msg);
            commandDatabase.Parameters.AddWithValue("@id4", DateTime.Now.ToString());
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
                MessageBox.Show("Message Sent!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        protected void Friend_Request(object sender, EventArgs e)
        {

            Session["Username"] = Username;
            Response.Redirect("~/Friends.aspx", false);
        }
        protected void View_Post(object sender, EventArgs e)
        {
            string msg = ((LinkButton)sender).CommandArgument.ToString();
            string[] a = msg.Split('\\');
            string x = a[1];
            if (x == "")
                MessageBox.Show("Normal Post");
            else
            {
                ShowEnlargedPostPic(a[0], a[1]);
            }
        }


       private void ShowEnlargedPostPic(string p1,string p2)
            {
                postId = p1;
 	            Enlarged_Post_pic.ImageUrl = "~\\Profile_Pics\\" +p2;
                Post_Comment_Pic.ImageUrl = "~\\Profile_Pics\\" + getProfilePic();
                id05.Style.Add("display", "block");
               // id02.Style.Add("display", "block");
                id06.Style.Add("display", "none");
                MessageBox.Show("Hello");
                //noOfLikesPost.InnerHtml = calculateLikesPosts(p1);
                //noOfCommentsPost.InnerHtml = calculateCommentsPosts(p1);
                //Show_Comments_Posts(p1);
             }

       private string calculateLikesPosts(string p1)
       {
           string likes = "";
           MySqlConnection databaseConnection = new MySqlConnection(connectionString);
           MySqlCommand commandDatabase = databaseConnection.CreateCommand();
           commandDatabase.CommandText = "select count(*) from post_like where post_id=@id1;";
           commandDatabase.Parameters.AddWithValue("@id1", p1);
           MySqlDataReader reader;
           try
           {
               databaseConnection.Open();
               reader = commandDatabase.ExecuteReader();
               if (reader.HasRows)
               {
                   reader.Read();
                   likes = reader.GetString(0);
                   reader.Close();
               }
               databaseConnection.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
           return likes;
       }
       private string calculateCommentsPosts(string p1)
       {
           string comments = "";
           MySqlConnection databaseConnection = new MySqlConnection(connectionString);
           MySqlCommand commandDatabase = databaseConnection.CreateCommand();
           commandDatabase.CommandText = "select count(*) from post_comment where post_id=@id1;";
           commandDatabase.Parameters.AddWithValue("@id1", p1);
           MySqlDataReader reader;
           try
           {
               databaseConnection.Open();
               reader = commandDatabase.ExecuteReader();
               if (reader.HasRows)
               {
                   reader.Read();
                   comments = reader.GetString(0);
                   reader.Close();
               }
               databaseConnection.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
           return comments;
       }
       private void Show_Comments_Posts(string p1)
       {
           MySqlDataReader reader;
           MySqlConnection databaseConnection = new MySqlConnection(connectionString);
           MySqlCommand commandDatabase = databaseConnection.CreateCommand();
           commandDatabase.CommandText = "select profile_pic,comment,first_name from users as u,post_comment as p where p.user_who=u.user_name and p.post_id= '" + p1 + "' order by p_id desc;";
           try
           {
               databaseConnection.Open();
               reader = commandDatabase.ExecuteReader();
               if (reader.HasRows)
               {
                   dlPosts1.DataSource = reader;
                   dlPosts1.DataBind();
                   databaseConnection.Close();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }
       protected void Enter_The_Comment1(object sender, EventArgs e)
       {
           string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
           MySqlConnection databaseConnection = new MySqlConnection(connectionString);
           MySqlCommand commandDatabase = databaseConnection.CreateCommand();
           commandDatabase.CommandText = "insert into post_comment (post_id,user_who,comment) values('" + postId + "','" + Username + "','" + TextBox1.Text + "');";
           MySqlDataReader reader;
           try
           {
               databaseConnection.Open();
               reader = commandDatabase.ExecuteReader();
               databaseConnection.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
           TextBox1.Text = "";
           Show_Comments_Posts(postId);
           noOfLikesPost.InnerHtml = calculateLikesPosts(postId);
           noOfCommentsPost.InnerHtml = calculateCommentsPosts(postId);
               
       }
       protected void ujwal(object sender, EventArgs e)
       {
           
           DataListItem item = dlPosts.Items[0] as DataListItem;
           System.Web.UI.WebControls.Panel imgbtn = item.FindControl("PostComments") as System.Web.UI.WebControls.Panel;
           imgbtn.Visible = true;     
       }
        
    }
}