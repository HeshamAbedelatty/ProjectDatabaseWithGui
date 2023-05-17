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

namespace Super_Market
{
    public partial class LogIN : Form
    {
        public LogIN()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                SqlDataReader myreader;
                sqlConnection.Open();
                cmd.CommandText = "select userName,password from Admin where userName = '"
                    + textBox1.Text.ToString() + "' And password='"
                    + textBox2.Text.ToString() + "' Union select cust_userName,cust_pasword  from Customer where cust_userName='"
                    + textBox1.Text.ToString() + "'And cust_pasword= '" + textBox2.Text.ToString() + "'";
                myreader = cmd.ExecuteReader();
                int count = 0;
                while (myreader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {

                    new Wellcomepage().Show();
                    this.Hide();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate user name and password");
                    this.Hide();
                    new LogIN().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong user name and password!!!");
                    this.Hide();
                    new LogIN().Show();
                    this.Hide();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
