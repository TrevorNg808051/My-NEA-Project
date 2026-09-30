using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_NEA_Project.Entities.Creatures
{
    internal class subtractionMonster : hostileMonster
    {
        public subtractionMonster(int xCoord, int yCoord, int width, int height, int maximumVerticalVelocity, Camara pov, World worldMonsterIsIn) : base(xCoord, yCoord, width, height, maximumVerticalVelocity, pov, worldMonsterIsIn)
        {

        }

        public override string EquationGenerator()
        {
            int numOfVariables = equationGen.Next(2,4);
            int valueUntilAnswer = equationGen.Next(5,20);
            int valueToAdd = this.answer + valueUntilAnswer;

            string finalEquation = "";
            finalEquation += valueToAdd + " - ";
            for (int i = 1; i <= numOfVariables - 2; i++)
            {
                valueToAdd = equationGen.Next(1, (valueUntilAnswer / (numOfVariables - i)));

                finalEquation += valueToAdd;
                finalEquation += " - ";
                valueUntilAnswer -= valueToAdd;
            }
            finalEquation += valueUntilAnswer;
           

            return finalEquation;
        }
    }
}
