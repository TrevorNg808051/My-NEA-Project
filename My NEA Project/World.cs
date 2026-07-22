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
            if (y > -1) return dirt;
            else return air;

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
        double bulletProgressionX = 0;
        double bulletProgressionY = 0;
        public void WorldUpdate()
        {
            
            foreach (Entity e in listOfLoadedEntities)
            {
                if (e is Player)
                {
                    Player player = (Player)e;
                    int camHorizontalStartingCoord = player.ReturnXCoord() - ((Screen.PrimaryScreen.Bounds.Width / cam.ReturnCamScale()) / 2);
                    int camVerticalStartingCoord = (player.ReturnYCoord()) - ((Screen.PrimaryScreen.Bounds.Height / cam.ReturnCamScale()) / 2);
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
                            if (SquareFinder(e.ReturnXCoord() + i - 1,e.ReturnYCoord()).solid)
                            {
                                break;
                            }
                            FinalXValue--;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < currentCreaturMovement.horrizontalMovement; i++)
                        {
                            if (SquareFinder(e.ReturnXCoord() + i + 1, e.ReturnYCoord()).solid)
                            {
                                break;
                            }
                            FinalXValue++;
                        }
                    }

                    if (currentCreaturMovement.verticalMovement < 0)
                    {
                        for (int i = 0; i > currentCreaturMovement.verticalMovement; i--)
                        {
                            if (SquareFinder(e.ReturnXCoord() , e.ReturnYCoord() + i - 1).solid)
                            {
                                break;
                            }
                            FinalYValue--;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < currentCreaturMovement.verticalMovement; i++)
                        {
                            if (SquareFinder(e.ReturnXCoord(), e.ReturnYCoord() + i + 1).solid)
                            {
                                break;
                            }
                            FinalYValue++;
                        }
                    }

                    c.SetEntityCoords(c.ReturnXCoord() + FinalXValue, c.ReturnYCoord() + FinalYValue);
                    
                }
                if(e is Bullet)
                {
                    Bullet bullet = (Bullet)e;
                  
                    if (bulletProgressionX >= 1 || bulletProgressionX <= -1 || bulletProgressionY >= 1 || bulletProgressionY <= -1)
                    {
                        int xIncrease = 0;
                        int yIncrease = 0;

                        if (bulletProgressionX >= 1 || bulletProgressionX <= -1)
                        {
                            xIncrease = (int)Math.Truncate(bulletProgressionX);

                            bulletProgressionX -= Math.Truncate(bulletProgressionX);
                        }
                        if (bulletProgressionY >= 1 || bulletProgressionY <= -1)
                        {
                            yIncrease = (int)Math.Truncate(bulletProgressionY);
                            bulletProgressionY -= Math.Truncate(bulletProgressionY);
                        }

                        bullet.SetEntityCoords(bullet.ReturnXCoord() + xIncrease, bullet.ReturnYCoord() + yIncrease);
                    }

                    bulletProgressionX += bullet.Travel().horrizontalMovement;
                    bulletProgressionY += bullet.Travel().verticalMovement;
                }
                else
                {
                    GravatationalPull(e);
                }

                
            }
            worldMap.loadingMap(playerX,playerY);
        }
        public void GravatationalPull(Entity e)
        {
            if (e is Creature)
            {
                Creature c = (Creature)e;
                c.CreatureSetVelocity(c.ReturnCreatureCurrentHorrizontalVelocity(), c.ReturnCreatureCurrentVerticalVelocity() + 1);
                if (SquareFinder(c.ReturnXCoord(), c.ReturnYCoord() + 1).solid) c.CreatureSetVelocity(c.ReturnCreatureCurrentHorrizontalVelocity(), 0);
            }
            if (SquareFinder(e.ReturnXCoord(), e.ReturnYCoord() + 1).solid) return;
            
        }
    }
}
