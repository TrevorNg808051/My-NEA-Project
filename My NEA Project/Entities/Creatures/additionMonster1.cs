using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project.Entities.Creatures
{
    public class AdditionMonster1 : Creature
    {

        bool inCombat, roaming;
        public AdditionMonster1(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity, Camara pov,World worldMonsterIsIn) : base(xCoord, yCoord, width, height, maximumVerticalVelocity, pov,worldMonsterIsIn)
        {
            this.inCombat = false;
            this.roaming = true;
            this.horrizontalVelocity = 1;
        }


        int roamingCounter = 0;
        bool longTravel = true;
        bool goingRight = false;
        int pause = 0;
        public override Movement Move()
        {
            if (roaming)
            {
                if (worldCreatureIsIn.SquareFinder(this.xCoord, this.yCoord + 1).solid)
                {
                    if (roamingCounter < 300)
                    {
                        if (!longTravel)
                        {
                            if (roamingCounter % 100 == 0)
                            {
                                goingRight = !goingRight;
                                pause = 50;
                            }
                            if (pause > 0)
                            {
                                pause--;
                            }
                            else 
                            {
                                if (goingRight)
                                {
                                    if (this.worldCreatureIsIn.SquareFinder(this.xCoord + this.horrizontalVelocity, this.yCoord).solid)
                                    {
                                        this.currentHorrizontalVelocity = horrizontalVelocity;
                                        this.currentVerticalVelocity = -2;
                                    }
                                    else
                                    {
                                        this.currentVerticalVelocity = 0;
                                        this.currentHorrizontalVelocity = horrizontalVelocity;
                                    }
                                   
                                }
                                else if (!goingRight)
                                {
                                    if (this.worldCreatureIsIn.SquareFinder(this.xCoord - this.horrizontalVelocity, this.yCoord).solid)
                                    {
                                        this.currentHorrizontalVelocity = horrizontalVelocity * -1;
                                        this.currentVerticalVelocity = -2;
                                    }
                                    else
                                    {
                                        this.currentVerticalVelocity = 0;
                                        this.currentHorrizontalVelocity = horrizontalVelocity * -1;
                                    }
                                    
                                }
                            }
                            roamingCounter += horrizontalVelocity;
                        }
                        else if (longTravel)
                        {
                            if (goingRight)
                            {
                                if (this.worldCreatureIsIn.SquareFinder(this.xCoord + this.horrizontalVelocity, this.yCoord).solid)
                                {
                                    this.currentHorrizontalVelocity = horrizontalVelocity;
                                    this.currentVerticalVelocity = -2;
                                }
                                else
                                {

                                    this.currentHorrizontalVelocity = horrizontalVelocity;
                                }

                            }
                            else if (!goingRight)
                            {
                                if (this.worldCreatureIsIn.SquareFinder(this.xCoord - this.horrizontalVelocity, this.yCoord).solid)
                                {
                                    this.currentHorrizontalVelocity = horrizontalVelocity * -1;
                                    this.currentVerticalVelocity = -2;
                                }
                                else
                                {

                                    this.currentHorrizontalVelocity = horrizontalVelocity * -1;
                                }

                            }
                            roamingCounter += horrizontalVelocity;
                        }
                    }
                    else
                    {
                        longTravel = !longTravel;
                        Random ran = new Random();
                        goingRight = ran.Next(1, 3) == 2;
                        roamingCounter = 0;

                       
                    }
                }


                Point playerCoords = worldCreatureIsIn.ReturnPlayerCoords();

                if((Math.Abs(this.xCoord - playerCoords.X) < 12) && (Math.Abs(this.yCoord - playerCoords.Y) < 12))
                {
                    roaming = false;
                    inCombat = true;
                }
            }
            else if (inCombat)
            {
                bool playerIsRightOfMonster = this.xCoord - worldCreatureIsIn.ReturnPlayerCoords().X <= 0;
                if (playerIsRightOfMonster)
                {
                    if (this.worldCreatureIsIn.SquareFinder(this.xCoord + this.horrizontalVelocity, this.yCoord).solid)
                    {
                        this.currentHorrizontalVelocity = horrizontalVelocity;
                        this.currentVerticalVelocity = -2;
                    }
                    else
                    {

                        this.currentHorrizontalVelocity = horrizontalVelocity;
                    }
                }
                else if (!playerIsRightOfMonster)
                {
                    if (this.worldCreatureIsIn.SquareFinder(this.xCoord - this.horrizontalVelocity, this.yCoord).solid)
                    {
                        this.currentHorrizontalVelocity = horrizontalVelocity * -1;
                        this.currentVerticalVelocity = -2;
                    }
                    else
                    {

                        this.currentHorrizontalVelocity = horrizontalVelocity * -1;
                    }

                }

            }

            return new Movement() { horrizontalMovement = this.currentHorrizontalVelocity, verticalMovement = this.currentVerticalVelocity };

        }
    }
}
