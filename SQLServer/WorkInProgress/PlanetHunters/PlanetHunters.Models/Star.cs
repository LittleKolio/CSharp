namespace PlanetHunters.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Each star holds information about its host star system.
    /// </summary>
    
    public class Star
    {
        public int Id { get; set; }
        [MaxLength(255), Required]
        public string Name { get; set; }
        [Range(2400, int.MaxValue), Required]
        public int Temperature { get; set; } //Kelvin
        [Required]
        public int StarSystemId { get; set; }
        public virtual StarSystem StarSystem { get; set; }
        public int? DiscoveryId { get; set; }
        public virtual Discovery Discovery { get; set; }
    }
}
