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
        private World worldTheMapIsIn;
        public Map(World worldTheMapIsIn)
        {
            renderDistanceX = 3;
            renderDistanceY = 3;
            visableChunks = new Chunk[renderDistanceX, renderDistanceY];

            this.worldTheMapIsIn = worldTheMapIsIn;
        }

        public void DisplayEntity(Entity thingToDisplay, Camara currentPov)
        {
            
            thingToDisplay.MoveSprite(currentPov);

        }

        public void loadingMap(int playerX, int playerY)
        {
            int firstChunkX = ((renderDistanceX / 2) * -1) + playerX;
            int firstChunkY = ((renderDistanceY / 2) * -1) + playerY;

            int lastChunkX = (renderDistanceX / 2);
            int lastChunkY = (renderDistanceY / 2);
            for (int vertical = firstChunkX; vertical <= lastChunkX; vertical++)
            {
                for (int horizontal = firstChunkY; horizontal <= lastChunkY; horizontal++)
                {
                    if (visableChunks[vertical + lastChunkX, horizontal + lastChunkY] == null)
                    {
                        visableChunks[vertical + lastChunkX, horizontal + lastChunkY] = new Chunk(horizontal,vertical);
                    }
                    visableChunks[vertical + lastChunkX, horizontal + lastChunkY].LoadChunk(horizontal,vertical,worldTheMapIsIn);
                }
            }
        }

        public Chunk[,] ReturnVisableMap()
        {
            return visableChunks;
        }

        public int ReturnRenderX()
        {
            return renderDistanceX;
        }
        public int ReturnRenderY()
        {
            return renderDistanceY;
        }
    }
}
