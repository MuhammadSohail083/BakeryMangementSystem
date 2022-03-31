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
    public partial class UC_AddItems : UserControl
    {
        Function fn = new Function();
        String query;

        public UC_AddItems()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            query = "insert into Items (Item_Name,Category,Item_Price) values ('" + txtItemName.Text + "','" + txtCategory.Text + "'," + txtPrice.Text + ")";
            fn.setData(query);
            clearAll();
        }

        public void clearAll()
        {
            txtCategory.SelectedIndex = -1;
            txtItemName.Clear();
            txtPrice.Clear();
        }


    }
}
