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
    public partial class Equipment : Form
    {
        EquipmentDTO DTO;
        SqlConnection sqlCon;
        SqlCommand cmd;
        string checkId;
        public Equipment()
        {
            InitializeComponent();
            DTO = new EquipmentDTO();
            sqlCon = new SqlConnection("Data Source=DESKTOP-63Q74F5;Initial Catalog=Project;Integrated Security=True");
            cmd = new SqlCommand();
        }

        private void refreshList()
        {
            equipmentList.Items.Clear();
            sqlCon.Open();
            cmd.CommandText = "Select * From Equipments";
            cmd.Connection = sqlCon;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem myList = new ListViewItem(dr["id"].ToString());
                myList.SubItems.Add(dr["eqName"].ToString());
                myList.SubItems.Add(dr["eqQuantity"].ToString());
                myList.SubItems.Add(dr["assignedTo"].ToString());
                equipmentList.Items.Add(myList);
            }
            sqlCon.Close();

            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Equipment_Load(object sender, EventArgs e)
        {
            enableDisableButton();
            refreshList();
            sqlCon.Open();
            cmd.CommandText = "Select CONCAT (firstName,' ',lastName) AS cName From Customers";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["cName"].ToString());
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
            //quantity
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //assigned
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update
            enableDisableButton();
            equipmentUpdate();
        }

        private void equipmentUpdate()
        {
            if (isIntergerOrDoubleBL.isInteger(textBox4.Text))
            {
                sqlCon.Open();
                cmd.Connection = sqlCon;
                cmd.CommandText = "Update Equipments SET eqName = '" + textBox3.Text + "', eqQuantity = '" + Convert.ToInt32(textBox4.Text) + "',assignedTo = '" + comboBox1.Text + "' Where id = '" + checkId + "'";
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                refreshList();
            }
            else
            {
                DialogResult result = MessageBox.Show("Please Enter Quantity Value Not A String", "Error", MessageBoxButtons.OK);
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
            if (textBox4.Text != "" && textBox3.Text != ""&&comboBox1.Text!="")
            {



                if (isIntergerOrDoubleBL.isInteger(textBox4.Text))
                {
                    DTO.EqpName = textBox3.Text;
                    DTO.EqpQty = Convert.ToInt32(textBox4.Text);
                    DTO.EqpAsgn = comboBox1.Text;

                    sqlCon.Open();
                    cmd.CommandText = "INSERT INTO Equipments(eqName,eqQuantity,assignedTo) VALUES ('" + DTO.EqpName + "','" + DTO.EqpQty + "','" + DTO.EqpAsgn + "')";
                    cmd.Connection = sqlCon;
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    refreshList();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Please Enter Quantity Value Not A String", "Error", MessageBoxButtons.OK);
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
            equipmentDelete();
        }

        private void equipmentDelete()
        {
            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Delete From Equipments Where id = '" + checkId + "'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            checkId = equipmentList.SelectedItems[0].SubItems[0].Text;
            sqlCon.Open();
            cmd.CommandText = "Select * From Equipments Where id = " + checkId + "";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox3.Text = dr["eqName"].ToString();
                textBox4.Text = dr["eqQuantity"].ToString();
                comboBox1.Text = dr["assignedTo"].ToString();
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
                equipmentList.Items.Clear();
                sqlCon.Open();
                if (!isIntergerOrDoubleBL.isInteger(textBox1.Text))
                {
                    cmd.CommandText = "SELECT * FROM Equipments WHERE eqName LIKE '%" + textBox1.Text + "%'";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM Equipments WHERE id LIKE '%" + textBox1.Text + "%'";
                }
                cmd.Connection = sqlCon;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem myList = new ListViewItem(dr["id"].ToString());
                    myList.SubItems.Add(dr["eqName"].ToString());
                    myList.SubItems.Add(dr["eqQuantity"].ToString());
                    myList.SubItems.Add(dr["assignedTo"].ToString());
                    equipmentList.Items.Add(myList);
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
    }
}
