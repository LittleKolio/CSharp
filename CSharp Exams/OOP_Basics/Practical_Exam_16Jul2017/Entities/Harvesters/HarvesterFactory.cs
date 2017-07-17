using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester GetHarvester(List<string> arguments)
    {
        string type = arguments[0];
        arguments.Remove(type);

        switch (type)
        {
            case "Hammer":
                return new HammerHarvester(
                    arguments[0], // id
                    double.Parse(arguments[1]), // oreOutput
                    double.Parse(arguments[2]) // energyRequirement
                    );
            case "Sonic":
                return new SonicHarvester(
                    arguments[0], // id
                    double.Parse(arguments[1]), // oreOutput
                    double.Parse(arguments[2]), // energyRequirement
                    int.Parse(arguments[3]) // sonicFactor
                    );
            default: return null;
        }
    }
}