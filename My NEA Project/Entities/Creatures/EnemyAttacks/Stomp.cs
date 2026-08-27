using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Entities.Creatures.EnemyAttacks
{
    internal class Stomp : EnemyAttack
    {
        public Stomp(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity, Camara pov, World worldCreatureIsIn) : base(xCoord, yCoord, width, height, maximumVerticalVelocity, pov, worldCreatureIsIn)
        {
            this.timeToLive = 15;
            this.dangerious = false;

            this.entitySprite.BackColor = Color.Lime;
        }
        public override Movement Move()
        {
            timeToLive--;
            if(timeToLive <= 10)
            {
                entitySprite.BackColor = Color.Orange;
            }
            if(timeToLive <= 5)
            {
                this.dangerious = true;
            }
            return new Movement { horrizontalMovement = 0, verticalMovement = 0 };
        }
    }
}
