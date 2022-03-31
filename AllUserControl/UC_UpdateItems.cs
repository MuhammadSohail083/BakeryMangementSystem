using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakery_Management_System.AllUserControl
{
    public partial class UC_UpdateItems : UserControl
    {
        Function fn = new Function();
        string query;

        public UC_UpdateItems()
        {
            InitializeComponent();
        }

        private void UC_UpdateItems_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void UC_UpdateItems_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            query = "Select * from Items";
            DataSet ds = fn.getData(query);
            guna2DataGridView2.DataSource = ds.Tables[0];
        }

        int id;
        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            string category = guna2DataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            string name = guna2DataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price =int.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtCategory.Text = category;
            txtItemName.Text = name;
            txtPrice.Text = price.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "Update Items set Item_Name='" + txtItemName.Text + "',Category ='" + txtCategory.Text + "',Item_Price=" + txtPrice.Text + " Where Item_Id="+id+"";
            fn.setData(query);
            loadData();

            txtItemName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
        }

        private void txtSearchItemUpdate_TextChanged(object sender, EventArgs e)
        {
            query = "Select * from Items where Item_Name like '%" + txtSearchItemUpdate.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView2.DataSource = ds.Tables[0];
        }
    }
}
