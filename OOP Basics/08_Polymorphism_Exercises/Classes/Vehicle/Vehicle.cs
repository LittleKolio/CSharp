using System;

namespace Polymorphism_Exercises.Classes
{
    public abstract class Vehicle
    {
        public Vehicle(double tank, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.Tank = tank;
            this.FuelConsumption = fuelConsumption;
        }
        protected double TankCapacity { get; set; }
        protected virtual double Tank { get; set; }
        protected double FuelConsumption { get; set; }
        protected virtual bool Distance(double distance, bool airConditioner)
        {
            double fuel = distance * this.FuelConsumption;
            if (fuel <= this.Tank)
            {
                this.Tank -= fuel;
                return true;
            }
            return false;
        }
        public string Drive(double distance, bool airConditioner)
        {
            if (Distance(distance, airConditioner))
            {
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
        public string Drive(double distance)
        {
            return this.Drive(distance, true);
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException(
                    "Fuel must be a positive number");
            }
            this.Tank += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Tank:F2}";
        }
    }
}
