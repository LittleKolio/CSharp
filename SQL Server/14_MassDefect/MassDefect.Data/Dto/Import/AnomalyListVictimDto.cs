namespace MassDefect.Data.Dto
{
    using System.Collections.Generic;

    public class AnomalyListVictimsDto
    {
        public string TeleportPlanet { get; set; }
        public string OriginPlanet { get; set; }
        public ICollection<string> Victims { get; set; }
    }
}
