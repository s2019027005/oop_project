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
    public partial class Airline : Form
    {
        AirlinesDTO DTO;
        SqlConnection sqlCon;
        SqlCommand cmd;
        string checkId;
        public Airline()
        {
            InitializeComponent();
            DTO = new AirlinesDTO();
            sqlCon = new SqlConnection("Data Source=DESKTOP-63Q74F5;Initial Catalog=Project;Integrated Security=True");
            cmd = new SqlCommand();
        }

        private void refreshList()
        {
            airlineList.Items.Clear();
            sqlCon.Open();
            //SqlCommand cmd1 = new SqlCommand("Select * From Customers", sqlCon);
            cmd.CommandText = "Select * From Airlines";
            cmd.Connection = sqlCon;
            //cmd.Parameters.Add(sqlCon);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem myList = new ListViewItem(dr["id"].ToString());
                myList.SubItems.Add(dr["name"].ToString());
                myList.SubItems.Add(dr["address"].ToString());
                myList.SubItems.Add(dr["serviceProvider"].ToString());
                myList.SubItems.Add(dr["contractStart"].ToString());
                myList.SubItems.Add(dr["contractRenew"].ToString());
                myList.SubItems.Add(dr["discount"].ToString());
                myList.SubItems.Add(dr["destination"].ToString());
                airlineList.Items.Add(myList);
            }
            sqlCon.Close();

            textBox2.Text = "";
            textBox10.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Refresh();
            dateTimePicker2.Refresh();

        }

        private void Airline_Load(object sender, EventArgs e)
        {
            refreshList();
            enableDisableButton();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //name
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //address
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //service
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //start
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //renew
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //discount
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //destination
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add
            if (textBox2.Text != "" && textBox10.Text != "" && textBox4.Text != "" && textBox7.Text != "" && textBox3.Text != "")
            {

                

                if (isIntergerOrDoubleBL.isDouble(textBox7.Text))
                {
                    DTO.CName = textBox2.Text;
                    DTO.CAddress = textBox10.Text;
                    DTO.CService = textBox4.Text;
                    DTO.CContractStart = dateTimePicker1.Value;
                    DTO.CRecontractRenew = dateTimePicker2.Value;
                    DTO.CDiscount = Convert.ToDouble(textBox7.Text);
                    DTO.AirDestin = textBox3.Text;

                    sqlCon.Open();
                    cmd.CommandText = "INSERT INTO Airlines(name,address,serviceProvider,contractStart,contractRenew,discount,destination) VALUES ('" + DTO.CName + "','" + DTO.CAddress + "','" + DTO.CService + "','" + DTO.CContractStart + "','" + DTO.CRecontractRenew + "','" + DTO.CDiscount + "','" + DTO.AirDestin + "')";
                    cmd.Connection = sqlCon;
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    refreshList();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Please Enter Discount Value Not A String", "Error", MessageBoxButtons.OK);
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

        private void airlineUpdate()
        {
            if (isIntergerOrDoubleBL.isDouble(textBox7.Text))
            {
            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Update Airlines SET name = '" + textBox2.Text + "', address = '" + textBox10.Text + "', serviceProvider = '" + textBox4.Text + "', contractStart = '" + dateTimePicker1.Value + "', contractRenew = '" + dateTimePicker2.Value + "', discount = '" + Convert.ToDouble(textBox7.Text) + "', destination = '" + textBox3.Text + "' Where id = '" + checkId + "'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();
            }
            else
            {
                DialogResult result = MessageBox.Show("Please Enter Discount Value Not A String", "Error", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            }
        }

        private void enableDisableButton()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            enableDisableButton();
            airlineUpdate();
         
        }

        private void airlineDelete()
        {
            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Delete From Airlines Where id = '" + checkId + "'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();


        }
        private void button3_Click(object sender, EventArgs e)
        {
            airlineDelete();
            enableDisableButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //back
            this.Hide();
            VendersMenu newVMenu = new VendersMenu();
            newVMenu.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //search
            if (textBox1.Text != "")
            {
                airlineList.Items.Clear();
                sqlCon.Open();
                if (!isIntergerOrDoubleBL.isInteger(textBox1.Text))
                {
                    cmd.CommandText = "SELECT * FROM Airlines WHERE name LIKE '%" + textBox1.Text + "%'";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM Airlines WHERE id LIKE '%" + textBox1.Text + "%'";
                }
                cmd.Connection = sqlCon;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem myList = new ListViewItem(dr["id"].ToString());
                    myList.SubItems.Add(dr["name"].ToString());
                    myList.SubItems.Add(dr["address"].ToString());
                    myList.SubItems.Add(dr["serviceProvider"].ToString());
                    myList.SubItems.Add(dr["contractStart"].ToString());
                    myList.SubItems.Add(dr["contractRenew"].ToString());
                    myList.SubItems.Add(dr["discount"].ToString());
                    myList.SubItems.Add(dr["destination"].ToString());
                    airlineList.Items.Add(myList);
                }
                sqlCon.Close();
            }
            else
            {
                refreshList();
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void airlineList_Click(object sender, EventArgs e)
        {

        }

        private void airlineList_MouseClick(object sender, MouseEventArgs e)
        {
            checkId = airlineList.SelectedItems[0].SubItems[0].Text;
            sqlCon.Open();
            cmd.CommandText = "Select * From Airlines Where id = " + checkId + "";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr["name"].ToString();
                textBox10.Text = dr["address"].ToString();
                textBox4.Text = dr["serviceProvider"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr["contractStart"]);
                dateTimePicker2.Value = Convert.ToDateTime(dr["contractRenew"]);
                textBox7.Text = dr["discount"].ToString();
                textBox3.Text = dr["destination"].ToString();
            }
            sqlCon.Close();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }
    }
}
