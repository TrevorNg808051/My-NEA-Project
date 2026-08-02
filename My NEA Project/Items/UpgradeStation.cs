using My_NEA_Project.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    internal class UpgradeStation : Placible
    {

        public UpgradeStation(Player itemOwner) : base(itemOwner,1,3)
        {
            this.nameOfItem = "UpgradeStation";
            usable = true;
            sprite = new System.Windows.Forms.PictureBox();
            
        }

        public override Structure placeStructure(int x, int y,Camara pov)
        {
            sprite.Width = width * pov.ReturnCamScale();
            sprite.Height = height * pov.ReturnCamScale();

            sprite.BackColor = Color.AliceBlue;
            return new UpgradeStationBuilding(x,y,3,1,sprite,pov);
        }

        public override void Use()
        {
            base.Use();
            ownerOfItem.PlaceStructure(this);
        }
    }
}
