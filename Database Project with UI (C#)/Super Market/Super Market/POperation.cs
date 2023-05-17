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
    public partial class POperation : Form
    {
        public POperation()
        {
            InitializeComponent();
        }

        private void POperation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'marketDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.marketDataSet.Supplier);
            // TODO: This line of code loads data into the 'marketDataSet.Product' table. You can move, or remove it, as needed.
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.CommandText = "Delete from Product where P_ID="+textBox3.Text+"";
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            new Wellcomepage().Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.CommandText = "Update Product Set P_name ='" + textBox1.Text.ToString() + "',P_scale ='"
                +textBox4.Text.ToString()+"',quantity_in_store = "+textBox5.Text+",buy_price ="+textBox6.Text+" where P_ID = "+textBox2.Text+"";
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            new Wellcomepage().Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // this.productTableAdapter.Fill(this.marketDataSet.Product);

            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = ("select * from Product ");
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "select * from Product where P_name like '%"+textBox7.Text+"%' ";
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = ("select * from Product where quantity_in_store = 0 ");
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Wellcomepage().Show();
            this.Hide();
        }
    }
}
