public class Bus : Vehicle
{
    public bool people = true;
    private const double fuelModifier = 1.4;

    public Bus(double tank, double fuelConsumption, double tankCapacity) 
        : base(tank, fuelConsumption, tankCapacity)
    {
    }

    public override double FuelConsumption
    {
        get
        {
            if (people)
            {
                return base.FuelConsumption + fuelModifier;
            }
            else
            {
                return base.FuelConsumption;
            }
        }

        protected set
        {
            base.FuelConsumption = value;
        }
    }
}