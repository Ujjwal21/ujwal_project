using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Login_Page
{
public partial class Friends : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Username = "";
            if (Session["Username"] != null)
            {
                Username = Session["Username"].ToString();
            }
            Show_Friend_Request(Username);
        }
    }
    private void Show_Friend_Request(string Username)
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
        MySqlDataReader reader;
        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();       
            commandDatabase.CommandText = "Select * FROM users where user_name IN (SELECT user_one FROM friends WHERE user_two='" + Username + "' AND Status=0)";
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dlFriends.DataSource = reader;
                    dlFriends.DataBind();
                    databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
    }
    protected void Accept_Click(object sender, EventArgs e)
    {
        DataListItem item = dlFriends.Items[0] as DataListItem;
        System.Web.UI.WebControls.Button acceptbtn = item.FindControl("Accept_Button") as System.Web.UI.WebControls.Button;
        //acceptbtn.Text = "Friends:)";
        //acceptbtn.CssClass = "centerbutton";
        acceptbtn.Visible = false;
        DataListItem item2 = dlFriends.Items[0] as DataListItem;
        System.Web.UI.WebControls.Label lbl = item.FindControl("Label1") as System.Web.UI.WebControls.Label;
        lbl.Visible = true;
        lbl.Text = "FRIENDS :)";
        lbl.ForeColor = System.Drawing.Color.Green;
        DataListItem item1 = dlFriends.Items[0] as DataListItem;
        System.Web.UI.WebControls.Button rejectbtn = item.FindControl("Reject_Button") as System.Web.UI.WebControls.Button;
        rejectbtn.Visible = false;
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
        MySqlDataReader reader;
        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        string SenderFriendId = (((System.Web.UI.WebControls.Button)sender).CommandArgument).ToString();
        string MyID = Session["Username"].ToString();
        MySqlCommand commandDatabase = databaseConnection.CreateCommand();       
        commandDatabase.CommandText = "Update friends set status=1 where user_one='" + SenderFriendId + "' AND user_two='" + MyID + "'";
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
    protected void Reject_Click(object sender, EventArgs e)
    {
        DataListItem item = dlFriends.Items[0] as DataListItem;
        System.Web.UI.WebControls.Button acceptbtn = item.FindControl("Accept_Button") as System.Web.UI.WebControls.Button;
        //acceptbtn.Text = "Friends:)";
        //acceptbtn.CssClass = "centerbutton";
        acceptbtn.Visible = false;
        DataListItem item2 = dlFriends.Items[0] as DataListItem;
        System.Web.UI.WebControls.Label lbl = item.FindControl("Label1") as System.Web.UI.WebControls.Label;
        lbl.Visible = true;
        lbl.Text = "REJECTED :/";
        lbl.ForeColor = System.Drawing.Color.Red;
        DataListItem item1 = dlFriends.Items[0] as DataListItem;
        System.Web.UI.WebControls.Button rejectbtn = item.FindControl("Reject_Button") as System.Web.UI.WebControls.Button;
        rejectbtn.Visible = false;
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
        MySqlDataReader reader;
        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        string SenderFriendId = (((System.Web.UI.WebControls.Button)sender).CommandArgument).ToString();
        string MyID = Session["Username"].ToString();
        MySqlCommand commandDatabase = databaseConnection.CreateCommand();
        commandDatabase.CommandText = "Update friends set status=2 where user_one='" + SenderFriendId + "' AND user_two='" + MyID + "'";
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