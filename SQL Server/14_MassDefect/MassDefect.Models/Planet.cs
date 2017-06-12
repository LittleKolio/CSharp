namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Planet
    {
        public Planet()
        {
            this.People = new HashSet<Person>();
            this.AnomaliesOrigin = new HashSet<Anomaly>();
            this.AnomaliesTeleport = new HashSet<Anomaly>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int SunId { get; set; }
        public virtual Star Sun { get; set; }
        public int SolarSystemId { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Anomaly> AnomaliesOrigin { get; set; }
        public virtual ICollection<Anomaly> AnomaliesTeleport { get; set; }
    }
}
