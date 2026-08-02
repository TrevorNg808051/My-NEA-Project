using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal class DroppedItems : Entity
    {
        private Item item;

        public DroppedItems(int xCoord, int yCoord, int width, int height, Camara pov) : base(xCoord, yCoord, width, height, pov)
        {
        }

        public void GetPickedUp()
        {

        }
    }
}
