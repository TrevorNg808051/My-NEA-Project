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

        int playerX;
        int playerY;
        public World(Camara playerPov, Form theFormThisWorldExistsIn)
        {
            this.worldMap = worldMap;
            listOfLoadedEntities = new List<Entity>();
            cam = playerPov;

            this.theFormThisWorldExistsIn = theFormThisWorldExistsIn;
        }
        public Material SquareFinder(int x, int y)
        {
            Material air = new Material()
            {
                name = "Air",
                solid = false,
                liquid = false,
                gas = true,
                slipery = false,
                decreaseSpeed = false

            };

            Material dirt = new Material()
            {
                name = "Dirt",
                solid = true,
                liquid = false,
                gas = false,
                slipery = false,
                decreaseSpeed = false

            };


            if (y < 0) return air;
            if (y >= 0) return dirt;
            else return dirt;

        }

        public void AddEntity(Entity thingToAdd)
        {
            listOfLoadedEntities.Add(thingToAdd);
            theFormThisWorldExistsIn.Controls.Add(thingToAdd.ReturnPictureBox());
        }

        public void getWorldMap(Map worldMap)
        {
            this.worldMap = worldMap;
        }
        public void WorldUpdate()
        {
            
            foreach (Entity e in listOfLoadedEntities)
            {
                if (e is Player)
                {
                    Player player = (Player)e;
                    int camHorizontalStartingCoord = player.ReturnXCoord() - ((Screen.PrimaryScreen.Bounds.Width / cam.ReturnCamScale()) / 2);
                    int camVerticalStartingCoord = player.ReturnYCoord() - ((Screen.PrimaryScreen.Bounds.Height / cam.ReturnCamScale()) / 2);
                    cam.SetCamStartingCoords(camHorizontalStartingCoord, camVerticalStartingCoord);

                    playerX = player.ReturnXCoord();
                    playerY = player.ReturnYCoord();
                }

                worldMap.DisplayEntity(e, cam);
                if (e is Creature)
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

                    if (currentCreaturMovement.verticalMovement < 0)
                    {
                        for (int i = 0; i > currentCreaturMovement.verticalMovement; i--)
                        {

                            FinalYValue--;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < currentCreaturMovement.verticalMovement; i++)
                        {
                            FinalYValue++;
                        }
                    }

                    c.SetCreatureCoords(c.ReturnXCoord() + FinalXValue, c.ReturnYCoord() + FinalYValue);

                }
            }
            worldMap.loadingMap(playerX,playerY);
        }
    }
}
