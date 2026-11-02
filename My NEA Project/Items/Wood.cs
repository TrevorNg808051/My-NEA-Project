using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Entities
{
    internal class Wood : Item
    {
        public Wood(Player itemOwner) : base(itemOwner)
        {
            this.ownerOfItem = itemOwner;
            this.nameOfItem = "Wood";
            this.usable = false;
        }
        public Wood()
        {
            this.nameOfItem = "Wood";
            this.usable = false;
        }
    }
}
