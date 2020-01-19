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
    public partial class Customer : Form
    {
        int _id = 0;
        CustomerDTO DTO;
        SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-63Q74F5;Initial Catalog=Project;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        string checkId;
        public Customer()
        {
            InitializeComponent();
            DTO = new CustomerDTO();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AddCustomer newAddCust = new AddCustomer();
            //newAddCust.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu newMenu = new Main_Menu();
            newMenu.ShowDialog();
            this.Close();
        }

        private void customerLIst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            Update.Enabled = false;
            Delete.Enabled = false;
            
            refreshList();
            
        }

        private void refreshList()
        {
            customerLIst.Items.Clear();
            sqlCon.Open();
            //SqlCommand cmd1 = new SqlCommand("Select * From Customers", sqlCon);
            cmd.CommandText = "Select * From Customers";
            cmd.Connection = sqlCon;
            //cmd.Parameters.Add(sqlCon);
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem myList = new ListViewItem(dr["cID"].ToString());
                myList.SubItems.Add(dr["firstName"].ToString());
                myList.SubItems.Add(dr["lastName"].ToString());
                myList.SubItems.Add(dr["email"].ToString());
                myList.SubItems.Add(dr["idCardNo"].ToString());
                myList.SubItems.Add(dr["contactNo"].ToString());
                myList.SubItems.Add(dr["contactDetails"].ToString());
                customerLIst.Items.Add(myList);
            }
            sqlCon.Close();

            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox2.Text != "")
            {

                DTO.FirstName = textBox3.Text;
                DTO.LastName = textBox4.Text;
                DTO.Email = textBox5.Text;
                DTO.ContactNo = textBox2.Text;
                DTO.IdCardNo = textBox6.Text;
                DTO.Details = textBox7.Text;
                DTO.Password = "";
                DTO.Id = _id;
                _id = _id + 1;

                //custBL.addCustomer(DTO);
                //var row = new string[] { DTO.Id.ToString(), DTO.FirstName.ToString(), DTO.LastName.ToString(), DTO.Email.ToString(), DTO.IdCardNo.ToString(), DTO.ContactNo.ToString(), DTO.Details.ToString() };
                //ListViewItem _customers = new ListViewItem(row);
                //customerLIst.Items.Add(_customers);

                //sqlObj.sqlConnection().Open();

                sqlCon.Open();
                cmd.CommandText = "INSERT INTO Customers(firstName,lastName,email,password,idCardNo,contactNo,contactDetails) VALUES ('" + DTO.FirstName + "','" + DTO.LastName + "','" + DTO.Email + "','" + DTO.Password + "','" + DTO.IdCardNo + "','" + DTO.ContactNo + "','" + DTO.Details + "')";
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //first
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //last
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //email
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //cnic
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //contact
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //details
        }

        private void CustUpdate()
        {

            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Update Customers SET firstName = '"+ textBox3.Text+"', lastName = '"+ textBox4.Text + "', email = '"+ textBox5.Text +"', idCardNo = '"+textBox6.Text+"', contactNo = '"+ textBox2.Text +"', contactDetails = '"+textBox7.Text+ "' Where cID = '"+checkId+"'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();
        }

        private void CustDelete()
        {
            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Delete From Customers Where cID = '"+checkId+"'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();


        }
        private void Update_Click(object sender, EventArgs e)
        {
            CustUpdate();
            button4.Enabled = true;
            Update.Enabled = false;
            Delete.Enabled = false;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            CustDelete();
            Delete.Enabled = false;
            Update.Enabled = false;
            button4.Enabled = true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        { 
        }

        private void customerLIst_MouseClick(object sender, MouseEventArgs e)
        {
            checkId = customerLIst.SelectedItems[0].SubItems[0].Text;
            sqlCon.Open();
            cmd.CommandText = "Select * From Customers Where cID = " + checkId + "";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) { 
            textBox3.Text = dr["firstName"].ToString();
            textBox4.Text = dr["lastName"].ToString();
            textBox5.Text = dr["email"].ToString();
            textBox6.Text = dr["idCardNo"].ToString();
            textBox2.Text = dr["contactNo"].ToString();
            textBox7.Text = dr["contactDetails"].ToString();
            }
            sqlCon.Close();
            button4.Enabled = false;
            Update.Enabled = true;
            Delete.Enabled = true;

        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
             if (textBox1.Text != "")
              {
                    customerLIst.Items.Clear();
                    sqlCon.Open();
                if (!isIntergerOrDoubleBL.isInteger(textBox1.Text))
                {
                    cmd.CommandText = "SELECT * FROM Customers WHERE firstName LIKE '%"+textBox1.Text+"%'";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM Customers WHERE cID LIKE '%"+textBox1.Text+"%'";
                }
                    cmd.Connection = sqlCon;
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListViewItem myList = new ListViewItem(dr["cID"].ToString());
                        myList.SubItems.Add(dr["firstName"].ToString());
                        myList.SubItems.Add(dr["lastName"].ToString());
                        myList.SubItems.Add(dr["email"].ToString());
                        myList.SubItems.Add(dr["idCardNo"].ToString());
                        myList.SubItems.Add(dr["contactNo"].ToString());
                        myList.SubItems.Add(dr["contactDetails"].ToString());
                        customerLIst.Items.Add(myList);
                    }
                    sqlCon.Close();
                }
                    else
                    {
                        refreshList();
                    }
        }

        private void refresh(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
