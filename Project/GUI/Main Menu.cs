
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.GUI
{
    public partial class Main_Menu : Form
    {

        public Main_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Hide();
                Customer newCust = new Customer();
                newCust.ShowDialog();
                this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.Hide();
                Employee newEmp = new Employee();
                newEmp.ShowDialog();
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            VendersMenu newVend = new VendersMenu();
            newVend.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Office newOffice = new Office();
            newOffice.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Booking newBookingD = new Booking();
            newBookingD.ShowDialog();
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm newLogin = new LoginForm();
            newLogin.ShowDialog();
            this.Close();
        }
    }
}
