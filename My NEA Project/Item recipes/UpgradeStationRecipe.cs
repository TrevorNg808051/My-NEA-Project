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
        }
    }
}
