using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace My_NEA_Project.Entities
{
    internal class Stone : Item
    {
        public Stone(Player itemOwner) : base(itemOwner)
        {
            this.ownerOfItem = itemOwner;
            this.nameOfItem = "Stone";
            this.usable = false;
        }
        public Stone()
        {
            this.nameOfItem = "Stone";
            this.usable = false;
        }
    }
}
