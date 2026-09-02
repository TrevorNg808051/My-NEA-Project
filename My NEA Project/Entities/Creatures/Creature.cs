using My_NEA_Project.Entities.Creatures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
        static protected Random equationGen = new Random();
        protected int answer;
        protected int jumpingCounter;
        protected World worldCreatureIsIn;
        protected bool onTheGround;
        protected int health;
        protected int maxHealth;

       
        public Creature(int xCoord, int yCoord, int width, int height,int maximumVerticalVelocity,Camara pov,World worldCreatureIsIn) : base(xCoord, yCoord, width, height,pov)
        {
            this.maxVerticalVelocity = maximumVerticalVelocity;
            this.worldCreatureIsIn = worldCreatureIsIn;

           
            if(!(this is Player))
            {
                answer = equationGen.Next(10, 100);
                equationBar = new Label();
                equationBar.Text = EquationGenerator();
                equationBar.Location = new Point(this.entitySprite.Location.X,this.entitySprite.Location.Y + 10);


            }
            
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

        public abstract string EquationGenerator();


        public void CreatureSetVelocity(int horrizontalVelocity,double verticalVelocity)
        {
            this.currentHorrizontalVelocity = horrizontalVelocity;
            this.currentVerticalVelocity = verticalVelocity;
        }
        public int ReturnCurrentHealth()
        {
            return health;
        }
        public int ReturnMaxHealth()
        {
            return maxHealth;
        }

        public Label ReturnEquaationBar()
        {
            return equationBar;
        }

        public override void MoveSprite(Camara cam)
        {
            base.MoveSprite(cam);
            if (!(this is Player) && !(this is EnemyAttack))
            {
                this.equationBar.Location = new Point(this.entitySprite.Location.X, this.entitySprite.Top - 75);
            }
        }
        public override void RemoveSprite()
        {
            base.RemoveSprite();
            this.equationBar.Dispose();
        }
    }
 
}
