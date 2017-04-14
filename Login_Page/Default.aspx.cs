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
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Login_Page
{
    public partial class Default : System.Web.UI.Page
    {
        public static int otpno = 0;
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=nitwale;";
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer sSyn = new SpeechSynthesizer();
        PromptBuilder pt = new PromptBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //MethodInvoker simpleDelegate = new MethodInvoker(initialWelcome);
                //simpleDelegate.BeginInvoke(null, null);
            }
            if (IsPostBack || !IsPostBack)
            {
                //MethodInvoker simpleDelegate = new MethodInvoker(si);
                //simpleDelegate.BeginInvoke(null, null);
            }

        }

        /*private void initialWelcome()
        {
            sSyn.Speak("Hi Welcome To NIT");
        }
        private void si()
        {
          //  Choices list = new Choices(System.IO.File.ReadAllLines(@"C:\Ujwal Project\Usernames.txt"));
            Choices colorChoice = new Choices(new string[] { "Login", "Sign Up", "Forget Password", "Close","Send The Email" });
            GrammarBuilder builder = new GrammarBuilder();
            builder.Append(colorChoice);
            //builder.Append(list);
            Grammar colorGrammar = new Grammar(builder);
            recEngine.LoadGrammarAsync(colorGrammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
        }
        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            if (e.Result.Text == "Sign Up")
            {
                pt.AppendText("Taking You To Sign Up Page");
                sSyn.Speak(pt);
                pt.ClearContent();
                MethodInvoker simpleDelegate = new MethodInvoker(signup);
                simpleDelegate.Invoke();
                

            }
            else if (e.Result.Text == "Login")
            {
                pt.AppendText("Opening the torrentz");
                sSyn.Speak(pt);
                System.Diagnostics.Process.Start("www.torrentz2.eu");
                pt.ClearContent();
            }
            else if (e.Result.Text == "Forget Password")
            {
                pt.AppendText("Opening the facebook");
                sSyn.Speak(pt);
                System.Diagnostics.Process.Start("www.facebook.com");
                pt.ClearContent();
                MethodInvoker simpleDelegate = new MethodInvoker(fp);
                simpleDelegate.Invoke();
            }
            else if (e.Result.Text == "Close")
            {
                pt.AppendText("Opening the gmail");
                sSyn.Speak(pt);
                System.Diagnostics.Process.Start("www.gmail.com");
                pt.ClearContent();
            }
            else if (e.Result.Text == "Send The Email")
            {
                MethodInvoker simpleDelegate1 = new MethodInvoker(pleasewait);
                simpleDelegate1.Invoke();
                MethodInvoker simpleDelegate = new MethodInvoker(se);
                simpleDelegate.Invoke();
            }
        }*/
        private void fp()
        {
            sSyn.Speak("Hey");
            id01.Style.Add("display", "block");
            sSyn.Speak("Bye");
        }
        protected void Sign_Up(object sender, EventArgs e)
        {
            Response.Redirect("~/SignUp.aspx", false);
        }
        private void signup()
        {
            Sign_Up(new object(), new EventArgs());
        }
        protected void Change_New_Password(object sender, EventArgs e)
        {
            // Sign_Up_Button.Text = "Done";
        }
        protected void Forget_Password_Block(object sender, EventArgs e)
        {
            id01.Style.Add("display", "block");
        }
        protected void Send_Email(object sender, EventArgs e)
        {
            string Username = Request.Form["user_name1"];
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "SELECT email FROM users where user_name=@id1 ";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            MySqlDataReader reader;
            string Email = "";
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Email = reader["email"].ToString();
                        //MessageBox.Show(Email);
                    }
                    databaseConnection.Close();
                }
                else
                {
                    MessageBox.Show(" Either Username or Password is Incorrect");
                    databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (Email != "")
                send_email(Email);
        }

        private void se()
        {
            MethodInvoker simpleDelegate = new MethodInvoker(fp);
            simpleDelegate.Invoke();
            string Username = HttpContext.Current.Request.Form["user_name1"];
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "SELECT email FROM users where user_name=@id1 ";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            MySqlDataReader reader;
            string Email = "";
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Email = reader["email"].ToString();
                        //MessageBox.Show(Email);
                    }
                    databaseConnection.Close();
                }
                else
                {
                    MessageBox.Show(" Either Username or Password is Incorrect");
                    databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (Email != "")
                send_email(Email);
        }
        protected string generate_otp()
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            otpno = ran.Next(1000, 9999);
            return otpno.ToString();
        }
        protected void send_email(string Email)
        {
            Send_Email_Button.Text = "Sending OTP,Please Wait!!";
            try
            {
                MailAddress From = new MailAddress("ujwalgph@gmail.com");
                MailAddress To = new MailAddress("ujwalgph@gmail.com");
                MailMessage mm = new MailMessage(From, To);
                mm.Subject = "OTP Password for NitWale";
                mm.Body = generate_otp();
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("ujwalgph@gmail.com", "09813135666");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 25;
                smtp.Send(mm);
                
                MessageBox.Show("Email Sent");
                Send_Email_Button.Text = "Send on Registered Email";
                System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(20).TotalMilliseconds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pleasewait()
        {
            sSyn.Speak("Please Wait While OTP is being send");
        }
        protected void Change__Password(object sender, EventArgs e)
        {
            string Entered_otp = Request.Form["otp"];

            if (Entered_otp != otpno.ToString())
            {
                MessageBox.Show("Enter Correct OTP");
                System.Threading.Thread.Sleep(
                (int)System.TimeSpan.FromSeconds(60).TotalMilliseconds);
            }
            else
            {
                Session["username"] = Request.Form["user_name"];
                Response.Redirect("~/Self_Home.aspx", false);
            }
        }
        protected void LogInToMainPage(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            string Username = Request.Form["user_name"];
            string Password = Request.Form["password"];
           

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = databaseConnection.CreateCommand();
            commandDatabase.CommandText = "SELECT * FROM users where user_name=@id1 AND password=@id2 ";
            commandDatabase.Parameters.AddWithValue("@id1", Username);
            commandDatabase.Parameters.AddWithValue("@id2", Password);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    databaseConnection.Close();
                    Session["username"] = Username;
                    //  MessageBox.Show(Session["username"].ToString());
                    Response.Redirect("~/Self_Home.aspx", false);
                    // Session.RemoveAll();


                }
                else
                {
                    MessageBox.Show(" Either Username or Password is Incorrect");
                    databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}