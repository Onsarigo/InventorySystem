//mainForm.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        // Log Out Button Click Event
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            logIn OBJlogIn = new logIn();
            OBJlogIn.Show();
        }

        // Add User Button Click Event
        private void addUser_Click(object sender, EventArgs e)
        {
            newUser OBJnewUser = new newUser();
            OBJnewUser.Show();
        }

        // View Stocks Button Click Event
        private void viewStocks_Click(object sender, EventArgs e)
        {
            this.Hide();
            stocks OBJstocks = new stocks();
            OBJstocks.Show();
        }

        // View Orders Button Click Event
        private void viewOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            orders OBJorders = new orders();
            OBJorders.Show();
        }
    }
}
