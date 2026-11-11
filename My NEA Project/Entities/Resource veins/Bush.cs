using My_NEA_Project.Items;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Entities
{
    internal class Bush: ResourceVeins
    {
        public Bush(int xCoord, int yCoord, Camara pov, World theWorldRockIsIn, int width = 2, int height = 1) : base(xCoord, yCoord, width, height, pov, theWorldRockIsIn)
        {
            SetListOfDrops();
        }
        protected override void SetListOfDrops()
        {
            this.listOfDrops = new List<Item> { new Numbers(),new Operator() };
        }

        protected override void DropItem()
        {
            Random ran = new Random();
            int itemToBeDropped = ran.Next(0, 10);
            if (itemToBeDropped > 3)
            {
                this.theWorldEntityExistIn.AddEntity(new DroppedItems(this.xCoord, this.yCoord, 1, 1, this.cam, new Numbers(), this.theWorldEntityExistIn));
            }
            else 
            {
                this.theWorldEntityExistIn.AddEntity(new DroppedItems(this.xCoord, this.yCoord, 1, 1, this.cam, new Operator(), this.theWorldEntityExistIn));
            }
        }
    }
}
