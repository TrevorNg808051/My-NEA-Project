using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Entities.Creatures
{
    public class AdditionMonster1 : Creature
    {

        bool incombat, roaming;
        public AdditionMonster1(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity, Camara pov) : base(xCoord, yCoord, width, height, maximumVerticalVelocity, pov)
        {
            this.incombat = false;
            this.roaming = true;
        }

        public override Movement Move()
        {
            if (roaming)
            {

            }
            else if (incombat)
            {

            }

            return new Movement() { horrizontalMovement = this.horrizontalVelocity, verticalMovement = this.currentVerticalVelocity };

        }
    }
}
