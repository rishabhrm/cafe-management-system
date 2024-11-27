using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cafe_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Study\Project\.NET Project\Cafe_Management_System\Cafe_Management_System\Cafedb.mdf';Integrated Security=True");

        private void Label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestOrder guest = new GuestOrder();
            guest.Show();
        }
        public static string user;
        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            user = UnameTb.Text;
            if(UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter a Username or Password");

            }
            else
            { 
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UsersTbl where Uname='" + UnameTb.Text + "'and Upassword='" + PasswordTb.Text+ "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1"){
                    UserOrder uorder = new UserOrder();
                    uorder.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }
                Con.Close();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click_1(object sender, EventArgs e)
        {

        }

        private void UnameTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
