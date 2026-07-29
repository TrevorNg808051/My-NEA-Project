using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTestingGround
{
    public partial class CraftingMenue : UserControl
    {
        public CraftingMenue()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.Left = hScrollBar1.Value * -1;
        }
        public void AddingToFlowPanel(Control thingToAdd)
        {
            flowLayoutPanel1.Controls.Add(thingToAdd);
        }
    }
}
