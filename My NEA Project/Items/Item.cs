using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    public class Item
    {
        protected string nameOfItem;
        protected bool usable;
        protected Player ownerOfItem;
        
        public Item(Player itemOwner)
        {
            ownerOfItem = itemOwner;
        }
        public string ReturnName()
        {
            return nameOfItem;
        }
        public virtual void Use()
        {
            if (!usable)
            {
                return;
            }
        }

    }
}
