using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal class Chunk
    {
        private Bitmap visualMap;
        private Material[,] mapInfo;
        private int chunkX;
        private int chunkY;
        private int chunkSize;
        private int pixelScale = 10;
        public Chunk(int chunkX, int chunkY)
        {
            this.chunkX = chunkX;
            this.chunkY = chunkY;
            this.chunkSize = chunkSize;
        }
        public void LoadDirty()
        {

        }

        public void LoadChunk(int chunkX, int chunkY,World worldChunkIsIn)
        {
            for(int vertical = 0; vertical < chunkSize; vertical++)
            {
                for(int horizontal = 0; horizontal < chunkSize; horizontal++)
                {
                    int worldX = (chunkX * chunkSize) + horizontal;
                    int worldY = (chunkY * chunkSize) + vertical;
                    mapInfo[vertical, horizontal] = worldChunkIsIn.SquareFinder(worldX, worldY);
                }
            }

            using (Graphics g = Graphics.FromImage(visualMap))
            {
                int horrizontalPaintingPos = 0;
                int verticalPaintingPos = 0;

                for(int vertical = chunkSize - 1; vertical >= 0; vertical--)
                {
                    for(int horrizontal = chunkSize - 1; horrizontal >= 0; horrizontal--)
                    {
                        switch (mapInfo[horrizontal,vertical].name)
                        {
                            case "Air":
                                g.FillRectangle(new SolidBrush(Color.Cyan), horrizontalPaintingPos, verticalPaintingPos, pixelScale, pixelScale);
                                break;
                            case "Dirt":
                                g.FillRectangle(new SolidBrush(Color.Brown), horrizontalPaintingPos, verticalPaintingPos, pixelScale, pixelScale);
                                break;


                        }
                    }
                }


                
            }
        }
        public Bitmap ReturnChunk()
        {
            return visualMap;
        }

        public int ReturnChunkY()
        {
            return chunkY;
        }
        public int ReturnChunkX()
        {
            return chunkX;
        }

        public int ReturnChunkSize()
        {
            return chunkSize;
        }
    }
}
