using My_NEA_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    public class Player : Creature
    {

        private bool gunEquipped = false;

        private World theWorldPlayerIsIn;
        private bool moveRight = false;
        private bool moveLeft = false;
        private bool jump = false;
        private int gunLv;
        private itemStack[] inventory;



        public Player(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity,World theWorldPlayerIsIn,Camara pov) : base(xCoord, yCoord, width, height, maximumVerticalVelocity,pov)
        {
            this.theWorldPlayerIsIn = theWorldPlayerIsIn;

            this.horrizontalVelocity = 1;
            this.maxVerticalVelocity = 5;
            this.gunLv = 1;
            this.verticalAcceloration = 1;

            this.gunEquipped = false ;
            inventory = new itemStack[50];
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

        public void ReciveItem(Item itemRecived, int amountRecived)
        {
            int index = 0;
            foreach (itemStack iS in inventory)
            {
                if (iS.item == null)
                {
                    break;
                }
                else if (iS.item == itemRecived)
                {
                    break;
                }
                index++;
            }
            if (!(index > 50))
            {
                if (inventory[index].item == null)
                {
                    inventory[index] = new itemStack() { item = itemRecived, stackCount = 0 };
                    inventory[index].stackCount += amountRecived;
                }
                else if (inventory[index].item == itemRecived)
                {
                    inventory[index].stackCount += amountRecived;
                }
            }
        }
        public itemStack[] ReturnInventory()
        {
            return inventory;
        }
        public void PlaceStructure(Placible structureToPlace)
        {
            theWorldPlayerIsIn.PreviewSturcturePlacement(structureToPlace);
        }
        public void Interact()
        {
            theWorldPlayerIsIn.PlayerInteraction(this);
        }
        public int ReturnGunLv()
        {
            return gunLv;
        }
        public void UpgradGun()
        {
            gunLv++;
        }
    }
}
