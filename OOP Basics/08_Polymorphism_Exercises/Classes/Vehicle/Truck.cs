using System;

namespace Polymorphism_Exercises.Classes
{
    public class Truck : Vehicle
    {
        private const double hole = 0.95;
        private const double summer = 1.6;
        public Truck(double tank, double fuelConsumption, double tankCapacity) 
            : base(tank, fuelConsumption + summer, tankCapacity) { }
        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * hole);
        }
    }
}
