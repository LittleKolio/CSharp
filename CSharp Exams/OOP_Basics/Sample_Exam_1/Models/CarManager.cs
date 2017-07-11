namespace Sample_Exam_1.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class CarManager
    {
        private List<Car> cars;
        private List<Race> races;
        private Garage garage;

        public CarManager()
        {
            this.cars = new List<Car>();
            this.races = new List<Race>();
            this.garage = new Garage();
        }

        public void Register(
            int id, 
            string type, 
            string brand, 
            string model, 
            int yearOfProduction, 
            int horsepower, 
            int acceleration, 
            int suspension, 
            int durability)
        {
            switch (type)
            {
                case "Performance":
                    cars.Add(new Performance(
                        brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
                    break;
                case "Show":
                    cars.Add(new Show(
                        brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
                    break;
            }
        }

        public void Open(int id, string type, int length, string route, int prizePool)
        {
            switch (type)
            {
                case "Casual":
                    races.Add(new Casual(length, route, prizePool));
                    break;
                case "Drag":
                    races.Add(new Drag(length, route, prizePool));
                    break;
                case "Drift":
                    races.Add(new Drift(length, route, prizePool));
                    break;
            }
        }
        public void Participate(int carId, int raceId)
        {
            //if (garage.ParkedCars.All(id => id != carId))
            //{
            //    races[raceId].AddParticipant
            //}
        }
        public string Start(int id)
        {
            return null;
        }
        public void Park(int id) { }
        public void Unpark(int id) { }
        public void Tune(int tuneIndex, string addOn) { }
        public string Check(int id)
        {
            return null;
        }

    }
}
