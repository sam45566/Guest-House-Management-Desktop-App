using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace guesthouse4
{
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
            Show();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abyla\OneDrive\Documents\guesthouse.mdf;Integrated Security=True;Connect Timeout=30");
        private void Show()
        {
            con.Open();
            string query = "Select * from Usertbl";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            SqlCommandBuilder build = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            usersDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (uname.Text == " " || uphone.Text == " " || Upass.Text == " ")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into usertbl(uname,uphone,upass) values(@uname,@upahone,@upass)", con);
                    cmd.Parameters.AddWithValue("@uname", uname.Text);
                    cmd.Parameters.AddWithValue("@uphone", uphone.Text);
                    cmd.Parameters.AddWithValue("@upass", Upass.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Saved");
                    con.Close();
                    Show();
                    Reset();



                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void usersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            uname.Text = usersDGV.SelectedRows[0].Cells[1].Value.ToString();
            uphone.Text = usersDGV.SelectedRows[0].Cells[2].Value.ToString();
            Upass.Text = usersDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (uname.Text == " ")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(usersDGV.SelectedRows[0].Cells [0].Value.ToString()); 
            }

            }

        private void uedit_Click(object sender, EventArgs e)
        {
            if (uname.Text == " " || uphone.Text == " " || Upass.Text == " ")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update usertbl set uname = @un,uphone = @uphone,upass = @pass whre Uid - @ukey", con);
                    cmd.Parameters.AddWithValue("@uname", uname.Text);
                    cmd.Parameters.AddWithValue("@uphone", uphone.Text);
                    cmd.Parameters.AddWithValue("@upass", Upass.Text);
                    cmd.Parameters.AddWithValue("@ukey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated");
                    con.Close();
                    Show();
                    Reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Reset()
        {
            uname.Text = " ";
            uphone.Text = " ";
            Upass.Text = " ";
            key = 0;

                }
        private void udel_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("select user");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from usertbl where UID = @UKey", con);
                    cmd.Parameters.AddWithValue("@UId", key);
                  

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted");
                    con.Close();
                    Show();
                    Reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void users_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        // Add these methods to your existing users class

        // Add these methods to your existing users class

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            Program.ReturnToDashboard();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Customers customersForm = new Customers();
            Program.SwitchForm(customersForm);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            Bookings bookingsForm = new Bookings();
            Program.SwitchForm(bookingsForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.CurrentForm.Close();
            Program.LoginForm.Show();
        }

        private void users_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            users usersForm = new users();
            Program.SwitchForm(usersForm);
        }

      

   
    }
   }
    
    