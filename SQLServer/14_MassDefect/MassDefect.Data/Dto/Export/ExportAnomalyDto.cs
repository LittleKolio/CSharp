namespace MassDefect.Data.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Serialization;

    
    public class anomaly
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("origin-planet")]
        public string OriginPlanet { get; set; }
        [XmlAttribute("teleport-planet")]
        public string TeleportPlanet { get; set; }
        [XmlArray("victims")]
        public List<victim> victims { get; set; }
    }
}
