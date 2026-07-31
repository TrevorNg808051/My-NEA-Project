using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace My_NEA_Project
{
    public class World
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
            this.seed = 849;
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

            Material grass = new Material()
            {
                name = "Grass",
                solid = true,
                liquid = false,
                gas = false,
                slipery = false,
                decreaseSpeed = false
            };

            int octives = 4;

            int worldHeight = (int)Math.Truncate(LoadingPerlin(x, octives) * 10);
            if (y < worldHeight) return air;
            if (y > worldHeight) return dirt;
            if (y == worldHeight) return grass;
            else return air;

        }

        public void AddEntity(Entity thingToAdd)
        {
            listOfLoadedEntities.Add(thingToAdd);
            theFormThisWorldExistsIn.Controls.Add(thingToAdd.ReturnPictureBox());
        }

        public void GetWorldMap(Map worldMap)
        {
            this.worldMap = worldMap;
        }
        double bulletProgressionX = 0;
        double bulletProgressionY = 0;
        public async Task WorldUpdate()
        {
            Task mapGen = new Task(() => worldMap.LoadingMap(playerX, playerY));
            if (mapGen.Status != TaskStatus.Running)
            {
                mapGen.Start();
            }
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
                            if (SquareFinder(e.ReturnXCoord() + i - 1, e.ReturnYCoord()).solid)
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
                            if (SquareFinder(e.ReturnXCoord(), e.ReturnYCoord() + i - 1).solid)
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
                if (e is Bullet)
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
            await mapGen;
        }
        public void GravatationalPull(Entity e)
        {
            if (e is Creature)
            {
                Creature c = (Creature)e;
                c.CreatureSetVelocity(c.ReturnCreatureCurrentHorrizontalVelocity(), c.ReturnCreatureCurrentVerticalVelocity() + 1);
                if (SquareFinder(c.ReturnXCoord(), c.ReturnYCoord() + 1).solid) c.CreatureSetVelocity(c.ReturnCreatureCurrentHorrizontalVelocity(), 0);
            }


        }
        private double LoadingPerlin(int worldX, int octives)
        {
            int chunkSize = worldMap.ReturnChunkSize();
            bool directionOfLeftChunk;
            bool directionOfRightChunk;

            double distanceFromLeft;
            double distanceFromRight;

            double leftDot = 0;
            double rightDot = 0;

            {
                //distanceFromLeft
                double physicalDistanceFromLeft = (Math.Abs(worldX) % chunkSize);
                distanceFromLeft = (physicalDistanceFromLeft / chunkSize);

                //distanceFromRight
                double physicaleDistanceFromRight = physicalDistanceFromLeft - chunkSize;
                distanceFromRight = (physicaleDistanceFromRight / chunkSize);

            }

            Random dircetionOfLeftPointGen = new Random((((worldX + seed - (worldX % chunkSize)) / chunkSize) * octives) );
            Random directionOfRightPointGen = new Random(((((worldX + seed - (worldX % chunkSize)) / chunkSize) * octives) + 1) );

            directionOfLeftChunk = dircetionOfLeftPointGen.Next(1, 1000) >= 500;
            directionOfRightChunk = directionOfRightPointGen.Next(1, 1000) <= 500;

            if (directionOfLeftChunk)
            {
                leftDot = distanceFromLeft;
            }
            else if (!directionOfLeftChunk)
            {
                leftDot = distanceFromLeft * -1;
            }

            if (directionOfRightChunk)
            {
                rightDot = distanceFromRight;
            }
            else if (!directionOfRightChunk)
            {
                rightDot = distanceFromRight * -1;
            }

            double fadedTime = Fade(distanceFromLeft);
            double interpolatedValue;
            if (octives > 0)
            {
                interpolatedValue = leftDot + (fadedTime * (rightDot - leftDot)) + LoadingPerlin(worldX, octives - 1);
            }
            else
            {
                interpolatedValue = leftDot + (fadedTime * (rightDot - leftDot));
            }
            return interpolatedValue;

        }

        private double Fade(double time)
        {
            return time * time * time * ((time * ((6 * time) - 15)) + 10);
        }

        public Point ReturnPlayerCoords()
        {
            return new Point() { X = playerX, Y = playerY };
        }
    }
}
