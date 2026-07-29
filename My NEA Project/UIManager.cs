using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppTestingGround;

namespace My_NEA_Project
{
    internal class UIManager
    {
        private Form theFormUiWillBeIn;
        private Player thePlayer;

        private CraftingMenue craftingMenue = new CraftingMenue();
        private CraftingRecipies[] recipies = { new UpgradeStation() ,new UpgradeStation()};
        bool craftingShown = false;
        public UIManager(Form theFormUiWillBeIn, Player thePlayer)
        {
            this.theFormUiWillBeIn = theFormUiWillBeIn;
            this.thePlayer = thePlayer;

            this.craftingMenue.Location = new System.Drawing.Point(0, (theFormUiWillBeIn.Height / 3) * 2);
            this.craftingMenue.Size = new System.Drawing.Size(theFormUiWillBeIn.Width, theFormUiWillBeIn.Height / 3);

            

            int tablePanelStartingX = 3;
            foreach (CraftingRecipies cr in recipies)
            {
                
                TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
                HScrollBar hScrollBar1 = new HScrollBar();
                PictureBox pictureBox1 = new PictureBox();
                Label label1 = new Label();
                // 
                // tableLayoutPanel1
                // 
                tableLayoutPanel1.BackColor = Color.Cyan;
                tableLayoutPanel1.ColumnCount = 1;
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel1.Controls.Add(label1, 0, 1);
                tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
                tableLayoutPanel1.Location = new System.Drawing.Point(tablePanelStartingX, 3);
                tableLayoutPanel1.Name = "tableLayoutPanel1";
                tableLayoutPanel1.RowCount = 2;
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                tableLayoutPanel1.Size = new System.Drawing.Size(230, 261);
                tableLayoutPanel1.TabIndex = 0;

                // 
                // label1
                // 
                label1.AutoSize = true;
                label1.Location = new System.Drawing.Point(tablePanelStartingX, 174);
                label1.Name = "label1";
                label1.Size = new System.Drawing.Size(35, 13);
                label1.TabIndex = 1;
                label1.Text = "label1";

                // 
                // pictureBox1
                // 
                pictureBox1.BackColor = Color.Green;
                pictureBox1.Location = new System.Drawing.Point(tablePanelStartingX, 3);
                pictureBox1.Name = "pictureBox1";
                pictureBox1.Size = new System.Drawing.Size(224, 168);
                pictureBox1.TabIndex = 0;
                pictureBox1.TabStop = false;

                craftingMenue.AddingToFlowPanel(tableLayoutPanel1);
                
                tablePanelStartingX += tableLayoutPanel1.Width;
            }
            
            

            theFormUiWillBeIn.Controls.Add(craftingMenue);
            craftingMenue.Hide();
        }

        public void ToggleCrafting()
        {
            if (!craftingShown)
                craftingMenue.Show();
            else if (craftingShown)
                craftingMenue.Hide();

            craftingShown = !craftingShown;
        }
        public void ToggleSettings()
        {
            throw new NotImplementedException();
        }
        public void ToggleEquationForming()
        {
            throw new NotImplementedException();
        }
        public void ToggleInventory()
        {
            throw new NotImplementedException();
        }
    }
}
