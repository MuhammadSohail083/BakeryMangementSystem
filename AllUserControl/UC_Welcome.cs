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
    public partial class UC_Welcome : UserControl
    {
        public UC_Welcome()
        {
            InitializeComponent();
        }
        int num=0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (num == 0)
            {
                labelBanner.Location = new Point(24,367);
                labelBanner.ForeColor = Color.Orange;
                num++;
            }
            else if (num == 1)
            {
                labelBanner.Location = new Point(124, 367);
                labelBanner.ForeColor = Color.Green;
                num++;
            }
            else if (num == 2)
            {
                labelBanner.Location = new Point(224, 367);
                labelBanner.ForeColor = Color.RoyalBlue;
                num++;
            }
            else if (num == 3)
            {
                labelBanner.Location = new Point(324, 367);
                labelBanner.ForeColor = Color.Purple;
                num = 0;
            }
        }

        private void UC_Welcome_Load(object sender, EventArgs e)
        {
            Timer.Start();
        }
    }
}
