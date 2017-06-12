namespace PlanetHunters.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// An astronomer can make many discoveries and observe many discoveries.
    /// </summary>

    public class Astronomer
    {
        public Astronomer()
        {
            this.PioneeringDiscoveries = new HashSet<Discovery>();
            this.ObservationsOfDiscoveries = new HashSet<Discovery>();
        }
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string FirstName { get; set; }
        [MaxLength(50), Required]
        public string LastName { get; set; }
        public virtual ICollection<Discovery> PioneeringDiscoveries  { get; set; }
        public virtual ICollection<Discovery> ObservationsOfDiscoveries { get; set; }

        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
