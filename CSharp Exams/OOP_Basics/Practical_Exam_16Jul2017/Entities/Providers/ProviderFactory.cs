using System.Collections.Generic;

public class ProviderFactory
{
    public Provider GetProvider(List<string> arguments)
    {
        string type = arguments[0];
        arguments.Remove(type);

        switch (type)
        {
            case "Solar":
                return new SolarProvider(
                    arguments[0],
                    double.Parse(arguments[1])
                    );
            case "Pressure":
                return new PressureProvider(
                    arguments[0],
                    double.Parse(arguments[1])
                    );
            default: return null;
        }
    }
}
