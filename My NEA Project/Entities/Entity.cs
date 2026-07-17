using System;
using System.Collections.Generic;
using System.Drawing;
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
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.width = width;
            this.height = height;

            this.entitySprite = new PictureBox();
            entitySprite.BackColor = Color.Green;
            entitySprite.Width = width;
            entitySprite.Height = height;
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
        public PictureBox ReturnPictureBox()
        {
            return entitySprite;
        }
        public void MoveSprite(Camara cam)
        {
            this.entitySprite.Left = (xCoord - cam.ReturnStaringX()) * cam.ReturnCamScale();
            this.entitySprite.Top = (yCoord - cam.ReturnStartingY()) * cam.ReturnCamScale();
        }
    }
}
