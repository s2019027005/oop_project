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
    public partial class Hotel : Form
    {
        HotelDTO DTO;
        SqlConnection sqlCon;
        SqlCommand cmd;
        string checkId;
        public Hotel()
        {
            InitializeComponent();
            DTO = new HotelDTO();
            sqlCon = new SqlConnection("Data Source=DESKTOP-63Q74F5;Initial Catalog=Project;Integrated Security=True");
            cmd = new SqlCommand();

        }

        private void Hotel_Load(object sender, EventArgs e)
        {
            enableDisableButton();
            refreshList();
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
            //dis
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //route
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //type
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //model
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            enableDisableButton();
            hotelUpdate();
        }

        private void hotelUpdate()
        {
            if (isIntergerOrDoubleBL.isDouble(textBox7.Text))
            {
                sqlCon.Open();
                cmd.Connection = sqlCon;
                cmd.CommandText = "Update Hotels SET name = '" + textBox2.Text + "', address = '" + textBox10.Text + "', serviceProvider = '" + textBox4.Text + "', contractStart = '" + dateTimePicker1.Value + "', contractRenew = '" + dateTimePicker2.Value + "', discount = '" + Convert.ToDouble(textBox7.Text) + "', hotelStatus = '" + textBox3.Text + "',roomTypes = '" + textBox8.Text + "',locationView = '" + textBox9.Text + "',totalRooms = '" + Convert.ToInt32(textBox5.Text) + "' Where id = '" + checkId + "'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            //add
            if (textBox2.Text != "" && textBox10.Text != "" && textBox4.Text != "" && textBox7.Text != "" && textBox3.Text != "" && textBox9.Text != "" && textBox8.Text != ""&& textBox5.Text != "")
            {



                if (isIntergerOrDoubleBL.isDouble(textBox7.Text)&&isIntergerOrDoubleBL.isInteger(textBox5.Text))
                {
                    DTO.CName = textBox2.Text;
                    DTO.CAddress = textBox10.Text;
                    DTO.CService = textBox4.Text;
                    DTO.CContractStart = dateTimePicker1.Value;
                    DTO.CRecontractRenew = dateTimePicker2.Value;
                    DTO.CDiscount = Convert.ToDouble(textBox7.Text);
                    DTO.HStatus = textBox3.Text;
                    DTO.HRoomtype = textBox8.Text;
                    DTO.HLocation = textBox9.Text;
                    DTO.HRoom = Convert.ToInt32(textBox5.Text);

                    sqlCon.Open();
                    cmd.CommandText = "INSERT INTO Hotels(name,address,serviceProvider,contractStart,contractRenew,discount,hotelStatus,roomTypes,locationView,totalRooms) VALUES ('" + DTO.CName + "','" + DTO.CAddress + "','" + DTO.CService + "','" + DTO.CContractStart + "','" + DTO.CRecontractRenew + "','" + DTO.CDiscount + "','" + DTO.HStatus + "','" + DTO.HRoomtype + "','" + DTO.HLocation + "','" + DTO.HRoom + "')";
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

        private void refreshList()
        {
            hotelList.Items.Clear();
            sqlCon.Open();
            cmd.CommandText = "Select * From Hotels";
            cmd.Connection = sqlCon;

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
                myList.SubItems.Add(dr["hotelStatus"].ToString());
                myList.SubItems.Add(dr["roomTypes"].ToString());
                myList.SubItems.Add(dr["locationView"].ToString());
                myList.SubItems.Add(dr["totalRooms"].ToString());
                hotelList.Items.Add(myList);
            }
            sqlCon.Close();

            textBox2.Text = "";
            textBox10.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox3.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Refresh();
            dateTimePicker2.Refresh();
        }

        private void enableDisableButton()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            enableDisableButton();
            hotelDelete();
        }

        private void hotelDelete()
        {
            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Delete From Hotels Where id = '" + checkId + "'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //back
            this.Hide();
            VendersMenu newVMenu = new VendersMenu();
            newVMenu.ShowDialog();
            this.Close();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                hotelList.Items.Clear();
                sqlCon.Open();
                if (!isIntergerOrDoubleBL.isInteger(textBox1.Text))
                {
                    cmd.CommandText = "SELECT * FROM Hotels WHERE name LIKE '%" + textBox1.Text + "%'";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM Hotels WHERE id LIKE '%" + textBox1.Text + "%'";
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
                    myList.SubItems.Add(dr["hotelStatus"].ToString());
                    myList.SubItems.Add(dr["roomTypes"].ToString());
                    myList.SubItems.Add(dr["locationView"].ToString());
                    myList.SubItems.Add(dr["totalRooms"].ToString());
                    hotelList.Items.Add(myList);
                }
                sqlCon.Close();
            }
            else
            {
                refreshList();
            }
        }

        private void hotelList_MouseClick(object sender, MouseEventArgs e)
        {
            checkId = hotelList.SelectedItems[0].SubItems[0].Text;
            sqlCon.Open();
            cmd.CommandText = "Select * From Hotels Where id = " + checkId + "";
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
                textBox3.Text = dr["hotelStatus"].ToString();
                textBox8.Text = dr["roomTypes"].ToString();
                textBox9.Text = dr["locationView"].ToString();
                textBox5.Text = dr["totalRooms"].ToString();
            }
            sqlCon.Close();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }
    }
}
