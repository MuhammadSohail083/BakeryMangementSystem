using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace Bakery_Management_System.AllUserControl
{
    public partial class UC_PlaceOrder : UserControl
    {
        Function fn = new Function();
        string query;

        public UC_PlaceOrder()
        {
            InitializeComponent();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboCategory.Text;
            query= "Select Item_Name from Items where Category = '" + category+"'";
            showItemList(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string category = comboCategory.Text;
            query = "Select Item_Name from Items where Category = '" + category + "' and Item_Name like '%"+txtSearch.Text+"%'";
            showItemList(query);
        }
        
        private void showItemList(string query)
        {
            listBox1.Items.Clear();
            DataSet ds = fn.getData(query);
            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantityUpDown.ResetText();
            txtTotal.Clear();
            

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            txtItemName.Text = text;
            query = "select Item_Price from Items where Item_Name = '" + text + "'";
            DataSet ds = fn.getData(query);

            try
            {
                   txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        private void txtQuantityUpDown_ValueChanged(object sender, EventArgs e)
        {
            int quan = int.Parse(txtQuantityUpDown.Value.ToString());
            int price = int.Parse(txtPrice.Text.ToString());
            txtTotal.Text = (quan * price).ToString();
        }


        int amount;
        private void guna2DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(guna2DataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected int n, total = 0;

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView3.Rows.RemoveAt(this.guna2DataGridView3.SelectedRows[0].Index);
            }
            catch (Exception)
            {

                throw;
            }
            total -= amount;
            labelTotalAmount.Text = "Rs. " + total;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer Bill";
            printer.SubTitle = string.Format("DATE:{0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payable Amount : " + labelTotalAmount.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView3);

            total = 0;
            guna2DataGridView3.Rows.Clear();
            labelTotalAmount.Text = "Rs. " + total;
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text!="0" && txtTotal.Text != "")
            {
                n = guna2DataGridView3.Rows.Add();
                guna2DataGridView3.Rows[n].Cells[0].Value = txtItemName.Text;
                guna2DataGridView3.Rows[n].Cells[1].Value = txtPrice.Text;
                guna2DataGridView3.Rows[n].Cells[2].Value = txtQuantityUpDown.Text;
                guna2DataGridView3.Rows[n].Cells[3].Value = txtTotal.Text;

                total = total + int.Parse(txtTotal.Text); labelTotalAmount.Text = "Rs. " + total;
            }
            else
            {
                MessageBox.Show("Minimun Quantity of Item Must be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtItemName.Clear();
            txtPrice.Clear();
            txtQuantityUpDown.ResetText();
            txtTotal.Clear();
            txtSearch.Clear();
        }
    }
}
