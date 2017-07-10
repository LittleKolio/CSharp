namespace Sample_Exam_1.Models
{
    public class Show : Car
    {
        public Show(
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
                  horsepower,
                  acceleration, 
                  suspension, 
                  durability)
        {
            this.Stars = 0;
        }
        public int Stars { get; set; }
    }
}
