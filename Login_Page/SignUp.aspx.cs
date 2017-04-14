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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Submit_Form(object sender, EventArgs e)
        {
            
            string Username = Request.Form["user_name"];
            string Firstname = Request.Form["first_name"];
            string Lastname = Request.Form["last_name"];
            string Email = Request.Form["email"];
            string Password = Request.Form["password"];
            string Gender;
            if (MaleButton.Checked)
                Gender = "Male";
            else
                Gender = "Female";
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            string query = "INSERT INTO users(user_name, first_name, last_name, password, email,Gender) VALUES ( '" + Username + "','" + Firstname + "','" + Lastname + "','" + Password + "','" + Email + "','" + Gender + "')";
            MySqlDataReader reader;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "SELECT * FROM users where user_name=@id";
            commandDatabase.Parameters.AddWithValue("@id", Username);
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show(" ' " + Username + " ' exists.Please try another Username");
                    databaseConnection.Close();
                }
                else
                {
                    databaseConnection.Close();
                    MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase1 = new MySqlCommand(query, databaseConnection2);
                    try
                    {
                        databaseConnection2.Open();
                        MySqlDataReader myReader1 = commandDatabase1.ExecuteReader();
                        databaseConnection2.Close();
                        System.IO.File.AppendAllText(@"C:\Ujwal Project\Usernames.txt", Username + Environment.NewLine);
                        Session["username"] = Username;
                        Response.Redirect("~/Self_Home.aspx", false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MaleButton.Checked = false;
            FemaleButton.Checked = false;
        }
    }
}