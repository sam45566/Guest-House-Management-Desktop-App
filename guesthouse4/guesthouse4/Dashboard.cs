using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guesthouse4
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountBooked();
            CountCustomers();
            CountBookings();
            GetCustomer();


        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abyla\OneDrive\Documents\guesthouse.mdf;Integrated Security=True;Connect Timeout=30");
        int free, booked;
        int bper, freeper;
        private void CountBooked()
        {
            string Status = "Booked";
           

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from RoomTbl where Rstatus='" + Status + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            free = 16 - Convert.ToInt32(dt.Rows[0][0].ToString());
            booked = Convert.ToInt32(dt.Rows[0][0].ToString());
            bper = (booked / 16) * 100;
            freeper = (free / 16) * 100;
            bkd.Text = dt.Rows[0][0].ToString() + " Booked Rooms ";
            avb.Text = free + " Free Rooms";
            avbbl.Text = free + "";
            bkdprogress.Value = bper;
            avbprogress.Value = freeper;
            FreeRoomspregress.Value = freeper;
            con.Close();
        }
        private void CountCustomers()
        {
            


            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from CustomerTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            custnnum.Text = dt.Rows[0][0].ToString() + " Customer ";
           
            con.Close();
        }

        private void bkdnum_Click(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
          private void GetCustomer()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select CusId from CustomerTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusId", typeof(int));
            dt.Load(rdr);
            CusIdCb.ValueMember = "CusId";
            CusIdCb.DataSource = dt;

            con.Close();
        }

        
        private void book_Click(object sender, EventArgs e)
        {
            if (CusNameTb.Text == "" || RoomNumber == 0)
            {
                MessageBox.Show("Select A Room and a Customer");
            }
            else
            {
                try
                {
                    GetRoomType();
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into BookingTbl(Cusid,CusName,Rid,RNum,Rtype,BCost)values(@CI,@CN,@RI,@RN,@RT,@RC)", con);
                    cmd.Parameters.AddWithValue("@CI", CusIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CN", CusNameTb.Text);
                    cmd.Parameters.AddWithValue("@RI", RoomNumber.ToString());
                    cmd.Parameters.AddWithValue("@RN", RoomNumber.ToString());
                    cmd.Parameters.AddWithValue("@RT", RType);
                    cmd.Parameters.AddWithValue("@RC", RC);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Booked");
                    Reset();
                    con.Close();
                    UpdateRoom();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void CountBookings()
        {



            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from BookingTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            booking.Text = dt.Rows[0][0].ToString() + " Bookings ";

            con.Close();
        }
        

        int RoomNumber = 0;
        private void GetcusName()
        {
            con.Open();
            string Query = "Select * from CustomerTbl where CusId=" + CusIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CusNameTb.Text = dr["CusName"].ToString();

            }
            con.Close();
        }

        string RType;
        int RC;
        private void GetRoomType()
        {
            con.Open();
            string Query = "Select * from RoomTbl where RId=" + RoomNumber + "";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                RType = dr["RType"].ToString();
                RC = Convert.ToInt32(dr["RCost"].ToString());

            }
            con.Close();
        }

        private void Reset()
        {
            CusIdCb.SelectedIndex = -1;
            CusNameTb.Text = "";
            RoomNumber = 0;
            RType = "";
            RC = 0;
        }

        private void UpdateRoom()
        {
            string Status = "Booked";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update RoomTbl set RStatus=@RS where RId =@RKey ",     con);
                cmd.Parameters.AddWithValue("@RS", Status);
                cmd.Parameters.AddWithValue("@RKey", RoomNumber);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Updated");
                con.Close();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void R1_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 1;
        }

        private void R2_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 2;
        }

        private void R3_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 3;
        }

        private void R4_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 4;
        }

        private void R5_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 5;
        }

        private void R6_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 6;
        }

        private void R7_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 7;
        }

        private void R8_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 8;
        }
        private void R9_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 9;
        }

        private void R10_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 10;
        }

        private void R11_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 11;
        }

        private void R12_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 12;
        }

        private void R13_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 13;
        }
        private void R14_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 14;
        }
        private void R15_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 15;
        }



        private void btnBooking_Click(object sender, EventArgs e)
        {
            Bookings bookingsForm = new Bookings();
            Program.SwitchForm(bookingsForm);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customers customersForm = new Customers();
            Program.SwitchForm(customersForm);
        }

       
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.CurrentForm.Close();
            Program.LoginForm.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        private void CusIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            users usersForm = new users();
            Program.SwitchForm(usersForm);
        }

        private void CusIdCb_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            GetcusName();
            
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }







    }
}
