namespace PlanetHunters.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class ZeroOrNegativeAttribute
        : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) { return true; }
            double primaryReflector = double.Parse(value.ToString());
            return primaryReflector > 0.0;
        }
    }
}
