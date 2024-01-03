//newUser.cs

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
    public partial class newUser : Form
    {


        public newUser()
        {
            InitializeComponent();
        }

        // Event handler for the Register button click
        private void registerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (password.Text == confirmPassword.Text)
                {
                    SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Kebiba\Desktop\C#\csharp-inventory-system-main\InventorySystem\database\InventoryDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;User Instance=True");
                    sqlcon.Open();
                    SqlCommand cmd = sqlcon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO userLogin VALUES('" + employeeNumber.Text + "', '" + password.Text + "')";
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();

                    MessageBox.Show("New user succesfully registered.");

                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Password do not match.");
                }
            }catch(System.Data.SqlClient.SqlException)
            {
                // Handling SQL exceptions related to employee number
                MessageBox.Show("Please check your employee number.");
            }
            
        }
    }
}
