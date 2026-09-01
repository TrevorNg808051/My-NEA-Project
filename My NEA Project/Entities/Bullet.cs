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
        public Bullet(int xCoord, int yCoord, int width, int height, double destinationX, double destinationY, int speed, Camara pov) : base(xCoord, yCoord, width, height, pov)
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
        public void FormAnswer(List<string> equation)
        {
            List<string> localEquation = equation;

            bool finalAnserIsFormed = false;

            double finalAnswer = 0;
            while (!finalAnserIsFormed)
            {
                if (localEquation.Contains("×") || localEquation.Contains("÷"))
                {
                    if (localEquation.Contains("×"))
                    {
                        int indexOfOperation = localEquation.IndexOf("×");

                        double previousNum = double.Parse(localEquation[indexOfOperation - 1]);
                        double numAfter = double.Parse(localEquation[indexOfOperation + 1]);

                        localEquation[indexOfOperation] = $"{previousNum * numAfter}";

                        localEquation.Remove(localEquation[indexOfOperation - 1]);
                        localEquation.Remove(localEquation[indexOfOperation]);
                    }
                    else if (localEquation.Contains("÷"))
                    {
                        int indexOfOperation = localEquation.IndexOf("÷");

                        double previousNum = double.Parse(localEquation[indexOfOperation - 1]);
                        double numAfter = double.Parse(localEquation[indexOfOperation + 1]);


                        localEquation[indexOfOperation] = $"{previousNum / numAfter}";

                        localEquation.Remove(localEquation[indexOfOperation - 1]);
                        localEquation.Remove(localEquation[indexOfOperation]);
                    }
                }
                else if(localEquation.Contains("-") || localEquation.Contains("+"))
                {
                    if (localEquation.Contains("+"))
                    {
                        int indexOfOperation = localEquation.IndexOf("+");

                        double previousNum = double.Parse(localEquation[indexOfOperation - 1]);
                        double numAfter = double.Parse(localEquation[indexOfOperation + 1]);


                        localEquation[indexOfOperation] = $"{previousNum + numAfter}";

                        localEquation.Remove(localEquation[indexOfOperation - 1]);
                        localEquation.Remove(localEquation[indexOfOperation]);
                    }
                    else if (localEquation.Contains("-"))
                    {
                        int indexOfOperation = localEquation.IndexOf("+");

                        double previousNum = double.Parse(localEquation[indexOfOperation - 1]);
                        double numAfter = double.Parse(localEquation[indexOfOperation + 1]);


                        localEquation[indexOfOperation] = $"{previousNum - numAfter}";

                        localEquation.Remove(localEquation[indexOfOperation - 1]);
                        localEquation.Remove(localEquation[indexOfOperation]);
                    }
                }
                else
                {
                    finalAnswer = double.Parse(localEquation[0]);
                    finalAnserIsFormed = true;
                }
            }
            answerOfTheBullet = finalAnswer;
        }
        public double ReturnAnswerOfBullet()
        {
            return answerOfTheBullet;
        }
    }
}
