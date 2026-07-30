using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    public partial class Inventory : UserControl
    {
        public Inventory()
        {
            InitializeComponent();
        }
        public void RefreshInventory(itemStack[] allItemsInInventory)
        {
            int numIndex = 0;
            foreach(itemStack stack in allItemsInInventory)
            {
                if (stack.item != null)
                {
                    Button buttonRepresentingItem = new Button();
                    buttonRepresentingItem.Text = $"{stack.item} x {stack.stackCount}";
                    buttonRepresentingItem.Dock = DockStyle.Fill;

                    int column = (numIndex + 1) % 5;
                    int row = (int)Math.Floor((float)(numIndex / 5));
                    tableLayoutPanel1.Controls.Add(buttonRepresentingItem, column, row);
                }

                numIndex++;

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
