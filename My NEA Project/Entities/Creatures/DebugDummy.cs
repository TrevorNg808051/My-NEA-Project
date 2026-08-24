using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal class DebugDummy : Creature
    {
        public DebugDummy(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity,Camara pov) : base(xCoord, yCoord, width, height, maximumVerticalVelocity,pov)
        {
        }

        public override Movement Move()
        {
            return new Movement() { horrizontalMovement = this.horrizontalVelocity , verticalMovement = this.currentVerticalVelocity};
        }
    }
}
