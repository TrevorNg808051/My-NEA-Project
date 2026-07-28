using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal class Player : Creature
    {
       
        private bool gunEquipped = false;

        private bool moveRight = false;
        private bool moveLeft = false;
        private bool jump = false;

        public Player(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity) : base(xCoord, yCoord, width, height, maximumVerticalVelocity)
        {
            this.horrizontalVelocity = 1;
            this.maxVerticalVelocity = 5;

            this.verticalAcceloration = 1;

            this.gunEquipped = false;

        }

        public void SetMovement(bool moveRight, bool moveLeft, bool jump)
        {
            if (moveRight && moveLeft) { moveRight = false; moveLeft = false; }
            this.moveRight = moveRight;
            this.moveLeft = moveLeft;

            if (jump)
            {
                this.jump = jump;
                this.jumpingCounter = 3;
                
            }
        }
        public override Movement Move()
        {
            Movement movementThisFrame = new Movement();

            
            if (moveRight) movementThisFrame.horrizontalMovement = horrizontalVelocity;
            if (moveLeft) movementThisFrame.horrizontalMovement = horrizontalVelocity * -1;
            if (jump)
            {
                if (jumpingCounter > 0)
                {
                    this.currentVerticalVelocity -= verticalAcceloration;
                    
                    jumpingCounter--;
                }
                else
                {
                    jump = false;
                }
            }
            movementThisFrame.verticalMovement = currentVerticalVelocity;

            return movementThisFrame;
        }
        public bool GunEqquiped()
        {
            return gunEquipped;
        }

        public void ToggleGun()
        {
            gunEquipped = !gunEquipped;
        }
    }
}
