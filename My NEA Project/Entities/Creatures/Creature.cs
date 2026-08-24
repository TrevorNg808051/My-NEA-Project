using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    public abstract class Creature : Entity
    {
        protected double currentVerticalVelocity;
        protected int maxVerticalVelocity;
        protected int verticalAcceloration;
        protected int currentHorrizontalVelocity;
        protected int horrizontalVelocity;
        protected Label equationBar;
        static protected Random equationGen;
        protected int answer;
        protected int jumpingCounter;
        protected World worldCreatureIsIn;
        protected bool onTheGround;

       
        public Creature(int xCoord, int yCoord, int width, int height,int maximumVerticalVelocity,Camara pov,World worldCreatureIsIn) : base(xCoord, yCoord, width, height,pov)
        {
            this.maxVerticalVelocity = maximumVerticalVelocity;
            this.worldCreatureIsIn = worldCreatureIsIn;
            
        }
        public abstract Movement Move();
        public int ReturnCreatureCurrentHorrizontalVelocity()
        {
            return currentHorrizontalVelocity;
        }
        public double ReturnCreatureCurrentVerticalVelocity()
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

        public string EquationGenerator()
        {
            throw new NotImplementedException();
        }

        public void CreatureSetVelocity(int horrizontalVelocity,double verticalVelocity)
        {
            this.currentHorrizontalVelocity = horrizontalVelocity;
            this.currentVerticalVelocity = verticalVelocity;
        }
    }
 
}
