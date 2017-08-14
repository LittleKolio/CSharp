namespace Events_Exercises.Exercises_03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PrimitiveCalculator
    {
        private IStrategy strategy;

        private Dictionary<char, IStrategy> strategies 
            = new Dictionary<char, IStrategy>
            {
                {'+', new AdditionStrategy()},
                {'-', new SubtractionStrategy()},
                {'*', new MultiplyStrategy()},
                {'/', new DividStrategy()}
            };

        public PrimitiveCalculator()
        {
            this.strategy = strategies['+'];
        }

        public void changeStrategy(char @operator)
        {
            this.strategy = strategies[@operator];
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
