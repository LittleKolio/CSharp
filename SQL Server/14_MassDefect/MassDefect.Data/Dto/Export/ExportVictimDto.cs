namespace MassDefect.Data.Dto
{
    using System.Xml.Serialization;

    public class victim
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
