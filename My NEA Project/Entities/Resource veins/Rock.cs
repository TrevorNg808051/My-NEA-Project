using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Entities
{
    internal class Rock : ResourceVeins
    {
        public Rock(int xCoord, int yCoord, Camara pov,World theWorldRockIsIn, int width = 3, int height = 3) : base(xCoord, yCoord, width, height, pov,theWorldRockIsIn)
        {
            SetListOfDrops();
        }
        protected override void SetListOfDrops()
        {
            this.listOfDrops = new List<Item> { new Stone()};
        }
    }
}
