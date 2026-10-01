using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Entities
{
    internal class Stone : ResourceVeins
    {
        public Stone(int xCoord, int yCoord, int width, int height, Camara pov) : base(xCoord, yCoord, width, height, pov)
        {
        }
        protected override void SetListOfDrops()
        {
            
        }
    }
}
