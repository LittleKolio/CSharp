using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Modifiers
{
    public static double GetModifier(string mod)
    {
        double result = 0.0;

        switch (mod.ToLower())
        {
            case "white": result = 1.5; break;
            case "wholegrain": result = 1.0; break;
            case "crispy": result = 0.9; break;
            case "chewy": result = 1.1; break;
            case "homemade": result = 1.0; break;
            case "meat": result = 1.2; break;
            case "veggies": result = 0.8; break;
            case "cheese": result = 1.1; break;
            case "sauce": result = 0.9; break;
            default: result = -1.0; break;
        }

        return result;
    }
}
