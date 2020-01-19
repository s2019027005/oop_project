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
    public partial class Office : Form
    {

        public Office()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.Hide();
                Kitchen newKitchen = new Kitchen();
                newKitchen.ShowDialog();
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipment newEquipment = new Equipment();
            newEquipment.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu newMenu = new Main_Menu();
            newMenu.ShowDialog();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            OfficeDetails newOfficeD = new OfficeDetails();
            newOfficeD.ShowDialog();
            this.Close();
        }
    }
}
