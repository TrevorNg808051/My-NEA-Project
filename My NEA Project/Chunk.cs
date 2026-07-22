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
        private struct PerlinChart
        {
            public int xCoord;
            public int worldHeight;
        }
        private Bitmap visualMap;
        private Material[,] mapInfo;
        private int chunkX;
        private int chunkY;
        private int chunkSize;
        private int pixelScale;
        private PerlinChart[] perlinChart;
        public Chunk(int chunkX, int chunkY, int chunkSize)
        {
            this.chunkX = chunkX;
            this.chunkY = chunkY;
            this.chunkSize = chunkSize;
            this.pixelScale = 50;
            this.mapInfo = new Material[chunkSize, chunkSize];
        }
        public void LoadDirty()
        {

        }

        public void LoadChunk(int chunkX, int chunkY, World worldChunkIsIn)
        {

            perlinChart = new PerlinChart[chunkSize];
            for (int vertical = 0; vertical < chunkSize; vertical++)
            {
                for (int horizontal = 0; horizontal < chunkSize; horizontal++)
                {
                    int worldX = (chunkX * chunkSize) + horizontal;
                    int worldY = (chunkY * chunkSize) + vertical;
                    LoadingPerlin(worldX);
                    mapInfo[horizontal, vertical] = worldChunkIsIn.SquareFinder(worldX, worldY);
                }
            }
            visualMap = new Bitmap(chunkSize * pixelScale, chunkSize * pixelScale);
            using (Graphics g = Graphics.FromImage(visualMap))
            {
                int horrizontalPaintingPos = 0;
                int verticalPaintingPos = 0;

                for (int vertical = chunkSize - 1; vertical >= 0; vertical--)
                {
                    for (int horrizontal = chunkSize - 1; horrizontal >= 0; horrizontal--)
                    {
                        switch (mapInfo[horrizontal, vertical].name)
                        {
                            case "Air":
                                g.FillRectangle(new SolidBrush(Color.Cyan), horrizontalPaintingPos, verticalPaintingPos, pixelScale, pixelScale);
                                break;
                            case "Dirt":
                                g.FillRectangle(new SolidBrush(Color.Brown), horrizontalPaintingPos, verticalPaintingPos, pixelScale, pixelScale);
                                break;


                        }
                        horrizontalPaintingPos += pixelScale;
                    }
                    verticalPaintingPos += pixelScale;
                    horrizontalPaintingPos = 0;
                }



            }
        }

        private void LoadingPerlin(int worldX)
        {
            bool directionOfLeftChunk;
            bool directionOfRightChunk;

            double distanceFromLeft;
            double distanceFromRight;

            double leftDot = 0;
            double rightDot = 0;

            //distanceFromLeft
            double physicalDistanceFromLeft = worldX - chunkX;
            distanceFromLeft = physicalDistanceFromLeft / chunkSize;

            //distanceFromRight
            double physicaleDistanceFromRight = worldX - (chunkX + 1);
            distanceFromRight = physicaleDistanceFromRight / chunkSize;

            Random dircetionOfLeftPointGen = new Random(chunkX);
            Random directionOfRightPointGen = new Random(chunkY);

            directionOfLeftChunk = dircetionOfLeftPointGen.Next(1, 3) == 1;
            directionOfRightChunk = directionOfRightPointGen.Next(1, 3) == 1;

            if (directionOfLeftChunk)
            {
                leftDot = distanceFromLeft;
            }
            else if (!directionOfLeftChunk)
            {
                leftDot = distanceFromLeft * -1;
            }

            if (directionOfRightChunk)
            {
                rightDot = distanceFromRight;
            }
            else if (!directionOfRightChunk)
            {
                rightDot = distanceFromRight * -1;
            }

            double fadedTime = Fade(distanceFromLeft);
            double interpolatedValue = leftDot + (fadedTime * (rightDot - leftDot));
        }

        private double Fade(double time)
        {
            return time * time * time * ((time * ((6 * time) + 15)) + 10);
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
