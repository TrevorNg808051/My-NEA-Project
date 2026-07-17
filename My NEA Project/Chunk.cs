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

        public Chunk(int chunkX, int chunkY, int chunkSize)
        {
            this.chunkX = chunkX;
            this.chunkY = chunkY;
            this.chunkSize = chunkSize;
        }
        public void LoadDirty()
        {

        }

        public void LoadChunk()
        {

        }
        public Bitmap ReturnChunk()
        {
            return visualMap;
        }
    }
}
