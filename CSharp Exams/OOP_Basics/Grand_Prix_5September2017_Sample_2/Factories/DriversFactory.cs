using System.Collections.Generic;

public class DriverFactory
{
    public Driver GetDriver(List<string> args, Car car)
    {
        string type = args[0];
        string name = args[1];
        switch (type)
        {
            case "Endurance": return new EnduranceDriver(name, car);
            case "Aggressive": return new AggressiveDriver(name, car);

            default: return null;
        }
    }
}