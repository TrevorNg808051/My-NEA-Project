using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal class ResourceVeins: Entity
    {
        protected List<Item> listOfDrops;
        protected int hitPoint;
        protected int numOfDrops;

        public ResourceVeins(int xCoord, int yCoord, int width, int height,Camara pov) : base(xCoord, yCoord, width, height,pov)
        {
        }
        protected virtual void SetListOfDrops()
        {

        }

        protected void DropItem(World theWorldDropedItemWillBeIn)
        {
            Random ran = new Random();
            int itemToBeDropped = ran.Next(0,listOfDrops.Count - 1);
            theWorldDropedItemWillBeIn.AddEntity(new DroppedItems(this.xCoord, this.yCoord, 1, 1, this.cam, listOfDrops[itemToBeDropped]));
        }

        
    }
}
