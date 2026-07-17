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
           foreach(Entity e in listOfLoadedEntities)
           {
                if(e is Player)
                {
                    Player player = (Player)e;
                    int camHorizontalStartingCoord = player.ReturnXCoord() - ((Screen.PrimaryScreen.Bounds.Width / cam.ReturnCamScale()) / 2);
                    int camVerticalStartingCoord = player.ReturnYCoord() - ((Screen.PrimaryScreen.Bounds.Height / cam.ReturnCamScale()) / 2);
                    cam.SetCamStartingCoords(camHorizontalStartingCoord,camVerticalStartingCoord);
                }
                worldMap.DisplayEntity(e,cam);
                if(e is Creature)
                {
                    Creature c = (Creature)e;

                    Movement currentCreaturMovement = c.Move();

                    int FinalXValue = 0;
                    int FinalYValue = 0;

                    if (currentCreaturMovement.horrizontalMovement < 0)
                    {
                        for (int i = 0; i > currentCreaturMovement.horrizontalMovement; i--)
                        {
                            
                            FinalXValue--;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < currentCreaturMovement.horrizontalMovement; i++)
                        {
                            FinalXValue++;
                        }
                    }

                    c.SetCreatureCoords(c.ReturnXCoord() + FinalXValue, c.ReturnYCoord() + FinalYValue);

                }
            }
        }
    }
}
