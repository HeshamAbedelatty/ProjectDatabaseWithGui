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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.CommandText = "Insert Into Product values ("
                + textBox1.Text
                + ","
                + textBox6.Text
                + ","
                + textBox7.Text
                + ",'"
                + textBox2.Text.ToString()
                + "','"
                + textBox3.Text.ToString()
                + "',"
                + textBox4.Text
                + ","
                + textBox5.Text
                + ")";
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            new Wellcomepage().Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Product_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new POperation().Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new Wellcomepage().Show();
            this.Hide();
        }
    }
}
