using System;

namespace Polymorphism_Exercises.Classes
{
    public class Car : Vehicle
    {
        private const double summer = 0.9;
        public Car(double tank, double fuelConsumption, double tankCapacity) 
            : base(tank, fuelConsumption + summer, tankCapacity) { }
        protected override double Tank
        {
            set
            {
                if (base.TankCapacity < value)
                {
                    throw new ArgumentException(
                        "Cannot fit fuel in tank");
                }
                base.Tank = value;
            }
        }
    }
}
