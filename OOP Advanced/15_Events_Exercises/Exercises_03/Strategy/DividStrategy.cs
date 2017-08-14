using System;

namespace Events_Exercises.Exercises_03
{
    public class DividStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
