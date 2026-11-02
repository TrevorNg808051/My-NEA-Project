using My_NEA_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal class UpgradeStationRecipe : CraftingRecipies
    {
        public UpgradeStationRecipe(Player whoIsCrafting) : base(whoIsCrafting)
        {
            theItmeCrafted = new UpgradeStation(whoIsCrafting);

            itemStack[] materialsRequired = new itemStack[2];
            materialsRequired[0] = new itemStack { item = new Stone(), stackCount = 2 };
            materialsRequired[1] = new itemStack { item = new Wood(), stackCount = 1 };
            this.materialsRequired = materialsRequired;
        }
    }
}
