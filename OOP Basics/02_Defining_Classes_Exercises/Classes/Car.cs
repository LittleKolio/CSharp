namespace Defining_Classes_Exercises.Classes
{
    using System;

    class Car
    {
        private string model;
        private double fuelAamount;
        private double fuelConsumption;
        private double distance;

        public Car(string model, double fuelAamount, double fuelConsumption)
        {
            this.model = model;
            this.fuelAamount = fuelAamount;
            this.fuelConsumption = fuelConsumption;
            this.distance = 0;
        }

        public string Model
        {
            get { return this.model; }
        }

        public void DistanceTraveled(double distance)
        {
            if (this.fuelAamount / this.fuelConsumption < distance)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.fuelAamount -= this.fuelConsumption * distance;
                this.distance += distance;
            }

        }

        public string CarInfo()
        {
            return $"{this.model} {this.fuelAamount:F2} {this.distance}";
        }
    }
}
