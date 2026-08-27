using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace My_NEA_Project
{
    public class Entity
    {
        protected int xCoord;
        protected int yCoord;
        protected int width;
        protected int height;
        protected PictureBox entitySprite;
        protected Camara cam;

        public Entity(int xCoord,int yCoord, int width, int height,Camara pov)
        {
            this.xCoord = xCoord;
            
            this.width = width;
            this.height = height;
            this.yCoord = yCoord;

            this.entitySprite = new PictureBox();
            entitySprite.BackColor = Color.Green;
            entitySprite.Width = width * pov.ReturnCamScale();
            entitySprite.Height = height * pov.ReturnCamScale();

            cam = pov;
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
            this.entitySprite.Top = (yCoord - cam.ReturnStartingY()) * cam.ReturnCamScale() - ((this.height - 2) * cam.ReturnCamScale());

        }
        public void SetEntityCoords(int xCoord, int yCoord)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
        }
        public void RemoveSprite()
        {
            this.entitySprite.Dispose();
        }
    }
}
