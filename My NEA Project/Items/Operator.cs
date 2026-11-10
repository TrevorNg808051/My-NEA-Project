using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Items
{
    internal class Operator : Item
    {
        public Operator(Player itemOwner) : base(itemOwner)
        {
            this.ownerOfItem = itemOwner;
            this.nameOfItem = "RandomOperation";
            this.usable = true;
        }
        public Operator()
        {
            this.nameOfItem = "RandomOperation";
            this.usable = true;
        }
        public override bool Use(Player playerUsingItem)
        {
            Random ran = new Random();
            SetOwner(playerUsingItem);
            int numberItWillGive = ran.Next(1, 5);
            switch (numberItWillGive)
            {
                case 1:
                    playerUsingItem.ReceiveOperator('+');
                    break;
                case 2:
                    playerUsingItem.ReceiveOperator('-');
                    break;
                case 3:
                    playerUsingItem.ReceiveOperator('x');
                    break;
                case 4:
                    playerUsingItem.ReceiveOperator('÷');
                    break;
            }
            return base.Use(playerUsingItem);
        }
    }
}
