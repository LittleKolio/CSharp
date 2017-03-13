namespace Photographers.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;
    using Util;
    using System.Data.Entity.Validation;

    class Startup
    {
        static void Main()
        {
            var context = new PhotographerContext();
            context.Database.Initialize(true);


            //Console.WriteLine(context.Tags.Count());

            //AddDataPhot(context);
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
