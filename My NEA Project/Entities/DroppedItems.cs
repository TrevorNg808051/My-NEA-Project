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

        public DroppedItems(int xCoord, int yCoord, int width, int height, Camara pov,Item item,World theWorldDroppedItemIsIn) : base(xCoord, yCoord, width, height, pov,theWorldDroppedItemIsIn)
        {
            this.item = item;
        }

        public void GetPickedUp(Player thePlayer)
        {
            thePlayer.ReciveItem(this.item, 1);
            this.theWorldEntityExistIn.ReturnListOfEntities().Remove(this);
            this.RemoveSprite();
        }
    }
}
