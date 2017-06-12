namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Contacts;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<OrganizerEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.OrganizerEntities";
        }

        protected override void Seed(OrganizerEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            var list = new List<Person>();
            list.Add(new Person
            {
                FirstName = "A",
                LastName = "B"
            });
            list.Add(new Person
            {
                FirstName = "C",
                LastName = "D"
            });
            foreach (var l in list)
            {
                context.People.AddOrUpdate(r => new { r.FirstName, r.LastName}, l);
            }
            context.SaveChanges();
        }
    }
}
