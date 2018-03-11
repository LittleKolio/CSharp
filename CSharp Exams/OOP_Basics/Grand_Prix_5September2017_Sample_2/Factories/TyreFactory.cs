using System.Collections.Generic;

public class TyreFactory
{
    public Tyre GetTyre(List<string> args)
    {
        string type = args[0];
        double hardness;
        bool isHardness = double.TryParse(args[1], out hardness);
        if (!isHardness)
        {
            return null;
        }
        switch (type)
        {
            case "Hard": return new HardTyre(hardness);
            case "Ultrasoft":
                {
                    double grip;
                    bool isGrip = double.TryParse(args[2], out grip);
                    if (!isGrip)
                    {
                        return null;
                    }
                    return new UltrasoftTyre(hardness, grip);
                }
            default: return null;
        }
    }
}