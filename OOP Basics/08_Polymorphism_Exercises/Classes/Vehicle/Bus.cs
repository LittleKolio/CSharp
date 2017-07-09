using System;

namespace Polymorphism_Exercises.Classes
{
    public class Bus : Vehicle
    {
        private const double airconditioner = 1.4;
        public Bus(double tank, double fuelConsumption, double tankCapacity) 
            : base(tank, fuelConsumption, tankCapacity) { }

        protected override double Tank
        {
            set
            {
                if (this.TankCapacity < value)
                {
                    throw new ArgumentException(
                        "Cannot fit fuel in tank");
                }
                base.Tank = value;
            }
        }

        protected override bool Distance(double distance, bool airConditioner)
        {
            double fuel = airConditioner 
                ? distance * (base.FuelConsumption + airconditioner)
                : distance * base.FuelConsumption;
            if (fuel <= this.Tank)
            {
                this.Tank -= fuel;
                return true;
            }
            return false;
        }
    }
}
