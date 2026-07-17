using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal class Player : Creature
    {
        private bool gunEquipped;


        public Player(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity) : base(xCoord, yCoord, width, height, maximumVerticalVelocity)
        {
        }

        public void SetMovement(bool moveRight, bool moveLeft, bool jump)
        {

        }
        public override Movement Move()
        {
            throw new NotImplementedException();
        }
    }
}
