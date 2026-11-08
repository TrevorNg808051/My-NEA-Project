using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    public class UpgradeStationBuilding : Structure
    {
        public UpgradeStationBuilding(int xCoord, int yCoord, PictureBox structureSprite, Camara pov,World theworldStructureIsIn, int width = 3, int height = 1) : base(xCoord, yCoord, width, height, structureSprite, pov,theworldStructureIsIn)
        {
            
        }
        public override void Interaction(Player p)
        {
            p.UpgradGun();
        }
    }
}
