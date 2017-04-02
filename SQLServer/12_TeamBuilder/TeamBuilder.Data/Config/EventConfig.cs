namespace TeamBuilder.Data.Config
{
    using Models;
    using System.Data.Entity.ModelConfiguration;

    public class EventConfig
        : EntityTypeConfiguration<Event>
    {
        public EventConfig()
        {
            Property(e => e.Name)
                .IsUnicode(true);
            Property(e => e.Description)
                .IsUnicode(true);

            HasRequired(e => e.Creator)
                .WithMany(u => u.EventsCreator);

            HasMany(e => e.Teams)
                .WithMany(t => t.Events)
                .Map(et =>
                {
                    et.ToTable("EventTeams");
                    et.MapLeftKey("EventId");
                    et.MapRightKey("TeamId");
                });
        }
    }
}
