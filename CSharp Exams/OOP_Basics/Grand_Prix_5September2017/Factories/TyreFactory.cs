using System.Collections.Generic;

public class TyreFactory
{
    public Tyre GetTyre(List<string> args)
    {
        string type = args[0];

        double hardness;
        if (!double.TryParse(args[1], out hardness))
        {
            return null;
        }

        switch (type)
        {
            case "Hard": return new HardTyre(hardness);
            case "Ultrasoft":
                {
                    double grip;
                    if (!double.TryParse(args[2], out grip))
                    {
                        return null;
                    }

                    return new UltrasoftTyre(hardness, grip);
                }
            default: return null;
        }
    }
}