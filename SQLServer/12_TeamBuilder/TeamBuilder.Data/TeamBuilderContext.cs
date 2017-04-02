namespace TeamBuilder.Data
{
    using Config;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext()
            : base("name=TeamBuilderContext")
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<TeamBuilderContext>()
                );
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new EventConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
} 