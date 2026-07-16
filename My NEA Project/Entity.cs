using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    internal class Entity
    {
        protected int xCoord;
        protected int yCoord;
        protected int width;
        protected int height;
        protected PictureBox entitySprite;

        public Entity(int xCoord,int yCoord, int width, int height)
        {

        }
        public int ReturnXCoord()
        {
            return xCoord;
        }
        public int ReturnYCoord()
        {
            return yCoord;
        }
        public int ReturnHeight()
        {
            return height;
        }
        public int returnWidth()
        {
            return width;
        } 

        public void getHit()
        {

        }

    }
}
