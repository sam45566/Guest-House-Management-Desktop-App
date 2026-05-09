using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace guesthouse4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else
            {
                try
                {
                    using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abyla\OneDrive\Documents\guesthouse.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from UserTbl where Uname='" + user.Text + "' and Upass='" + pass.Text + "'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Program.DashboardForm = new Dashboard();
                            Program.SwitchForm(Program.DashboardForm);
                        }
                        else
                        {
                            MessageBox.Show("Wrong UserName Or Password");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}