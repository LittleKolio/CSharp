namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models.Contacts;
    using Migrations;

    public class OrganizerEntities : DbContext
    {

        public OrganizerEntities()
            : base("OrganizerEntities") // iztrivame "name="
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<OrganizerEntities, Configuration>()
                );
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
    }
}