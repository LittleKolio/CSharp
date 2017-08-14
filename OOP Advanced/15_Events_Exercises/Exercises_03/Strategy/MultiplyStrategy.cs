using System;

namespace Events_Exercises.Exercises_03
{
    public class MultiplyStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
