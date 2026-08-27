using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Entities.Creatures
{
    internal abstract class EnemyAttack : Creature
    {
        protected int timeToLive;
        protected bool dangerious;
        public EnemyAttack(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity, Camara pov, World worldCreatureIsIn) : base(xCoord, yCoord, width, height, maximumVerticalVelocity, pov, worldCreatureIsIn)
        {
        }

        public override Movement Move()
        {
            throw new NotImplementedException();
        }
        public int ReturnTimeToLive()
        {
            timeToLive--;
            return timeToLive;
        }
        public bool ReturnDangeriousOrNot()
        {
            return dangerious;
        }
    }
}
