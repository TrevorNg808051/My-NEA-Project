using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    internal class InventoryButton : Button
    {
        private string itemName;
        private int indexNum;
        private Item item;
        public InventoryButton(string nameOfItem, int indexNum,Item item)
        {
            this.item = item;
            itemName = nameOfItem;
            this.indexNum = indexNum;
        }
        public int ReturnIndex()
        {
            return indexNum;
        }
        public string ReturnName()
        {
            return itemName;
        }
        public Item ReturnItem()
        {
            return item;
        }
    }
}
