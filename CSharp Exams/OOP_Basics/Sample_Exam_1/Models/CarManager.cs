namespace Sample_Exam_1.Models
{
    using System.Collections.Generic;

    public class CarManager
    {
        private Dictionary<int, Car> cars;
        private Dictionary<int, Race> races;
        private Garage garage;

        public CarManager()
        {
            this.cars = new Dictionary<int, Car>();
            this.races = new Dictionary<int, Race>();
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
                    cars.Add(id, new Performance(
                        brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
                    break;
                case "Show":
                    cars.Add(id, new Show(
                        brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
                    break;
            }
        }
        public string Check(int id)
        {
            return null;
        }
        public void Open(int id, string type, int length, string route, int prizePool)
        {
            switch (type)
            {
                case "Casual":
                    races.Add(id, new Casual(length, route, prizePool));
                    break;
                case "Drag":
                    races.Add(id, new Drag(length, route, prizePool));
                    break;
                case "Drift":
                    races.Add(id, new Drift(length, route, prizePool));
                    break;
            }
        }
        public void Participate(int carId, int raceId)
        {

        }
        public string Start(int id)
        {
            return null;
        }
        public void Park(int id) { }
        public void Unpark(int id) { }
        public void Tune(int tuneIndex, string addOn) { }

    }
}
