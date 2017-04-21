namespace PlanetHunters.Models
{
    using Attributes;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Each planet holds information about its host star system.
    /// </summary>

    public class Planet
    {
        public int Id { get; set; }
        [MaxLength(255), Required]
        public string Name { get; set; }
        [ZeroOrNegative, Required]
        public double? Mass { get; set; }
        [Required]
        public int StarSystemId { get; set; }
        public virtual StarSystem StarSystem { get; set; }
        public int? DiscoveryId { get; set; }
        public virtual Discovery Discovery { get; set; }
    }
}
