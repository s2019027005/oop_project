using ABC_Travel_and_Tours;
using Project.BL;
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

namespace Project.GUI
{
    public partial class OfficeDetails : Form
    {
        OfficeDTO DTO;
        SqlConnection sqlCon;
        SqlCommand cmd;
        string checkId;
        public OfficeDetails()
        {
            InitializeComponent();
            DTO = new OfficeDTO();
            sqlCon = new SqlConnection("Data Source=DESKTOP-63Q74F5;Initial Catalog=Project;Integrated Security=True");
            cmd = new SqlCommand();
        }

        private void refreshList()
        {
            officeList.Items.Clear();
            sqlCon.Open();
            cmd.CommandText = "Select * From OfficeDetails";
            cmd.Connection = sqlCon;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem myList = new ListViewItem(dr["id"].ToString());
                myList.SubItems.Add(dr["address"].ToString());
                myList.SubItems.Add(dr["rent"].ToString());
                myList.SubItems.Add(dr["expense"].ToString());
                officeList.Items.Add(myList);
            }
            sqlCon.Close();

            textBox3.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
        }

        private void OfficeDetails_Load(object sender, EventArgs e)
        {
            enableDisableButton();
            refreshList();
            sqlCon.Open();
            cmd.CommandText = "Select COUNT(firstName) As EmpCount From Employees";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label5.Text = dr["EmpCount"].ToString();
            }
            sqlCon.Close();
            
        }

        private void enableDisableButton()
        {
            button2.Enabled = true;
            button3.Enabled = false;
            button1.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //name
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //rent
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //assigned
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update
            enableDisableButton();
            officeDetailsUpdate();
        }

        private void officeDetailsUpdate()
        {
            if (isIntergerOrDoubleBL.isInteger(textBox4.Text))
            {
                sqlCon.Open();
                cmd.Connection = sqlCon;
                cmd.CommandText = "Update OfficeDetails SET address = '" + textBox3.Text + "', rent = '" + Convert.ToInt32(textBox4.Text) + "',expense = '" + textBox2.Text + "' Where id = '" + checkId + "'";
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                refreshList();
            }
            else
            {
                DialogResult result = MessageBox.Show("Please Enter Rent Value Not A String", "Error", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button3.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //add
            if (textBox4.Text != "" && textBox3.Text != ""&&textBox2.Text!="")
            {



                if (isIntergerOrDoubleBL.isDouble(textBox4.Text)&& isIntergerOrDoubleBL.isDouble(textBox2.Text))
                {
                    DTO.OffAddress = textBox3.Text;
                    DTO.OffRent = Convert.ToInt32(textBox4.Text);
                    DTO.OffExpense = Convert.ToInt32(textBox2.Text);

                    sqlCon.Open();
                    cmd.CommandText = "INSERT INTO OfficeDetails(address,rent,expense) VALUES ('" + DTO.OffAddress + "','" + DTO.OffRent + "','" + DTO.OffExpense + "')";
                    cmd.Connection = sqlCon;
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    refreshList();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Please Enter Rent Value Not A String", "Error", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        enableDisableButton();
                    }
                }


            }
            else
            {
                MessageBox.Show("Please Fill All The Fields", "Opps");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //del
            enableDisableButton();
            officeDetailsDelete();
        }

        private void officeDetailsDelete()
        {
            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Delete From OfficeDetails Where id = '" + checkId + "'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            checkId = officeList.SelectedItems[0].SubItems[0].Text;
            sqlCon.Open();
            cmd.CommandText = "Select * From OfficeDetails Where id = " + checkId + "";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox3.Text = dr["address"].ToString();
                textBox4.Text = dr["rent"].ToString();
                textBox2.Text = dr["expense"].ToString();
            }
            sqlCon.Close();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                officeList.Items.Clear();
                sqlCon.Open();
                if (!isIntergerOrDoubleBL.isInteger(textBox1.Text))
                {
                    cmd.CommandText = "SELECT * FROM OfficeDetails WHERE address LIKE '%" + textBox1.Text + "%'";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM OfficeDetails WHERE id LIKE '%" + textBox1.Text + "%'";
                }
                cmd.Connection = sqlCon;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem myList = new ListViewItem(dr["id"].ToString());
                    myList.SubItems.Add(dr["address"].ToString());
                    myList.SubItems.Add(dr["rent"].ToString());
                    myList.SubItems.Add(dr["expense"].ToString());
                    officeList.Items.Add(myList);
                }
                sqlCon.Close();
            }
            else
            {
                refreshList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Office newOffice = new Office();
            newOffice.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
