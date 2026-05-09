using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace guesthouse4
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            ShowCustomers();    

            // Wire up click events for navigation buttons
            btnDashBoard.Click += btnDashBoard_Click;
            btnBookings.Click += btnBookings_Click;
            btnLogout.Click += btnLogout_Click;
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abyla\OneDrive\Documents\guesthouse.mdf;Integrated Security=True;Connect Timeout=30");
        int key;
        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            // Find existing Dashboard form or create new one
            foreach (Form form in Application.OpenForms)
            {
                if (form is Dashboard)
                {
                    form.Show();
                    this.Hide();
                    return;
                }
            }

            // If no Dashboard exists, create new one
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            // Find existing Bookings form or create new one
            foreach (Form form in Application.OpenForms)
            {
                if (form is Bookings)
                {
                    form.Show();
                    this.Hide();
                    return;
                }
            }

            // If no Bookings exists, create new one
            Bookings bookings = new Bookings();
            bookings.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Find existing Login form or create new one
            foreach (Form form in Application.OpenForms)
            {
                if (form is Login)
                {
                    form.Show();
                    this.Close();
                    return;
                }
            }

            // If no Login exists, create new one
            Login login = new Login();
            login.Show();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        private void ShowCustomers()
        {
            con.Open();
            string query = "SELECT * FROM CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            CustomersDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void Reset()
        {
            CusName.Text = "";
            CusPhone.Text = "";
            CusGenCb.SelectedIndex = -1;
            Datepicker.Value = DateTime.Now;
            key = 0;
        }



        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (CusName.Text == "" || CusPhone.Text == "" || CusGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO CustomerTbl(CusName, CusPhone, CusGen, CusDOB) VALUES (@CN, @CP, @CG, @CD)", con);
                    cmd.Parameters.AddWithValue("@CN", CusName.Text);
                    cmd.Parameters.AddWithValue("@CP", CusPhone.Text);
                    cmd.Parameters.AddWithValue("@CG", CusGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CD", Datepicker.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Saved");
                    con.Close();
                    ShowCustomers();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void CustomersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CusName.Text = CustomersDGV.SelectedRows[0].Cells[1].Value.ToString();
            CusPhone.Text = CustomersDGV.SelectedRows[0].Cells[2].Value.ToString();
            CusGenCb.SelectedItem = CustomersDGV.SelectedRows[0].Cells[3].Value.ToString();
            Datepicker.Value = Convert.ToDateTime(CustomersDGV.SelectedRows[0].Cells[4].Value.ToString());
            if (CusName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CustomersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Customer");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CustomerTbl where CusId=@CKey", con);
                    cmd.Parameters.AddWithValue("@CKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted");
                    con.Close();
                    ShowCustomers();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CusName.Text == "" || CusPhone.Text == "" || CusGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE CustomerTbl SET CusName=@CN, CusPhone=@CP, CusGen=@CG, CusDOB=@CD WHERE CusId=@CKey", con);
                    cmd.Parameters.AddWithValue("@CN", CusName.Text);
                    cmd.Parameters.AddWithValue("@CP", CusPhone.Text);
                    cmd.Parameters.AddWithValue("@CG", CusGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CD", Datepicker.Value.Date);
                    cmd.Parameters.AddWithValue("@CKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Updated");
                    con.Close();
                    ShowCustomers();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            users usersForm = new users();
            Program.SwitchForm(usersForm);
        }
    }
}