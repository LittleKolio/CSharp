namespace PlanetHunters.Models
{
    using Attributes;
    using System.ComponentModel.DataAnnotations;

    public class Telescope
    {
        public int Id { get; set; }
        [MaxLength(255), Required]
        public string Name { get; set; }
        [MaxLength(255), Required]
        public string Location { get; set; }
        [ZeroOrNegative]
        public double? MirrorDiameter { get; set; }
    }
}
