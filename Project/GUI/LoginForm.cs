using ABC_Travel_and_Tours;
using Project.BL;

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
    public partial class LoginForm : Form
    {
        UserDTO user;
        LoginBL l;


        public LoginForm()
        {
            InitializeComponent();
            l = new LoginBL();
            user = new UserDTO();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (l.EmployeeLogin(textBox1.Text, textBox2.Text) == true) {
                this.Hide();
                Main_Menu newMainMenu = new Main_Menu();
                newMainMenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Credentials","Login Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            

          /*  if (textBox1.Text != "" && textBox2.Text != "")
            {
                user.Email = textBox1.Text;
                user.Password = textBox2.Text;
                if (l.Login(user))
                {
                    this.Hide();
                    Main_Menu newMenu = new Main_Menu();
                    newMenu.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Fill All The Fields", "Error");
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
