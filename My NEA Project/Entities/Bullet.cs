using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal class Bullet : Entity
    {
        private Movement distanceMovedPerFrame;
        private double answerOfTheBullet;
        private int bulletSpeed;
        public Bullet(int xCoord, int yCoord, int width, int height,double destinationX, double destinationY, int speed,Camara pov) : base(xCoord, yCoord, width, height,pov)
        {
            this.bulletSpeed = speed;

            double distanceBetweenStartXAndEndX = destinationX - xCoord;
            double distanceBetweenStartYAndEndY = destinationY - yCoord;

            double StrightLineDistanceBetweenStartAndEnd = Math.Sqrt(((distanceBetweenStartXAndEndX * distanceBetweenStartXAndEndX) + (distanceBetweenStartYAndEndY * distanceBetweenStartYAndEndY)));

            double framesTakenToReachDestination = StrightLineDistanceBetweenStartAndEnd / bulletSpeed;

            distanceMovedPerFrame.horrizontalMovement = distanceBetweenStartXAndEndX / framesTakenToReachDestination;
            distanceMovedPerFrame.verticalMovement = distanceBetweenStartYAndEndY / framesTakenToReachDestination;

        }

        public Movement Travel()
        {
            return distanceMovedPerFrame;
        }
        public void FormAnswer(string equation)
        {

        }
        public void ReturnAnswerOfBullet()
        {

        }
    }
}
