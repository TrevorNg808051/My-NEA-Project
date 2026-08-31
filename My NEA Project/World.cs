using My_NEA_Project.Entities;
using My_NEA_Project.Entities.Creatures;
using My_NEA_Project.Entities.Creatures.EnemyAttacks;
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
        Form1 theFormThisWorldExistsIn;

        int playerX;
        int playerY;
        public World(Camara playerPov, Form1 theFormThisWorldExistsIn)
        {
            listOfLoadedEntities = new List<Entity>();
            cam = playerPov;

            this.theFormThisWorldExistsIn = theFormThisWorldExistsIn;
            this.seed = 4546787;
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

            int octives = 6;

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

            if(thingToAdd is Creature && !(thingToAdd is Player) && !(thingToAdd is EnemyAttack))
            {
                Creature c = (Creature)thingToAdd;
                theFormThisWorldExistsIn.Controls.Add(c.ReturnEquaationBar());
            }
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
            for(int interger = 0; interger <listOfLoadedEntities.Count;interger++)
            {
                Entity e = listOfLoadedEntities[interger];
                if (e is Player)
                {
                    Player player = (Player)e;
                    int camHorizontalStartingCoord = player.ReturnXCoord() - ((Screen.PrimaryScreen.Bounds.Width / cam.ReturnCamScale()) / 2);
                    int camVerticalStartingCoord = (player.ReturnYCoord()) - ((Screen.PrimaryScreen.Bounds.Height / cam.ReturnCamScale()) / 2);
                    cam.SetCamStartingCoords(camHorizontalStartingCoord, camVerticalStartingCoord);

                    playerX = player.ReturnXCoord();
                    playerY = player.ReturnYCoord();
                }

                if (e is Creature)
                {
                    if(e is EnemyAttack)
                    {
                        EnemyAttack attack = (EnemyAttack)e;
                        int attackTimeToLive = attack.ReturnTimeToLive();
                        if(attackTimeToLive <= 0)
                        {
                            
                            listOfLoadedEntities.Remove(attack);
                            attack.RemoveSprite();
                        }

                        foreach (Entity p in listOfLoadedEntities)
                        {
                            if (p is Player)
                            {
                                if (attack.ReturnDangeriousOrNot())
                                {
                                    if (attack.ReturnPictureBox().Bounds.IntersectsWith(p.ReturnPictureBox().Bounds))
                                    {
                                        p.GetHit();
                                        listOfLoadedEntities.Remove(attack);
                                        attack.RemoveSprite();
                                    }
                                }
                            }
                        
                        }
                    }
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
                            int x = e.ReturnXCoord();
                            int y = e.ReturnYCoord() + i + 1;
                            if (SquareFinder(x, y).solid)
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

                    foreach (Entity entity in listOfLoadedEntities)
                    {
                        if (entity is Creature)
                        {
                            if (bullet.ReturnPictureBox().Bounds.IntersectsWith(entity.ReturnPictureBox().Bounds))
                            {
                                bullet.FormAnswer(theFormThisWorldExistsIn.GetEquation());
                                bullet.ReturnAnswerOfBullet();
                            }
                        }
                    }

                }
                else
                {
                    GravatationalPull(e);
                }

                worldMap.DisplayEntity(e, cam);
            }
            if (structureSprite != null)
            {
                bool placible = false;

                int onScreenX = (int)Math.Floor((double)theFormThisWorldExistsIn.ReturnMousePos().X / cam.ReturnCamScale());
                int onScreenY = (int)Math.Floor((double)theFormThisWorldExistsIn.ReturnMousePos().Y / cam.ReturnCamScale());
                Point displayLocation = new Point(onScreenX * cam.ReturnCamScale(), onScreenY * cam.ReturnCamScale());
                structureSprite.Location = displayLocation;

                structureX = (structureSprite.Left / cam.ReturnCamScale()) + cam.ReturnStaringX();
                structureY = (structureSprite.Top / cam.ReturnCamScale()) + cam.ReturnStartingY();

                for (int i = 0; i < structureBeingPlaced.ReturnWidth(); i++)
                {
                    if (!SquareFinder(structureX + i, structureY + 1).solid)
                    {
                        placible = false;
                        break;
                    }
                    placible = true;
                }
                if (placible)
                {
                    structureSprite.BackColor = Color.LightGreen;
                }
                else if (!placible)
                {
                    structureSprite.BackColor = Color.Red;
                }
            }
            SpawiningEntities();
            await mapGen;
        }


        public void GravatationalPull(Entity e)
        {
            if (e is Creature && !(e is EnemyAttack))
            {
                Creature c = (Creature)e;
                int preciceGravity = (int)c.ReturnCreatureCurrentVerticalVelocity() + 1;

                c.CreatureSetVelocity(c.ReturnCreatureCurrentHorrizontalVelocity(), preciceGravity);

                int creatureX = c.ReturnXCoord();
                int creatureY = c.ReturnYCoord();

               
                if (e is AdditionMonster1)
                {
                    Material m = SquareFinder(creatureX, creatureY + 1);
                    if (SquareFinder(creatureX, creatureY + 1).solid) c.CreatureSetVelocity(c.ReturnCreatureCurrentHorrizontalVelocity(), 0);
                }
                else if(e is Player)
                {
                    Material m = SquareFinder(creatureX, creatureY + 1);
                    if (SquareFinder(creatureX, creatureY + 1 ).solid) c.CreatureSetVelocity(c.ReturnCreatureCurrentHorrizontalVelocity(), 0);
                }
                else if (!(e is AdditionMonster1))
                {
                    if (SquareFinder(creatureX, creatureY + 1).solid) c.CreatureSetVelocity(c.ReturnCreatureCurrentHorrizontalVelocity(), 0);
                }
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

            Random dircetionOfLeftPointGen = new Random((((worldX + seed - (worldX % chunkSize)) / chunkSize) * octives));
            Random directionOfRightPointGen = new Random(((((worldX + seed - (worldX % chunkSize)) / chunkSize) * octives) + 1));

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

        Placible structureBeingPlaced;
        PictureBox structureSprite;
        int structureX;
        int structureY;

        public void PreviewSturcturePlacement(Placible structureToPlace)
        {
            structureBeingPlaced = structureToPlace;
            structureSprite = structureToPlace.ReturnSprite();

            structureSprite.Size = new Size(structureToPlace.ReturnWidth() * cam.ReturnCamScale(), structureToPlace.ReturnHeight() * cam.ReturnCamScale());
            structureSprite.BackColor = Color.Red;
            structureSprite.Click += new System.EventHandler(PlacementConfirmed);
            theFormThisWorldExistsIn.Controls.Add(structureSprite);


        }
        private void PlacementConfirmed(object sender, EventArgs e)
        {
            if (structureBeingPlaced != null)
            {
                for (int i = 0; i < structureBeingPlaced.ReturnWidth(); i++)
                {
                    if (!SquareFinder(structureX + i, structureY + 1).solid)
                    {
                        return;
                    }
                }
                AddEntity(structureBeingPlaced.placeStructure(structureX, structureY, cam));
                structureBeingPlaced = null;
                structureSprite = null;
            }
        }

        public void PlayerInteraction(Player player)
        {
            foreach (Entity e in listOfLoadedEntities)
            {
                if (player.ReturnPictureBox().Bounds.IntersectsWith(e.ReturnPictureBox().Bounds))
                {
                    if(e is Structure)
                    {
                        Structure structure = (Structure)e;
                        structure.Interaction(player);
                    }
                }
            }
        }

        public void SpawiningEntities()
        {
            Player thePlayer = null;
            AdditionMonster1 hostileCreature = null;

            foreach(Entity e in listOfLoadedEntities)
            {
                if(e is Player)
                {
                    thePlayer = (Player)e;
                }
                else if(e is AdditionMonster1)
                {
                    if (hostileCreature == null)
                    {
                        hostileCreature = (AdditionMonster1)e;
                    }
                    else if( hostileCreature != null)
                    {
                        listOfLoadedEntities.Remove(e);
                        break;
                    }
                }
            }

            if( hostileCreature == null)
            {
                Random ran = new Random();
                AdditionMonster1 newCreature;

                bool rightOfPlayer = ran.Next(1, 3) == 2;
                int playerX = thePlayer.ReturnXCoord();
                if (rightOfPlayer)
                {
                    newCreature = new AdditionMonster1(thePlayer.ReturnXCoord() + ran.Next(100, 300), -15, 3, 5, 10, cam, this);                   
                }
                else
                {
                    newCreature = new AdditionMonster1(thePlayer.ReturnXCoord() - ran.Next(100, 300), -15, 3, 5, 10, cam, this);
                }
                AddEntity(newCreature);
                MessageBox.Show($"the creature has been spawned at {newCreature.ReturnXCoord()}, {newCreature.ReturnYCoord()}");
                //spawn a creature;
            }

            int hostilX = hostileCreature.ReturnXCoord();
            if(Math.Abs(playerX - hostilX) > 500)
            {
                listOfLoadedEntities.Remove(hostileCreature);
                hostileCreature.RemoveSprite();
                MessageBox.Show("creature has been removed");
            }
        }
    }
}
