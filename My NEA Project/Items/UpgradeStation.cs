using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal class UpgradeStation : Item
    {

        public UpgradeStation(Player itemOwner) : base(itemOwner)
        {
            this.nameOfItem = "UpgradeStation";
            usable = true;

        }
        public override void Use()
        {
            base.Use();
            ownerOfItem.PlaceStructure(this);
        }
    }
}
