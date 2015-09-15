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

namespace Project2015
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlConnection conn = DBConnection.getConn("MAYUR\\SQLEXPRESS", "project2015");
            SqlCommand cmd = new SqlCommand("Select * from users where Username=" + textBox1.Text + "Password =" + textBox2.Text, conn);
            SqlDataReader dbr;
            dbr = cmd.ExecuteReader();
            int count = 0;
            while (dbr.Read())
            {
                count = count + 1;
            }
            if(count == 1)
            {
                this.Hide();
                main ss = new main();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Passowrd.");

            }
           
             
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                MessageBox.Show("Please Enter your username");
                return;
            }
    
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                MessageBox.Show("Please Enter your Password");
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}