namespace Photographers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data;
    using Models;
    using Util;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotographerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Photographers.Data.PhotographerContext";
        }

        protected override void Seed(PhotographerContext context)
        {
            #region Photographers
            var listPhot = new List<Photographer>();
            listPhot.Add(new Photographer
            {
                Name = "A",
                Password = "123",
                Email = "asd@asd.vf",
                RegisterDate = new DateTime(1910, 1, 1),
                BirthDate = new DateTime(1900, 1, 1)
            });
            listPhot.Add(new Photographer
            {
                Name = "B",
                Password = "123",
                Email = "qwe@asd.vf",
                RegisterDate = new DateTime(1910, 1, 1),
                BirthDate = new DateTime(1900, 1, 1)
            });
            listPhot.Add(new Photographer
            {
                Name = "C",
                Password = "123",
                Email = "zxc@asd.vf",
                RegisterDate = new DateTime(1910, 1, 1),
                BirthDate = new DateTime(1900, 1, 1)
            });
            foreach (var p in listPhot)
            {
                context.Photographers.AddOrUpdate(a => a.Name, p);
            }
            context.SaveChanges();
            #endregion

            #region Tags
            Tag t = new Tag() { Label = "D d__DFDd      fSDFDdfSDFw333333" };
            context.Tags.Add(t);
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                t.Label = TagTransofrmer.Transofrmer(t.Label);
                context.SaveChanges();
            }
            #endregion
        }
    }
}
