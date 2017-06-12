namespace Photographers.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using Util;
    using System.Data.Entity.Validation;

    class Startup
    {
        static void Main()
        {
            //var context = new PhotographerContext();
            //context.Database.Initialize(true);

            //AddDataPhot(context);

            CatchValidationExeption();
        }

        private static void CatchValidationExeption()
        {
            var context = new PhotographerContext();
            using (context)
            {
                var t = new Tag
                { Label = "Y y__DFDd      fSDFDdf45645Fw333333" };
                context.Tags.Add(t);

                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Console.WriteLine(
                            "Entity of type {0} in state {1} has the following validation errors:",
                            eve.Entry.Entity.GetType().Name,
                            eve.Entry.State);

                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine(
                                "- Property: {0}, Error: {1}",
                                ve.PropertyName,
                                ve.ErrorMessage);
                        }

                        if (eve.Entry.Entity.GetType().Name == "Tag")
                        {
                            t.Label = TagTransofrmer.Transofrmer(t.Label);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }

        private static void AddDataPhot(PhotographerContext context)
        {
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

            context.Photographers.AddRange(listPhot);
            context.SaveChanges();
        }
    }
}
