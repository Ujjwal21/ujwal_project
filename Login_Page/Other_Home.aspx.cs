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
    public partial class Other_Home : System.Web.UI.Page
    {
        string imageUrl = "";
        string userfrom = "";
        string Username = "";
        string status = "";
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Session["User_from"]!=null)
                userfrom = Session["User_from"].ToString();
            if(Session["User_to"]!=null)
                Username = Session["User_to"].ToString();
            imageUrl = getProfilePic();
            InitializeFriendRequestButton();
            InitializeProfilePics();
            Show_Posts();
        }

        private void InitializeProfilePics()
        {
            
            ProfilePic.ImageUrl = "~\\Profile_Pics\\" + imageUrl;
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

        private void InitializeFriendRequestButton()
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select status from friends where (user_one=@id1 AND user_two=@id2) OR (user_one=@id2 AND user_two=@id1);";
            commandDatabase.Parameters.AddWithValue("@id1", userfrom);
            commandDatabase.Parameters.AddWithValue("@id2", Username);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    status = reader.GetString(0);
                    if (status == "1")
                    {
                        Send_Request_Button.Text = "Friends ;)";
                        Send_Request_Button.Enabled = false;
                    }
                    else if (status == "0")
                    {
                        Send_Request_Button.Text = "Friend Request Sent";
                        Send_Request_Button.Enabled = false;
                        Cancel_Link.Visible = true;
                    }
                    reader.Close();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected void DisplayEnlargedPic(object sender, EventArgs e)
        {
            Enlarged_Profile_Picture.ImageUrl = ProfilePic.ImageUrl;
            Comment_Image.ImageUrl = ProfilePic.ImageUrl;
            initializeLikesAndComments();
            id02.Style.Add("display", "block");
            Show_Comments_Profile_Pic(imageUrl);
        }
        protected void Enter_The_Comment(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "insert into pic_comment (user_whose,image,user_from,Comment) values('" + Username + "','" + imageUrl + "','" + userfrom + "','" + commentTextBox.Text + "');";
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
            Show_Comments_Profile_Pic(imageUrl);
            initializeLikesAndComments();
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
        private void initializeLikesAndComments()
        {
            noOfLikes.InnerHtml = calculateLikes();
            noOfComments.InnerHtml = calculateComments();
            string action = getActionStatus(imageUrl);
            if (action == "like")
                Like_Button.BorderWidth = 2;
           // else if (action == "unlike")
             //   Unlike_Button.BorderWidth = 2;
        }
        private string calculateLikes()
        {
            string likes = "";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select count(*) from profile_pic_like where user_whose=@id1 AND image=@id2 AND action='like';";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", imageUrl);
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
        protected void Post_Matter(object sender, EventArgs e)
        {
            string fileName = "";
            if (FileUpload2.HasFile)
            {
                MessageBox.Show(FileUpload2.FileName);
                fileName = SaveFile(FileUpload2.PostedFile, FileUpload2);
            }
            MessageBox.Show(fileName);
            string post = Request.Form["TextArea1"];
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "insert into posts (`user_to`, `user_from`, `post`,`post_pic`,`dateadded`) values ('" + Username + "','" + userfrom + "','" + post + "','" + fileName + "','" + DateTime.Now.ToString() + "');";
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
            Show_Posts();
        }
        private void Show_Posts()
        {
            MySqlDataReader reader;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select user_from,user_to,profile_pic,post_pic,post from posts,users where user_name=user_from and (user_from=@id1 or user_to=@id1 ) order by post_id desc;";
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
        protected void Send_Request(object sender, EventArgs e)
        {
            
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = databaseConnection.CreateCommand();
                commandDatabase.CommandText = "insert into friends(user_one,user_two,status) values(@id1,@id2,'0');";
                commandDatabase.Parameters.AddWithValue("@id1", userfrom);
                commandDatabase.Parameters.AddWithValue("@id2", Username);
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
                Send_Request_Button.Text = "Friend Request Send";
                Send_Request_Button.Enabled = false;
                Cancel_Link.Visible = true;

            
        }
        protected void Cancel_Request(object sender, EventArgs e)
        {
            Cancel_Link.Visible = false;
            Send_Request_Button.Enabled = true;
            Send_Request_Button.Text = "Send Request";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "delete from friends where user_one=@id1 and user_two=@id2;";
            commandDatabase.Parameters.AddWithValue("@id1", userfrom);
            commandDatabase.Parameters.AddWithValue("@id2", Username);
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
        protected void Check_Info(object sender, EventArgs e)
        {
            id04.Style.Add("display", "block");
            MySqlDataReader reader;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select * from about where username=@id1";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    nameTextBox.Text = reader[0].ToString();
                    birthdayTextBox.Text = reader[1].ToString();
                    phoneTextBox.Text = reader[2].ToString();
                    interestTextBox.Text = reader[3].ToString();
                    professionTextBox.Text = reader[4].ToString();
                    studiedTextBox.Text = reader[5].ToString();
                    livesInTextBox.Text = reader[6].ToString();
                    fromTextBox.Text = reader[7].ToString();
                    reader.Close();
                    databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        protected void LikeImage(object sender, EventArgs e)
        {
            string action = getActionStatus(imageUrl);
            if(action=="like")
            {
                Like_Button.BorderWidth = 0;
                deleteFromRecord("like",imageUrl);
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
                commandDatabase.Parameters.AddWithValue("@id3", userfrom);
                commandDatabase.Parameters.AddWithValue("@id1", Username);
                commandDatabase.Parameters.AddWithValue("@id2", imageUrl);
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
            Show_Comments_Profile_Pic(imageUrl);
            initializeLikesAndComments();
        }

        private void ChangeInLikesRecord(string p, string imageurl)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "update profile_pic_like set action=@id4 where user_whose=@id1 and image=@id2 and user_from=@id3 ;";
            commandDatabase.Parameters.AddWithValue("@id3", userfrom);
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

        private void deleteFromRecord(string p, string imageurl)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "delete from profile_pic_like where user_whose =@id1 and image=@id2 and user_from=@id3 and action=@id4;";
            commandDatabase.Parameters.AddWithValue("@id3", userfrom);
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", imageurl);
            commandDatabase.Parameters.AddWithValue("@id4",p );
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

        private string getActionStatus(string imageurl)
        {
            string action = "";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select action from profile_pic_like where user_whose=@id1 AND user_from=@id2 and image=@id3;";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", userfrom);
            commandDatabase.Parameters.AddWithValue("@id3",imageurl );
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
       // protected void UnlikeImage(object sender, EventArgs e)
        //{
        //<asp:ImageButton runat="server" CssClass="unlike" OnClick="UnlikeImage" ID="Unlike_Button" ImageUrl="unlike.jpg" />
          //  Check_Info_Button.Text = "Like";
        //}
        protected void Search_Name(object sender, EventArgs e)
        {
            string name = Request.Form["search"];
            MessageBox.Show(name);
            Check_Info_Button.Text = "Searched";
        }
        protected void Change_Password(object sender, EventArgs e)
        {
            
        }
        
    }
}