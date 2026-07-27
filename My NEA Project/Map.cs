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
        public void LoadingMap(int playerX, int playerY)
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

                Chunk[,] newChunks = new Chunk[renderDistanceX, renderDistanceY];
                
                int xIndex = 0;
                int yIndex = 0;

                for (int vertical = firstChunkY; vertical <= lastChunkY; vertical++)
                {
                    for (int horizontal = firstChunkX; horizontal <= lastChunkX; horizontal++)
                    {
                        int horizontalSpot = horizontal + (horizontal * -1) + xIndex;
                        int verticalSpot = vertical + (vertical * -1) + yIndex;

                        int currentChunkX;
                        int currentChunkY;

                        if (visableChunks[horizontalSpot,verticalSpot] != null)
                        {
                            currentChunkX = visableChunks[horizontalSpot, verticalSpot].ReturnChunkX();
                            currentChunkY = visableChunks[horizontalSpot, verticalSpot].ReturnChunkY();
                        }
                        else
                        {
                            currentChunkX = horizontal;
                            currentChunkY = vertical;

                        }

                        int playerChunkX = (int)Math.Floor((double)(worldTheMapIsIn.ReturnPlayerCoords().X / chunkSize));
                        int playerChunkY = (int)Math.Floor((double)(worldTheMapIsIn.ReturnPlayerCoords().Y / chunkSize));

                        if (currentChunkX == playerChunkX + horizontal && currentChunkY == playerChunkY + vertical && visableChunks[horizontalSpot,verticalSpot] != null)
                        {
                            newChunks[horizontalSpot, verticalSpot] = visableChunks[horizontalSpot,verticalSpot];
                        }
                        else
                        {
                            newChunks[horizontalSpot, verticalSpot] = new Chunk(horizontal,vertical,chunkSize);
                            newChunks[horizontalSpot, verticalSpot].LoadChunk(horizontal, vertical, worldTheMapIsIn);
                            
                        }
                        
                        xIndex++;
                    }
                    xIndex = 0;
                    yIndex++;
                }
                DeloadingChunks(visableChunks);
                visableChunks = newChunks;
            }
        }

        private void DeloadingChunks(Chunk[,] visableChunks)
        {
            
            for(int y = 0; y < renderDistanceX; y++)
            {
                for(int x = 0; x < renderDistanceY; x++)
                {
                    if (visableChunks[x, y] == null) continue;
                    int chunkX = visableChunks[x, y].ReturnChunkX();
                    int chunkY = visableChunks[x, y].ReturnChunkY();

                    int renderX = renderDistanceX / 2;
                    int renderY = renderDistanceY / 2;

                    int playerChunkX = (int)Math.Floor((double)(worldTheMapIsIn.ReturnPlayerCoords().X / chunkSize));
                    int playerChunkY = (int)Math.Floor((double)(worldTheMapIsIn.ReturnPlayerCoords().Y / chunkSize));

                    if (chunkX > playerChunkX + renderX || chunkX < playerChunkX - renderX || chunkY < playerChunkY - renderY || chunkY > playerChunkY + renderY)
                    {
                          visableChunks[x, y].ReturnChunk().Dispose();
                    }
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

        public int ReturnChunkSize()
        {
            return chunkSize;
        }
    }
}
