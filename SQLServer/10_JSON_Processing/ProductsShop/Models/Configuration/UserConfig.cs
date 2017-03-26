namespace ProductsShop.Models.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    public class UserConfig
        : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            this.HasMany(u => u.Friends)
                .WithMany()
                .Map(u =>
                {
                    u.ToTable("Friends");
                    u.MapLeftKey("UserA");
                    u.MapRightKey("UserB");
                });

            //this.HasMany(u => u.Friends)
            //    .WithRequired(uf => uf.UserB)
            //    .HasForeignKey(uf => uf.UserBId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
