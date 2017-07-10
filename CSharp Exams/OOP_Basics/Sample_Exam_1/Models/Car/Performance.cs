namespace Sample_Exam_1.Models
{
    using System.Collections.Generic;

    public class Performance : Car
    {
        private const double IncreaseHorsepower = 1.5;
        private const double DecreaseSuspension = 0.75;

        private List<string> addOns;

        public Performance(
            string brand, 
            string model, 
            int yearOfProduction, 
            int horsepower, 
            int acceleration, 
            int suspension, 
            int durability) 
            : base(
                  brand, 
                  model, 
                  yearOfProduction, 
                  (int)(horsepower * IncreaseHorsepower),
                  acceleration, 
                  (int)(suspension * DecreaseSuspension), 
                  durability)
        {
            this.addOns = new List<string>();
        }
    }
}
