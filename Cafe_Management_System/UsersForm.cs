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
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Study\Project\.NET Project\Cafe_Management_System\Cafe_Management_System\Cafedb.mdf';Integrated Security=True");
        void populate()
        {
            Con.Open();
            string query = "select * from UsersTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            UserOrder uorder = new UserOrder();
            uorder.Show();
            this.Hide();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            ItemsForm item = new ItemsForm();
            item.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = " Insert into UsersTbl values('" + UnameTb.Text + "', '" + UphoneTb.Text + "','" + UpassTb.Text + "')";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Successfully Created");
           Con.Close();
            populate();


        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void UserGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UserGV.SelectedRows[0].Cells[0].Value.ToString();
            UphoneTb.Text = UserGV.SelectedRows[0].Cells[1].Value.ToString();
            UpassTb.Text = UserGV.SelectedRows[0].Cells[2].Value.ToString();
            //UnameTb.Text = UserGV.SelectedRows[0].Cells[0].Value.ToString();
           // UphoneTb.Text = UserGV.SelectedRows[0].Cells[1].Value.ToString();
            //UpassTb.Text = UserGV.SelectedRows[0].Cells[2].Value.ToString();

            


        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if(UphoneTb.Text == "")
            {
                MessageBox.Show("Select The User to be Deleted");
            }
            else
            {
                Con.Open();
                string query = "delete from UsersTbl where Uphone = '"+ UphoneTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Seccessfully Deleted");
                Con.Close();
                populate(); 

            } 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(UphoneTb.Text == "" || UpassTb.Text == "" || UnameTb.Text == "")
            {
                MessageBox.Show("Fill All the Field");
            }
            else
            {
                Con.Open();
                string query = "update  UsersTbl set Uname='" + UnameTb.Text + "',Upassword='" + UpassTb.Text + "' where Uphone='" + UphoneTb + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfuuly upadted");
                Con.Close();
                populate();
            }
        }
    }

    
}

