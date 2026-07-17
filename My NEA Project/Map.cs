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
        private int chunkSize;
        public Map(World worldTheMapIsIn, int chunkSize)
        {
            this.chunkSize = chunkSize;
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
            int firstChunkX = ((renderDistanceX / 2) * -1) + (int)Math.Floor((double)playerX/chunkSize);
            int firstChunkY = ((renderDistanceY / 2) * -1) + (int)Math.Floor((double)playerY / chunkSize);

            int lastChunkX = (renderDistanceX / 2) + (int)Math.Floor((double)playerX / chunkSize);
            int lastChunkY = (renderDistanceY / 2) + (int)Math.Floor((double)playerY / chunkSize);

            int xIndex = 0;
            int yIndex = 0;
            for (int vertical = firstChunkX; vertical <= lastChunkX; vertical++)
            {
                
                for (int horizontal = firstChunkY; horizontal <= lastChunkY; horizontal++)
                {
                    if (visableChunks[vertical + (vertical * -1) + yIndex, horizontal + (horizontal * -1) + xIndex] == null)
                    {
                        visableChunks[vertical + (vertical * -1) + yIndex, horizontal + (horizontal * -1) + xIndex] = new Chunk(horizontal,vertical,chunkSize);
                    }
                    visableChunks[vertical + (vertical * -1) + yIndex, horizontal + (horizontal * -1) + xIndex].LoadChunk(horizontal,vertical,worldTheMapIsIn);
                    xIndex++;
                }
                xIndex = 0;
                yIndex++;
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
