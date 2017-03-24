namespace PhotoShare.Service
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TownService
    {
        public virtual void Add(string townname, string country)
        {
            var town = new Town
            {
                Name = townname,
                Country = country
            };
            using (var context = new PhotoShareContext())
            {
                context.Towns.Add(town);
                context.SaveChanges();
            }
        }

        public bool Exist(string townname)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Towns.Any(u => u.Name == townname);
            }
        }
    }
}
