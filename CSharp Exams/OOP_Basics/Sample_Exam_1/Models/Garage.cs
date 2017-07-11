namespace Sample_Exam_1.Models
{
    using System.Collections.Generic;

    public class Garage
    {
        private List<int> parkedCars;
        public Garage()
        {
            this.parkedCars = new List<int>();
        }
        public List<int> ParkedCars
        {
            get { return this.parkedCars; }
            //set { this.parkedCars = value; }
        }
        public void AddCar(int id)
        {
            this.parkedCars.Add(id);
        }
    }
}
