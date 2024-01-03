//orders.cs

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

namespace InventorySystem
{
    public partial class orders : Form
    {

        // SqlConnection object for database connectivity
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Kebiba\Desktop\C#\csharp-inventory-system-main\InventorySystem\database\InventoryDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;User Instance=True");

        public orders()
        {
            InitializeComponent();
        }
        // Method to display data in the DataGridView
        public void displayData()
        {
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from oders";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            recordList.DataSource = dt;

            sqlcon.Close();
        }
        // Form load event, calls displayData to populate DataGridView on form load
        private void orders_Load(object sender, EventArgs e)
        {
            displayData();
        }

        // Event handler for the Insert button click
        private void insertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO oders VALUES('" + orderNumber.Text + "', '" + customerName.Text + "', '" + dateOfPurchase.Text + "', '" + price.Text + "', '" + orderStatus.Text + "')";
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                MessageBox.Show("Order placed.");

                orderNumber.Text = " ";
                customerName.Text = " ";
                price.Text = " ";
                orderStatus.Text = " ";

                displayData();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("One or more input(s) is/are invalid.");
            }
            catch (System.InvalidOperationException)
            {
                this.Hide();
                orders OBJorders = new orders();
                OBJorders.Show();
            }
        }

        // Event handler for the Update button click
        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE oders set CustomerName = '" + customerName.Text + "', DateofPurchase = '" + dateOfPurchase.Text + "', Price = '" + price.Text + "', Status = '" + orderStatus.Text + "' WHERE OrderNumber = '" + orderNumber.Text + "'";
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                MessageBox.Show("Order updated.");

                orderNumber.Text = " ";
                customerName.Text = " ";
                price.Text = " ";
                orderStatus.Text = " ";

                displayData();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("One or more input(s) is/are invalid.");
            }
            catch (System.InvalidOperationException)
            {
                this.Hide();
                orders OBJorders = new orders();
                OBJorders.Show();
            }
        }

        // Event handler for the Delete button click
        private void delBtn_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM oders WHERE OrderNumber = '" + searchOrder.Text + "'";
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                MessageBox.Show("Order record deleted.");

                orderNumber.Text = " ";
                customerName.Text = " ";
                price.Text = " ";
                orderStatus.Text = " ";

                displayData();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("One or more input(s) is/are invalid.");
            }
            catch (System.InvalidOperationException)
            {
                this.Hide();
                orders OBJorders = new orders();
                OBJorders.Show();
            }
        }

        // Event handler for the Search button click
        private void searchBtn_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from oders where OrderNumber = '" + searchOrder.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            recordList.DataSource = dt;

            sqlcon.Close();
        }

        // Event handler for the Clear button click
        private void clearBtn_Click(object sender, EventArgs e)
        {
            displayData();
            searchOrder.Text = " ";
        }

        // Event handler for the Back button click
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm OBJmainForm = new mainForm();
            OBJmainForm.Show();
        }
    }
}
