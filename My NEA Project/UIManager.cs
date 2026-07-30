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
        private CraftingRecipies[] recipies = { new UpgradeStationRecipe()};

        private Inventory inventory = new Inventory();

        private bool craftingShown = false;
        private bool inventoryShown = false;
        public UIManager(Form theFormUiWillBeIn, Player thePlayer)
        {
            this.theFormUiWillBeIn = theFormUiWillBeIn;
            this.thePlayer = thePlayer;

            //
            //craftingMenue
            //
            {
                this.craftingMenue.Location = new Point(0, (theFormUiWillBeIn.Height / 3) * 2);
                this.craftingMenue.Size = new Size(theFormUiWillBeIn.Width, theFormUiWillBeIn.Height / 3);

                int indexInCraftingRecipe = 0;
                int tablePanelStartingX = 3;
                foreach (CraftingRecipies cr in recipies)
                {
                    TableLayoutPanel craftingOption = new TableLayoutPanel();
                    HScrollBar hScrollBar1 = new HScrollBar();
                    PictureBox itemSprite = new PictureBox();
                    Label listOfMaterialsForRecipe = new Label();
                    // 
                    // tableLayoutPanel1
                    // 
                    craftingOption.BackColor = Color.Cyan;
                    craftingOption.ColumnCount = 1;
                    craftingOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                    craftingOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                    craftingOption.Controls.Add(listOfMaterialsForRecipe, 0, 1);
                    craftingOption.Controls.Add(itemSprite, 0, 0);
                    craftingOption.Location = new System.Drawing.Point(tablePanelStartingX, 3);
                    craftingOption.Name = $"{indexInCraftingRecipe}";
                    craftingOption.RowCount = 2;
                    craftingOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
                    craftingOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                    craftingOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                    craftingOption.Size = new System.Drawing.Size(230, 261);
                    craftingOption.TabIndex = 0;
                    craftingOption.Click += new EventHandler(RecipeSelected);

                    // 
                    // label1
                    // 
                    listOfMaterialsForRecipe.AutoSize = true;
                    listOfMaterialsForRecipe.Location = new System.Drawing.Point(tablePanelStartingX, 174);
                    listOfMaterialsForRecipe.Name = "label1";
                    listOfMaterialsForRecipe.Size = new System.Drawing.Size(35, 13);
                    listOfMaterialsForRecipe.TabIndex = 1;
                    listOfMaterialsForRecipe.Text = "label1";

                    // 
                    // pictureBox1
                    // 
                    itemSprite.BackColor = Color.Green;
                    itemSprite.Location = new System.Drawing.Point(tablePanelStartingX, 3);
                    itemSprite.Name = "pictureBox1";
                    itemSprite.Size = new System.Drawing.Size(224, 168);
                    itemSprite.TabIndex = 0;
                    itemSprite.TabStop = false;

                    craftingMenue.AddingToFlowPanel(craftingOption);

                    tablePanelStartingX += craftingOption.Width;
                    indexInCraftingRecipe++;
                }

                theFormUiWillBeIn.Controls.Add(craftingMenue);
                craftingMenue.Hide();
            }
            //
            //inventory
            //
            {
                inventory.Location = new Point(0, 0);
                inventory.Size = new Size(350, 300);
                theFormUiWillBeIn.Controls.Add(inventory);
                inventory.Hide();
            }
        }

        public void ToggleCrafting()
        {
            if (!craftingShown)
            {
                craftingMenue.Show();
                craftingMenue.BringToFront();
            }
            else if (craftingShown)
            {


                craftingMenue.Hide();
            }

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
            if (!inventoryShown)
            {
                inventory.RefreshInventory(thePlayer.ReturnInventory());

                inventory.Show();
                inventory.BringToFront();
            }
            else
            {
                inventory.Hide();
            }
            inventoryShown = !inventoryShown;
        }

        public void RecipeSelected(object sender, EventArgs e)
        {
            TableLayoutPanel tLP = (TableLayoutPanel)sender;
            if (recipies[int.Parse(tLP.Name)].Craftable()) 
            {
                thePlayer.ReciveItem(recipies[int.Parse(tLP.Name)].Craft(), 1);
            }
        }
    }
}
