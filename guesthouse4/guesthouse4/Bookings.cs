using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace guesthouse4
{
    public partial class Bookings : Form
    {
        public Bookings()
        {
            InitializeComponent();
            ShowBookings(); 
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abyla\OneDrive\Documents\guesthouse.mdf;Integrated Security=True;Connect Timeout=30");
        private void ShowBookings()
        {
            Con.Open();
            string Query = "Select * from BookingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingDGV.DataSource = ds;
            Con.Close();
        }
        private void FilterBooking()
        {
            Con.Open();
            string Query = "Select * from BookingTbl where RType='" + RtypeCb.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingDGV.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customers customersForm = new Customers();
            Program.SwitchForm(customersForm);
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            Program.ReturnToDashboard();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.CurrentForm.Close();
            Program.LoginForm.Show();
        }

        private void Bookings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            ShowBookings();
        }

        private void RtypeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterBooking();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            users usersForm = new users();
            Program.SwitchForm(usersForm);
        }
    }
}