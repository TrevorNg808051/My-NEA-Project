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
        public Item()
        {

        }
        public string ReturnName()
        {
            return nameOfItem;
        }
        public virtual bool Use(Player playerUsingItem)
        {
            if (!usable)
            {
                return false;
            }
            return true;
        }
        public Player ReturnOwner()
        {
            return ownerOfItem;
        }
        public void SetOwner(Player owner)
        {
            this.ownerOfItem = owner;
        }
        public bool Usable()
        {
            return usable;
        }
    }
}
