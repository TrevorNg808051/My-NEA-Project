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
        protected ICraftingMaterials[] materialsRequired;
        protected PictureBox pictureOfCraftedItems;
        protected Label listOfMaterials;
        protected Item theItmeCrafted;
        protected Player whosCrafting;
        public CraftingRecipies(Player whoIsCrafting)
        {
            this.whosCrafting = whoIsCrafting;
        }
        public bool Craftable()
        {
            return true;
        }
        public Item Craft()
        {
           
            return theItmeCrafted;
        }

    }
}
