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
    public partial class Edit_Customer : Form
    {
        public Edit_Customer()
        {
            InitializeComponent();
        }

        private void Edit_Customer_Load(object sender, EventArgs e)
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
            cmd.CommandText = "update Customer set Cust_fname='"
                
                + textBox2.Text.ToString()
                + "',Cust_lname='"
                + textBox3.Text.ToString()
                + "',cust_city ='"
                + textBox4.Text.ToString()
                + "',cust_street='"
                + textBox5.Text.ToString()
                + "',cust_state='"
                + textBox6.Text.ToString()
                + "',cust_gender='"
                + textBox7.Text.ToString()
                + "',cust_userName='"
                + textBox8.Text.ToString()
                + "',cust_pasword='"
                + textBox9.Text.ToString()
                + "'where Cust_ID = "+textBox1.Text+"";
            cmd.ExecuteNonQuery();
            new Wellcomepage().Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.CommandText = "delete from Customer where Cust_ID = " + textBox1.Text + " ";
            cmd.ExecuteNonQuery();
            new Wellcomepage().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "select * from Customer";
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Wellcomepage().Show();
            this.Hide();
        }
    }
}
