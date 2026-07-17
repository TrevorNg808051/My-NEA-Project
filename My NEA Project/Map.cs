using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    internal class Map
    {
        private Chunk[,] visableChunks;
        private int renderDistanceX;
        private int renderDistanceY;
        public Map()
        {
            renderDistanceX = 3;
            renderDistanceY = 3;
            visableChunks = new Chunk[renderDistanceX, renderDistanceY];
        }

        public void DisplayEntity(Entity thingToDisplay, Camara currentPov)
        {
            
            thingToDisplay.MoveSprite(currentPov);

        }
    }
}
