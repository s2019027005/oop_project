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
    public partial class Kitchen : Form
    {
        KitchenDTO DTO;
        SqlConnection sqlCon;
        SqlCommand cmd;
        string checkId;
        public Kitchen()
        {
            InitializeComponent();
            DTO = new KitchenDTO();
            sqlCon = new SqlConnection("Data Source=DESKTOP-63Q74F5;Initial Catalog=Project;Integrated Security=True");
            cmd = new SqlCommand();
        }

        private void refreshList()
        {
            kitchenList.Items.Clear();
            sqlCon.Open();
            //SqlCommand cmd1 = new SqlCommand("Select * From Customers", sqlCon);
            cmd.CommandText = "Select * From KitchenItems";
            cmd.Connection = sqlCon;
            //cmd.Parameters.Add(sqlCon);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem myList = new ListViewItem(dr["id"].ToString());
                myList.SubItems.Add(dr["itemName"].ToString());
                myList.SubItems.Add(dr["itemQuantity"].ToString());
                kitchenList.Items.Add(myList);
            }
            sqlCon.Close();

            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Kitchen_Load(object sender, EventArgs e)
        {
            enableDisableButton();
            refreshList();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //update
            enableDisableButton();
            kitchenUpdate();
        }

        private void kitchenUpdate()
        {
            if (isIntergerOrDoubleBL.isInteger(textBox4.Text))
            {
                sqlCon.Open();
                cmd.Connection = sqlCon;
                cmd.CommandText = "Update KitchenItems SET itemName = '" + textBox3.Text + "', itemQuantity = '" + Convert.ToInt32(textBox4.Text) + "' Where id = '" + checkId + "'";
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
            if (textBox4.Text != "" && textBox3.Text != "")
            {



                if (isIntergerOrDoubleBL.isInteger(textBox4.Text))
                {
                    DTO.ItmName = textBox3.Text;
                    DTO.ItmQty = Convert.ToInt32(textBox4.Text);

                    sqlCon.Open();
                    cmd.CommandText = "INSERT INTO KitchenItems(itemName,itemQuantity) VALUES ('" + DTO.ItmName + "','" + DTO.ItmQty + "')";
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
            //delete
            enableDisableButton();
            kitchenDelete();
        }

        private void kitchenDelete()
        {
            sqlCon.Open();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Delete From KitchenItems Where id = '" + checkId + "'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            refreshList();
        }

        private void kitchenList_MouseClick(object sender, MouseEventArgs e)
        {
            checkId = kitchenList.SelectedItems[0].SubItems[0].Text;
            sqlCon.Open();
            cmd.CommandText = "Select * From KitchenItems Where id = " + checkId + "";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox3.Text = dr["itemName"].ToString();
                textBox4.Text = dr["itemQuantity"].ToString();
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
                kitchenList.Items.Clear();
                sqlCon.Open();
                if (!isIntergerOrDoubleBL.isInteger(textBox1.Text))
                {
                    cmd.CommandText = "SELECT * FROM KitchenItems WHERE itemName LIKE '%" + textBox1.Text + "%'";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM KitchenItems WHERE id LIKE '%" + textBox1.Text + "%'";
                }
                cmd.Connection = sqlCon;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem myList = new ListViewItem(dr["id"].ToString());
                    myList.SubItems.Add(dr["itemName"].ToString());
                    myList.SubItems.Add(dr["itemQuantity"].ToString());
                    kitchenList.Items.Add(myList);
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
    }
}
