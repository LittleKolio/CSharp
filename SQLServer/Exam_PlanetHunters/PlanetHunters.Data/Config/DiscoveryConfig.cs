namespace PlanetHunters.Data.Config
{
    using PlanetHunters.Models;
    using System.Data.Entity.ModelConfiguration;

    public class DiscoveryConfig
        : EntityTypeConfiguration<Discovery>
    {
        public DiscoveryConfig()
        {
            HasMany(d => d.Pioneers)
                .WithMany(p => p.PioneeringDiscoveries)
                .Map(pd =>
                {
                    pd.ToTable("PioneerDiscoveries");
                    pd.MapLeftKey("DiscoveryId");
                    pd.MapRightKey("PioneerId");
                });

            HasMany(d => d.Observers)
                .WithMany(o => o.ObservationsOfDiscoveries)
                .Map(od =>
                {
                    od.ToTable("ObserverDiscoveries");
                    od.MapLeftKey("DiscoveryId");
                    od.MapRightKey("ObserverId");
                });
        }
    }
}
