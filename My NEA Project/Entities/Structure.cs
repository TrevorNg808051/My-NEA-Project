using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    public class Structure : Entity
    {
        public Structure(int xCoord, int yCoord, int width, int height,PictureBox structureSprite,Camara pov) : base(xCoord, yCoord, width, height , pov)
        {
            this.entitySprite = structureSprite;
        }
    }
}
