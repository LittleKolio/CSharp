namespace PlanetHunters.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A discovery can be made by many astronomers and can be observed (confirmed) by many astronomers.
    /// A single discovery may include many planets and stars.
    /// </summary>

    public class Discovery
    {
        public Discovery()
        {
            this.Pioneers = new HashSet<Astronomer>();
            this.Observers = new HashSet<Astronomer>();
            this.Stars = new HashSet<Star>();
            this.Planets = new HashSet<Planet>();
        }
        public int Id { get; set; }
        public DateTime DateMade { get; set; }
        [Required]
        public int TelescopeId { get; set; }
        public virtual Telescope Telescope { get; set; }
        public virtual ICollection<Astronomer> Pioneers { get; set; }
        public virtual ICollection<Astronomer> Observers { get; set; }
        public virtual ICollection<Star> Stars { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
    }
}
