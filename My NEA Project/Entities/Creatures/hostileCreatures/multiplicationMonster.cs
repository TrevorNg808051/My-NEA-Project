using My_NEA_Project.Entities.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project
{
    internal class multiplicationMonster : hostileMonster
    {
        public multiplicationMonster(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity, Camara pov, World worldMonsterIsIn) : base(xCoord, yCoord, width, height, maximumVerticalVelocity, pov, worldMonsterIsIn)
        {
            

        }

        public override string EquationGenerator()
        {
            this.answer = equationGen.Next(20, 121);
            int numOfVariables = equationGen.Next(2, 4);
            int valueUntilAnswer = this.answer;

            string finalEquation = "";
            for (int i = 1; i <= numOfVariables - 1; i++)
            {
                int numToAddToEquation = equationGen.Next(1, (valueUntilAnswer / (numOfVariables - i)));


                finalEquation += numToAddToEquation + " * ";

                valueUntilAnswer = valueUntilAnswer / numToAddToEquation;
            }
            finalEquation += valueUntilAnswer;


            return finalEquation;
        }
    }
}
