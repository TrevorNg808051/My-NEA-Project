using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal abstract class Creature : Entity
    {
        protected int currentVerticalVelocity;
        protected int maxVerticalVelocity;
        protected int verticalAcceloration;
        protected int currentHorrizontalVelocity;
        protected int horrizontalVelocity;// movement on the horrizontal plain is designed to have no accelortation
        protected Label equationBar;
        static protected Random equationGen;
        protected int answer;
        protected int jumpingCounter;
        

        // so a little tweak to the original idea the max vertical speed of the creature will always be positive and independent to the gravity.
        // also the creature when jumping would start at the max vertical velocity and decelorate to a stop by gravity so acceloration of the crature will be removed and gravity will be handled by the World class
        public Creature(int xCoord, int yCoord, int width, int height,int maximumVerticalVelocity) : base(xCoord, yCoord, width, height)
        {
            this.maxVerticalVelocity = maximumVerticalVelocity;
        }
        public abstract Movement Move();
        public int ReturnCreatureCurrentHorrizontalVelocity()
        {
            return currentHorrizontalVelocity;
        }
        public int ReturnCreatureCurrentVerticalVelocity()
        {
            return currentVerticalVelocity;
        }
        public void Obstruction(bool obstructedVertically)
        {
            if (obstructedVertically)
            {
                currentVerticalVelocity = 0;
            }
            else
            {
                currentHorrizontalVelocity = 0;
            }
        }
        public void SetCreatureCoords(int xCoord, int yCoord)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
        }
        public string EquationGenerator()
        {
            throw new NotImplementedException();
        }

        public void CreatureSetVelocity(int horrizontalVelocity,int verticalVelocity)
        {
            this.currentHorrizontalVelocity = horrizontalVelocity;
            this.currentVerticalVelocity = verticalVelocity;
        }
    }
 
}
