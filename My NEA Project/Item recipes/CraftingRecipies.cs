using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    internal abstract class CraftingRecipies
    {
        protected itemStack[] materialsRequired;
        protected PictureBox pictureOfCraftedItems;
        protected Label listOfMaterials;
        protected Item theItmeCrafted;
        protected Player whosCrafting;
        public CraftingRecipies(Player whoIsCrafting)
        {
            this.whosCrafting = whoIsCrafting;
        }
        public bool Craftable(Inventory playerInventory)
        {
            bool craftable = true;
            itemStack[] contentsOfInventory = playerInventory.ReturnInventoryContents();

            foreach (itemStack iS in materialsRequired)
            {
                bool hasItme = false;
                bool hasEnough = false;

                foreach (itemStack stackOfItems in contentsOfInventory)
                {
                    try
                    {
                        if (iS.item.ReturnName() == stackOfItems.item.ReturnName())
                        {
                            hasItme = true;
                            if (stackOfItems.stackCount >= iS.stackCount)
                            {
                                hasEnough = true;
                                break;
                            }
                        }
                    }
                    catch (NullReferenceException)
                    {
                        continue;
                    }
                }

                if (!(hasItme && hasEnough))
                {
                    return false;
                }
            }

            return craftable;
        }
        public Item Craft()
        {
            return theItmeCrafted;
        }
        public itemStack[] ReturnItemRequirement()
        {
            return materialsRequired;
        }

    }
}
