namespace MassDefect.Data.Config
{
    using Models;
    using System.Data.Entity.ModelConfiguration;

    public class PlanetConfig
        : EntityTypeConfiguration<Planet>
    {
        public PlanetConfig()
        {
            HasRequired(p => p.SolarSystem)
                .WithMany(s => s.Planets)
                .WillCascadeOnDelete(false);
            HasRequired(p => p.Sun)
                .WithMany(s => s.Planets)
                .WillCascadeOnDelete(false);
        }
    }
}
