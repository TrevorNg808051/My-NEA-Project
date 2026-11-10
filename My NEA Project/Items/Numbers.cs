using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Items
{
    internal class Numbers : Item
    {
        public Numbers(Player itemOwner) : base(itemOwner)
        {
            this.ownerOfItem = itemOwner;
            this.nameOfItem = "RandomNumber";
            this.usable = true;
        }
        public Numbers()
        {
            this.nameOfItem = "RandomNumber";
            this.usable = true;
        }
        public override bool Use(Player playerUsingItem)
        {
            Random ran = new Random();
            int numberItWillGive = ran.Next(1, 13);
            SetOwner(playerUsingItem);
            playerUsingItem.ReceiveNumber(numberItWillGive);
            return base.Use(playerUsingItem);
        }
    }
}
