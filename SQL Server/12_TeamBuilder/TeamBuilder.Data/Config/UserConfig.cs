namespace TeamBuilder.Data.Config
{
    using Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;

    public class UserConfig
        : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            Property(u => u.Username)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_User_Username", 1) { IsUnique = true }));

            HasMany(u => u.TeamsCreator)
                .WithRequired(t => t.Creator)
                .WillCascadeOnDelete(false);

            HasMany(u => u.EventsCreator)
                .WithRequired(e => e.Creator)
                .WillCascadeOnDelete(false);

            HasMany(u => u.InTeams)
                .WithMany(t => t.Users)
                .Map(ut =>
                {
                    ut.ToTable("UserTeams");
                    ut.MapLeftKey("UserId");
                    ut.MapRightKey("TeamId");
                });

            HasMany(u => u.ReceivedInvitations)
                .WithRequired(i => i.InvitedUser)
                .WillCascadeOnDelete(false);
        }
    }
}
