using My_NEA_Project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    public partial class Inventory : UserControl
    {
        InventoryButton[] allButtonsInInventory;
        itemStack[] allItemsInCurrentInventory;
        ListBox options;
        Form formThisWillBeIn;
        Player playerUsingInventory;
        public Inventory(Form formThisWillBeIn,Player playerWithTheInventory)
        {
            this.formThisWillBeIn = formThisWillBeIn;
            InitializeComponent();
            allButtonsInInventory = new InventoryButton[tableLayoutPanel1.ColumnCount * tableLayoutPanel1.RowCount];
            playerUsingInventory = playerWithTheInventory;

            options = new ListBox();
            options.Size = new Size(200, 30);
            options.Items.Add("Use");
            options.Items.Add("Drop");
            options.Items.Add("Exit");
            this.Controls.Add(options);
            options.Click += new EventHandler(OptionSelected);
            options.Hide();

        }
        public void RefreshInventory(itemStack[] allItemsInInventory)
        {
            allItemsInCurrentInventory = allItemsInInventory;
            int numIndex = 0;
            foreach (itemStack stack in allItemsInInventory)
            {
                if (stack.item == null)
                {
                    return;

                }
                InventoryButton currentButton = allButtonsInInventory[numIndex];
                if (currentButton == null)
                {
                    InventoryButton buttonRepresentingItem = new InventoryButton(stack.item.ReturnName(), numIndex, stack.item);
                    buttonRepresentingItem.Text = $"{stack.item.ReturnName()} x {stack.stackCount}";
                    buttonRepresentingItem.Dock = DockStyle.Fill;
                    buttonRepresentingItem.Click += new EventHandler(InventoryButtonPressed);

                    allButtonsInInventory[numIndex] = buttonRepresentingItem;

                    int column = numIndex % 5;
                    int row = (int)Math.Floor((float)(numIndex / 5));
                    tableLayoutPanel1.Controls.Add(buttonRepresentingItem, column, row);
                }
                else if (currentButton.ReturnName() == stack.item.ReturnName())
                {
                    currentButton.Text = $"{stack.item.ReturnName()} x {stack.stackCount}";
                }


                numIndex++;

            }
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            formThisWillBeIn.KeyPreview = false;

        }
        private void InventoryButtonPressed(object sender, EventArgs e)
        {
            InventoryButton theButtonClicked = (InventoryButton)sender;
            options.Location = MousePosition;
            options.Show();
            options.BringToFront();
            itemBeingUsed = theButtonClicked.ReturnItem();
        }
        Item itemBeingUsed = null;
        private void OptionSelected(object sender, EventArgs e)
        {
            string option = (string)this.options.SelectedItem;
            if (itemBeingUsed != null)
            {
                switch (option)
                {
                    case "Use":
                        if(itemBeingUsed is Placible)
                        {
                            this.Hide();
                        }
                        itemBeingUsed.Use();
                        break;
                    case "Drop":
                        throw new NotImplementedException();
                        break;
                    case "Exit":
                        options.Hide();
                        break;
                }
            }

        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            tableLayoutPanel1.Top = vScrollBar1.Value * -1;
        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            tableLayoutPanel1.Focus();

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            this.Focus();
            formThisWillBeIn.KeyPreview = true;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            this.Focus();
            formThisWillBeIn.KeyPreview = true;
        }
    }
}
