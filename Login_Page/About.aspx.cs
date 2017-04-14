using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Login_Page
{

    public partial class About : System.Web.UI.Page
    {
        string Username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                  Username = Session["username"].ToString();
                fillTheTextBoxes(Select());
            }
        }

        private void fillTheTextBoxes(List<string> list)
        {
            BirthdayTextbox.Text = list[0].ToString();
            TextBox1.Text = list[1].ToString();
            TextBox2.Text = list[2].ToString();
            TextBox3.Text = list[3].ToString();
            TextBox4.Text = list[4].ToString();
            TextBox5.Text = list[5].ToString();
            TextBox6.Text = list[6].ToString();
        }
        public List<string> Select()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "select  `birthday`, `phone_no`, `interested_in`, `profession`, `studied`, `lives_in`,`from_where` from about where username=@id1";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            MySqlDataReader reader;
            //Create a list to store the result
            List<string> list=new List<string>();

            //Open connection
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                
                while (reader.HasRows)
                {
                    reader.Read();
                    list.Add(reader["birthday"].ToString());
                    list.Add(reader["phone_no"].ToString());
                    list.Add(reader["interested_in"].ToString());
                    list.Add(reader["profession"].ToString());
                    list.Add(reader["studied"].ToString());
                    list.Add(reader["lives_in"].ToString());
                    list.Add(reader["from_where"].ToString());
                    reader.Close();
                databaseConnection.Close();
                  }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }
        protected void Save_Info(object sender, EventArgs e)
        {
            MessageBox.Show(TextBox2.Text);
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "update about set birthday=@id2,phone_no=@id3,interested_in=@id4,profession=@id5,studied=@id6,lives_in=@id7,from_where=@id8 where username=@id1;";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", BirthdayTextbox.Text.ToString());
            commandDatabase.Parameters.AddWithValue("@id3", TextBox1.Text.ToString());
            commandDatabase.Parameters.AddWithValue("@id4", TextBox2.Text);
            commandDatabase.Parameters.AddWithValue("@id5", TextBox3.Text);
            commandDatabase.Parameters.AddWithValue("@id6", TextBox4.Text);
            commandDatabase.Parameters.AddWithValue("@id7", TextBox5.Text);
            commandDatabase.Parameters.AddWithValue("@id8", TextBox6.Text);
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
    }
}
