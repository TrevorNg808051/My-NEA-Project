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
            renderDistanceX = 5;
            renderDistanceY = 5;
            visableChunks = new Chunk[renderDistanceX, renderDistanceY];

            this.worldTheMapIsIn = worldTheMapIsIn;
        }

        public void DisplayEntity(Entity thingToDisplay, Camara currentPov)
        {
            
            thingToDisplay.MoveSprite(currentPov);

        }

        int playerChunkXCoordLastFrame = int.MaxValue;
        int playerChunkYCoordLastFrame = int.MaxValue;
        public void loadingMap(int playerX, int playerY)
        {
            int firstChunkX = ((renderDistanceX / 2) * -1) + (int)Math.Floor((double)playerX/chunkSize);
            int firstChunkY = ((renderDistanceY / 2) * -1) + (int)Math.Floor((double)playerY / chunkSize);

            int lastChunkX = (renderDistanceX / 2) + (int)Math.Floor((double)playerX / chunkSize);
            int lastChunkY = (renderDistanceY / 2) + (int)Math.Floor((double)playerY / chunkSize);

            if (playerChunkXCoordLastFrame == (int)Math.Floor((double)playerX / chunkSize) && playerChunkYCoordLastFrame == (int)Math.Floor((double)playerY / chunkSize)) return;
            else
            {
                playerChunkXCoordLastFrame = (int)Math.Floor((double)playerX / chunkSize);
                playerChunkYCoordLastFrame = (int)Math.Floor((double)playerY / chunkSize);

                visableChunks = new Chunk[renderDistanceX, renderDistanceY];
                int xIndex = 0;
                int yIndex = 0;

                for (int vertical = firstChunkY; vertical <= lastChunkY; vertical++)
                {
                    for (int horizontal = firstChunkX; horizontal <= lastChunkX; horizontal++)
                    {
                        if (visableChunks[horizontal + (horizontal * -1) + xIndex, vertical + (vertical * -1) + yIndex] == null)
                        {
                            visableChunks[horizontal + (horizontal * -1) + xIndex, vertical + (vertical * -1) + yIndex] = new Chunk(horizontal, vertical, chunkSize);
                        }
                        visableChunks[horizontal + (horizontal * -1) + xIndex, vertical + (vertical * -1) + yIndex].LoadChunk(horizontal, vertical, worldTheMapIsIn);
                        xIndex++;
                    }
                    xIndex = 0;
                    yIndex++;
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
