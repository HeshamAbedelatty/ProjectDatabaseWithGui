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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.CommandText = "Insert Into Customer values ("
                + textBox1.Text
                + ", null ,'"
                + textBox2.Text.ToString()
                + "','"
                + textBox3.Text.ToString()
                + "','"
                + textBox5.Text.ToString()
                + "','"
                + textBox7.Text.ToString()
                + "','"
                + textBox6.Text.ToString()
                + "','"
                + textBox4.Text.ToString()
                + "','"
                + textBox8.Text.ToString()
                + "','"
                + textBox9.Text.ToString()
                + "')";
            cmd.ExecuteNonQuery();
            new Wellcomepage().Show();
            this.Hide();

            sqlConnection.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new LogIN().Show();
            this.Hide();
        }
    }
}
