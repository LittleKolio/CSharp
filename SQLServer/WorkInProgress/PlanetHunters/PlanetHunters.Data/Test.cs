namespace PlanetHunters.Data
{
    using Models;
    using System;
    using System.Data.Entity.Validation;

    public class Test
    {
        public static void ZeroOrNegativeAttribute()
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                var telescop = new Telescope
                {
                    Name = "Tartei",
                    Location = "Tro6evo",
                    //MirrorDiameter = -6.66
                    //MirrorDiameter = 0
                    MirrorDiameter = 0.000000000012
                };
                context.Telescopes.Add(telescop);

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
                    }
                }
            }
        }
    }
}
