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
    public partial class Booking : Form
    {
        BookingDTO DTO;
        SqlConnection sqlCon;
        SqlCommand cmd;
        string checkId;
        public Booking()
        {
            InitializeComponent();
            DTO = new BookingDTO();
            sqlCon = new SqlConnection("Data Source=DESKTOP-63Q74F5;Initial Catalog=Project;Integrated Security=True");
            cmd = new SqlCommand();
        }

        private void refreshList()
        {
            bookingsList.Items.Clear();
            sqlCon.Open();
            cmd.CommandText = "Select * From Bookings";
            cmd.Connection = sqlCon;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem myList = new ListViewItem(dr["id"].ToString());
                myList.SubItems.Add(dr["name"].ToString());
                myList.SubItems.Add(dr["fromDate"].ToString());
                myList.SubItems.Add(dr["endDate"].ToString());
                myList.SubItems.Add(dr["book"].ToString());
                myList.SubItems.Add(dr["bookingDetails"].ToString());
                bookingsList.Items.Add(myList);
            }
            sqlCon.Close();

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Refresh();
            dateTimePicker2.Refresh();

        }

        private void Booking_Load(object sender, EventArgs e)
        {

            refreshList();
            enableDisableButton();
            sqlCon.Open();
            cmd.CommandText = "Select CONCAT (firstName,' ',lastName) AS cName From Customers";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["cName"].ToString());
            }
            sqlCon.Close();

            comboBox2.Items.Add("Bus");
            comboBox2.Items.Add("Car");
            comboBox2.Items.Add("Airline");
            comboBox2.Items.Add("Hotel");
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
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {

                DTO.CusName = comboBox1.Text;
                DTO.BookDate = dateTimePicker1.Value;
                DTO.Bookends = dateTimePicker2.Value;
                DTO.Book = comboBox2.Text;
                DTO.BookinDetails = comboBox3.Text;

                sqlCon.Open();
                cmd.CommandText = "INSERT INTO Bookings(name,fromDate,endDate,book,bookingDetails) VALUES ('" + DTO.CusName + "','" + DTO.BookDate + "','" + DTO.Bookends + "','" + DTO.Book + "','" + DTO.BookinDetails + "')";
                cmd.Connection = sqlCon;
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                refreshList();
            }
            else
            {
                MessageBox.Show("Please Fill All The Fields", "Opps");
            }
        }

        private void bookingUpdate()
        {
            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Update Bookings SET name = '" + comboBox1.Text + "', fromDate = '" + Convert.ToDateTime(dateTimePicker1.Text) + "', endDate = '" + Convert.ToDateTime(dateTimePicker2.Text) + "', book = '" + comboBox2.Text + "', bookingDetails = '" + comboBox3.Text + "' Where id = '" + checkId + "'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
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
            bookingUpdate();
         
        }

        private void bookingDelete()
        {
            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Delete From Bookings Where id = '" + checkId + "'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();


        }
        private void button3_Click(object sender, EventArgs e)
        {
            bookingDelete();
            enableDisableButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //back
            this.Hide();
            Main_Menu newMenu = new Main_Menu();
            newMenu.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //search
            if (textBox1.Text != "")
            {

                bookingsList.Items.Clear();
                sqlCon.Open();
                if (!isIntergerOrDoubleBL.isInteger(textBox1.Text))
                {
                    cmd.CommandText = "SELECT * FROM Bookings WHERE name LIKE '%" + textBox1.Text + "%'";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM Bookings WHERE id LIKE '%" + textBox1.Text + "%'";
                }
                cmd.Connection = sqlCon;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem myList = new ListViewItem(dr["id"].ToString());
                    myList.SubItems.Add(dr["name"].ToString());
                    myList.SubItems.Add(dr["fromDate"].ToString());
                    myList.SubItems.Add(dr["endDate"].ToString());
                    myList.SubItems.Add(dr["book"].ToString());
                    myList.SubItems.Add(dr["BookingDetails"].ToString());
                    bookingsList.Items.Add(myList);
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

        private void bookingsList_MouseClick(object sender, MouseEventArgs e)
        {
            checkId = bookingsList.SelectedItems[0].SubItems[0].Text;
            sqlCon.Open();
            cmd.CommandText = "Select * From Bookings Where id = " + checkId + "";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Text = dr["name"].ToString();        
                dateTimePicker1.Value = Convert.ToDateTime(dr["fromDate"]);
                dateTimePicker2.Value = Convert.ToDateTime(dr["endDate"]);
                comboBox2.Text = dr["book"].ToString();
                comboBox3.Text = dr["bookingDetails"].ToString();
            }
            sqlCon.Close();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //book

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cName
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox3.Text = "";
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox2.Text == "Bus")
            {
                comboBox3.Items.Clear();
                comboBox3.Text = "";
                sqlCon.Open();
                cmd.CommandText = "Select CONCAT (name,' ',routesAvailaible,' ',busModels) AS busDetails From Buses";
                cmd.Connection = sqlCon;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["busDetails"].ToString());
                }
                sqlCon.Close();
            }
            else if (comboBox2.Text == "Car")
            {
                comboBox3.Items.Clear();
                comboBox3.Text = "";
                sqlCon.Open();
                cmd.CommandText = "Select CONCAT (name,' ',citiesAvailaible,' ',driver) AS carDetails From Cars";
                cmd.Connection = sqlCon;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["carDetails"].ToString());
                }
                sqlCon.Close();
            }
            else if (comboBox2.Text == "Hotel")
            {
                comboBox3.Items.Clear();
                comboBox3.Text = "";
                sqlCon.Open();
                cmd.CommandText = "Select CONCAT (name,' ',hotelStatus,' ',totalRooms) AS hotelDetails From Hotels";
                cmd.Connection = sqlCon;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["hotelDetails"].ToString());
                }
                sqlCon.Close();
            }
            else if (comboBox2.Text == "Airline")
            {
                comboBox3.Items.Clear();
                comboBox3.Text = "";
                sqlCon.Open();
                cmd.CommandText = "Select CONCAT (name,' ',serviceProvider,' ',destination) AS airlineDetails From Airlines";
                cmd.Connection = sqlCon;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["airlineDetails"].ToString());
                }
                sqlCon.Close();
            }
        }
    }
}
