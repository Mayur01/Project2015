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
            string email = textBox1.Text;
            string passwd = textBox2.Text;
            string saltedHashedPass;
            //String queryUser = "SELECT * FROM users WHERE email='" + username + "'";
            //SqlCommand command = new SqlCommand(queryUser, conn);
            SqlConnection conn = DBConnection.getConn("MAYUR\\SQLEXPRESS", "project2015");
             SqlCommand cmd = new SqlCommand("Select * from users where email=" + textBox1.Text + "passwd =" + textBox2.Text, conn);
            SqlDataReader userData = cmd.ExecuteReader();
            if (userData.HasRows)
            {
                while (userData.Read())

                {
                    saltedHashedPass = userData["passwd"].ToString();
                    MessageBox.Show(saltedHashedPass);

                    if (Functions.ValidatePassword(passwd, saltedHashedPass));
                    {
                        this.Hide();
                        main ss = new main();
                        ss.Show();
                    }
                }
            }

           else  
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