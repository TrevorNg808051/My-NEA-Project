using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Items
{
    internal class Sticks : Item
    {
        public Sticks(Player itemOwner) : base(itemOwner)
        {
            this.ownerOfItem = itemOwner;
            this.nameOfItem = "Sticks";
            this.usable = false;
        }
        public Sticks()
        {
            this.nameOfItem = "Sticks";
            this.usable = false;
        }
    }
}
