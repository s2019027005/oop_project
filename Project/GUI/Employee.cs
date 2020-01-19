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
    public partial class Employee : Form
    {
        EmployeeDTO DTO;
        SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-63Q74F5;Initial Catalog=Project;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        string checkId;
        int check;
        
        public Employee()
        {
            InitializeComponent();
            DTO = new EmployeeDTO();
            enableDisableButton();
        }

        private void refreshList()
        {
            employeeList.Items.Clear();
            sqlCon.Open();
            //SqlCommand cmd1 = new SqlCommand("Select * From Customers", sqlCon);
            cmd.CommandText = "Select * From Employees";
            cmd.Connection = sqlCon;
            //cmd.Parameters.Add(sqlCon);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem myList = new ListViewItem(dr["eID"].ToString());
                myList.SubItems.Add(dr["firstName"].ToString());
                myList.SubItems.Add(dr["lastName"].ToString());
                myList.SubItems.Add(dr["email"].ToString());
                myList.SubItems.Add(dr["password"].ToString());
                myList.SubItems.Add(dr["idCardNo"].ToString());
                myList.SubItems.Add(dr["contactNo"].ToString());
                myList.SubItems.Add(dr["designation"].ToString());
                myList.SubItems.Add(dr["salary"].ToString());
                myList.SubItems.Add(dr["dateOfJoining"].ToString());
                employeeList.Items.Add(myList);
            }
            sqlCon.Close();

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            checkBox1.Checked = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //first
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //last
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //email
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //idCard
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //ContactNo
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //Designation
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //Salary
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //DateOfJoining
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != ""&& textBox8.Text != ""&&textBox10.Text!="")
            {

                DTO.FirstName = textBox2.Text;
                DTO.LastName = textBox3.Text;
                DTO.Email = textBox4.Text;
                DTO.IdCardNo = textBox5.Text;
                DTO.ContactNo = textBox6.Text;              
                DTO.Destination = textBox7.Text;
                DTO.DateOfJoining = dateTimePicker1.Value;
                DTO.Password = textBox10.Text;
                if (checkBox1.Checked==true)
                {
                    DTO.IsAdmin = Convert.ToInt32(checkBox1.Checked=true);
                }
                else
                {
                    DTO.IsAdmin = Convert.ToInt32(checkBox1.Checked=false);
                }
                
                if (isIntergerOrDoubleBL.isDouble(textBox8.Text))
                {
                    DTO.Salary = Convert.ToDouble(textBox8.Text);
                    sqlCon.Open();
                    cmd.CommandText = "INSERT INTO Employees(firstName,lastName,email,password,idCardNo,contactNo,designation,salary,dateOfJoining,isAdmin) VALUES ('" + DTO.FirstName + "','" + DTO.LastName + "','" + DTO.Email + "','" + DTO.Password + "','" + DTO.IdCardNo + "','" + DTO.ContactNo + "','" + DTO.Destination + "','" + DTO.Salary + "','" + DTO.DateOfJoining + "','" + DTO.IsAdmin + "')";
                    cmd.Connection = sqlCon;
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    refreshList();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Please Enter Salary Value Not A String", "Error", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        enableDisableButton();
                    }
                }
                

                //custBL.addCustomer(DTO);
                //var row = new string[] { DTO.Id.ToString(), DTO.FirstName.ToString(), DTO.LastName.ToString(), DTO.Email.ToString(), DTO.IdCardNo.ToString(), DTO.ContactNo.ToString(), DTO.Details.ToString() };
                //ListViewItem _customers = new ListViewItem(row);
                //customerLIst.Items.Add(_customers);

                //sqlObj.sqlConnection().Open();

                

            }
            else
            {
                MessageBox.Show("Please Fill All The Fields", "Opps");
            }
        }

        private void enableDisableButton()
        {
            button3.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = true;
        }
        private void EmpUpdate()
        {
            if (isIntergerOrDoubleBL.isDouble(textBox8.Text))
            { 
            sqlCon.Open();
            cmd.CommandText = "Update Employees SET firstName = '" + textBox2.Text + "', lastName = '" + textBox3.Text + "', email = '" + textBox4.Text + "',password = '" + textBox10.Text + "', idCardNo = '" + textBox5.Text + "', contactNo = '" + textBox6.Text + "', designation = '" + textBox7.Text + "', salary = '" + Convert.ToDouble(textBox8.Text) + "', dateOfJoining = '" + dateTimePicker1.Value + "',isAdmin = '" + Convert.ToInt32(check) + "' Where eID = '" + checkId + "'";
            cmd.Connection = sqlCon;
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();
            }
            else
            {
                DialogResult result = MessageBox.Show("Please Enter Salary Value Not A String", "Error", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    //;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button2.Enabled = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            enableDisableButton();
            EmpUpdate();
            
        }
        private void EmpDelete()
        {
            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Delete From Employees Where eID = '" + checkId + "'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
            EmpDelete();
            enableDisableButton();

        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu newMenu = new Main_Menu();
            newMenu.ShowDialog();
            this.Close();
        }

        private void employeeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void employeeList_MouseClick(object sender, MouseEventArgs e)
        {
            checkId = employeeList.SelectedItems[0].SubItems[0].Text;
            sqlCon.Open();
            cmd.CommandText = "Select * From Employees Where eID = " + checkId + "";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr["firstName"].ToString();
                textBox3.Text = dr["lastName"].ToString();
                textBox4.Text = dr["email"].ToString();
                textBox10.Text = dr["password"].ToString();
                textBox5.Text = dr["idCardNo"].ToString();
                textBox6.Text = dr["contactNo"].ToString();
                textBox7.Text = dr["designation"].ToString();
                textBox8.Text = dr["salary"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr["dateOfJoining"]);
                if (Convert.ToInt32(dr["isAdmin"]) == 1)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                
            }
            sqlCon.Close();
            button3.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                employeeList.Items.Clear();
                
            }
            else
            {
                refreshList();
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            enableDisableButton();
            textBox1.Text = "Enter Id Or First Name";
            refreshList();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Id Or First Name")
            {
                textBox1.Text = "";
            }
            refreshList();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Id Or First Name";
                textBox1.ForeColor = Color.Gray;
            }
            refreshList();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                check = 1;
            }
            else
            {
                check = 0;
            }
        }
    }
}
