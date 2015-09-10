using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project2015
{
    public partial class Register : Form
    {
        

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox1.Clear();
            if (!textBox1.Focused)
            {
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBConnection.getConn("HP-PC\\SQLEXPRESS", "project2015");

            string email = textBox1.Text;
            string passwd = textBox2.Text;
            string saltedHashedPass = Functions.CreateHash(passwd);

            String query = "INSERT INTO users(email, passwd) VALUES(@email,@passwd)";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@passwd", saltedHashedPass);
            command.ExecuteNonQuery();
            MessageBox.Show("Length1:" + email.Length + "\nLength2: " + saltedHashedPass.Length);
            MessageBox.Show("New User Created!\n User with email " + email + " created");
        }
    }
}
