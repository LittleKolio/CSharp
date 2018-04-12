namespace Exercise_03_Dependency_Inversion
{
	public class SubtractionStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
