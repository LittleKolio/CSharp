namespace MassDefect.Data.Config
{
    using Models;
    using System.Data.Entity.ModelConfiguration;

    public class AnomalyConfig
        : EntityTypeConfiguration<Anomaly>
    {
        public AnomalyConfig()
        {
            HasRequired(a => a.OriginPlanet)
                .WithMany(p => p.AnomaliesOrigin)
                .WillCascadeOnDelete(false);
            HasRequired(a => a.TeleportPlanet)
                .WithMany(p => p.AnomaliesTeleport)
                .WillCascadeOnDelete(false);
            HasMany(a => a.Victims)
                .WithMany(p => p.Anomalies)
                .Map(ap =>
                {
                    ap.ToTable("AnomalyVictims");
                    ap.MapLeftKey("AnomalyId");
                    ap.MapRightKey("PersonId");
                });
        }
    }
}
