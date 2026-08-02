using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project.Entities
{
    public abstract class Placible : Item
    {
        protected int height;
        protected int width;
        protected PictureBox sprite;
        protected Structure theStructurePlaced;
        public Placible(Player itemOwner,int height, int width) : base(itemOwner)
        {
            this.height = height;
            this.width = width;
        }

        public int ReturnWidth()
        {
            return width;
        }

        public int ReturnHeight()
        {
            return height;
        }
        public PictureBox ReturnSprite()
        {
            return sprite;
        }
        public abstract Structure placeStructure(int x, int y,Camara pov);
    }
}
