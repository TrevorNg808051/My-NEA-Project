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

        private bool moveRight = false;
        private bool moveLeft = false;
        private bool jump = false;

        public Player(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity) : base(xCoord, yCoord, width, height, maximumVerticalVelocity)
        {
            this.horrizontalSpeed = 5;
            this.maxVerticalSpeed = 5;
        }

        public void SetMovement(bool moveRight, bool moveLeft, bool jump)
        {
            if (moveRight && moveLeft) { moveRight = false; moveLeft = false; }
            this.moveRight = moveRight;
            this.moveLeft = moveLeft;
            this.jump = jump;
        }
        public override Movement Move()
        {
            Movement movementThisFrame = new Movement();

            
            if (moveRight) movementThisFrame.horrizontalMovement = horrizontalSpeed;
            if (moveLeft) movementThisFrame.horrizontalMovement = horrizontalSpeed * -1;
            if (jump) movementThisFrame.verticalMovement = maxVerticalSpeed;

            return movementThisFrame;
        }
    }
}
