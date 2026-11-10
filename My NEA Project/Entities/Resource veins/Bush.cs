using My_NEA_Project.Items;
using System;
using System.Collections.Generic;
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
    }
}
