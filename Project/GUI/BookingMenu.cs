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
    public partial class BookingMenu : Form
    {

        public BookingMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Hide();
                Bus newBusMenu = new Bus();
                newBusMenu.ShowDialog();
                this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.Hide();
                Airline newAirline = new Airline();
                newAirline.ShowDialog();
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Car newCar = new Car();
            newCar.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hotel newHotel = new Hotel();
            newHotel.ShowDialog();
            newHotel.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu newMenu = new Main_Menu();
            newMenu.ShowDialog();
            this.Close();
        }
    }
}
