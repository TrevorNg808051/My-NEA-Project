using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    internal class World
    {
        private List<Entity> listOfLoadedEntities;
        private Map worldMap;
        private int seed;
        private Camara cam;
        Form theFormThisWorldExistsIn;
        public World(Map worldMap, Camara playerPov,Form theFormThisWorldExistsIn)
        {
            this.worldMap = worldMap;
            listOfLoadedEntities = new List<Entity>();
            cam = playerPov;

            this.theFormThisWorldExistsIn = theFormThisWorldExistsIn;
        }
        public Material SquareFinder(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Entity thingToAdd)
        {
            listOfLoadedEntities.Add(thingToAdd);
            theFormThisWorldExistsIn.Controls.Add(thingToAdd.ReturnPictureBox());
        }

        public void WorldUpdate()
        {
           foreach(Entity c in listOfLoadedEntities)
           {
                if(c is Player)
                {
                    Player player = (Player)c;
                    int camHorizontalStartingCoord = player.ReturnXCoord() - ((Screen.PrimaryScreen.Bounds.Width / cam.ReturnCamScale()) / 2);
                    int camVerticalStartingCoord = player.ReturnYCoord() - ((Screen.PrimaryScreen.Bounds.Height / cam.ReturnCamScale()) / 2);
                    cam.SetCamStartingCoords(camHorizontalStartingCoord,camVerticalStartingCoord);
                }
                worldMap.DisplayEntity(c,cam);
           }
        }
    }
}
