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
        protected Iitem theItmeCrafted;
        public bool Craftable()
        {
            return true;
        }
        public Iitem Craft()
        {
           
            return theItmeCrafted;
        }

    }
}
