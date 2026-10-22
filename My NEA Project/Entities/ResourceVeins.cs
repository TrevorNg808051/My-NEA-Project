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

        public ResourceVeins(int xCoord, int yCoord, int width, int height,Camara pov,World theWorldResourceIsIn) : base(xCoord, yCoord, width, height,pov,theWorldResourceIsIn)
        {
        }
        protected virtual void SetListOfDrops()
        {

        }

        protected void DropItem()
        {
            Random ran = new Random();
            int itemToBeDropped = ran.Next(0,listOfDrops.Count - 1);
            this.theWorldEntityExistIn.AddEntity(new DroppedItems(this.xCoord, this.yCoord, 1, 1, this.cam, listOfDrops[itemToBeDropped],this.theWorldEntityExistIn));
        }
        public override void GetHit()
        {
            this.hitPoint--;
            if(this.hitPoint<= 0)
            {
                this.DropItem();
                this.theWorldEntityExistIn.ReturnListOfEntities().Remove(this);
                this.RemoveSprite();
            }
        }
        
    }
}
