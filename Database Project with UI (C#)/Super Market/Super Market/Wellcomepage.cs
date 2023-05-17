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
    public partial class Wellcomepage : Form
    {
        public Wellcomepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    + textBox2.Text.ToString() + "'";
                myreader = cmd.ExecuteReader();
                int count = 0;
                while (myreader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    new Product().Show();
                    this.Hide();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate user name and password");
                    this.Hide();
                    new Wellcomepage().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong user name and password!!!");
                    this.Hide();
                    new Wellcomepage().Show();
                    this.Hide();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
                    + textBox2.Text.ToString() + "'";
                myreader = cmd.ExecuteReader();
                int count = 0;
                while (myreader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    new POperation().Show();
                    this.Hide();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate user name and password");
                    this.Hide();
                    new Wellcomepage().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong user name and password!!!");
                    this.Hide();
                    new Wellcomepage().Show();
                    this.Hide();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = ("select * from Product where P_ID in (select top 1 P_ID from [order] ,OrderDetails where [order].O_id = OrderDetails.O_id group by P_ID order by count(*)desc) ");
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "select * from Product where P_ID not in(select P_ID from [Order],OrderDetails where O_date like '%_" + textBox3.Text + "-%') ";
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
            sqlCommand.CommandText = "select * from Customer where Cust_ID not in ( select Customer.Cust_ID from [Order],Customer where Customer.Cust_ID = [Order].Cust_ID And O_date like '2022-%')";
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "select * from Customer,[Order] where Customer.Cust_ID = [Order].Cust_ID And [Order].O_id in (select top 1 OrderDetails.O_id from  OrderDetails, [Order]  where [Order].O_id = OrderDetails.O_id group by OrderDetails.O_id order by Sum(Price)desc) ";
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "select top 1 Category.C_ID,Category.C_name,Category.D_ID ,sum(quantity) as NumOfSold  from(select Product.*, quantity from OrderDetails, Product where OrderDetails.P_ID = Product.P_ID) as f,Category where f.C_ID = Category.C_ID group by Category.C_ID,Category.C_name,Category.D_ID order by NumOfSold desc";
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "select Product.P_ID,C_ID,S_ID,P_name,P_scale,quantity_in_store,buy_price,NumOFCustomer from Product left join (select P_ID  , Count(*) as NumOFCustomer from[order] ,OrderDetails where[order].O_id = OrderDetails.O_id group by P_ID )as b on Product.P_ID = b.P_ID";
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Wellcomepage_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Edit_Customer().Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "select Customer.*,c as numberOfOreders from Customer,(select Customer.Cust_ID, COUNT(*) as c from Customer ,[Order] where Customer.Cust_ID = [Order].Cust_ID group by Customer.Cust_ID)as t where Customer.Cust_ID = t.Cust_ID And c>=2";
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-TT06APK;Initial Catalog=Market;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "select * from Product where P_name like '%"+textBox7.Text+"%'"; 
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
