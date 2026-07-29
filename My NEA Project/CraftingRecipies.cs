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
        ICraftingMaterials[] materialsRequired;
        PictureBox pictureOfCraftedItems;
        Label listOfMaterials;
        public bool Craftable()
        {
            return true;
        }

    }
}
