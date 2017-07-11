namespace Sample_Exam_1.Models
{
    using System.Collections.Generic;

    public class Garage
    {
        private List<Car> parkedCars;
        public Garage()
        {
            this.parkedCars = new List<Car>();
        }
        public List<Car> ParkedCars
        {
            get { return this.parkedCars; }
            //set { this.parkedCars = value; }
        }
        public void AddCar(Car car)
        {
            this.parkedCars.Add(car);
        }
    }
}
