namespace PlanetHunters.Dto.Import
{
    using System;
    using System.Collections.Generic;

    public class DiscoveryDto
    {
        public DateTime DateMade { get; set; }
        public string Telescope { get; set; }
        public List<string[]> Stars { get; set; }
        public List<string> Planets { get; set; }
    }
}
