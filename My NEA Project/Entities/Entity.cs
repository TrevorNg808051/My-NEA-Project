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
        public int ReturnWidth()
        {
            return width;
        } 

        public void GetHit()
        {

        }
        public void MoveSprite(Camara cam)
        {
            this.entitySprite.Left = (xCoord - cam.ReturnCamX()) * cam.ReturnCamScale();
            this.entitySprite.Top = (yCoord - cam.ReturnCamY()) * cam.ReturnCamScale();
        }
    }
}
