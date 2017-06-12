namespace PhotoShare.Service
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System.Linq;

    public class TownService
    {
        public void AddTown(string name, string country)
        {
            using(var cxt = new PhotoShareContext())
            {
                var town = new Town
                {
                    Name = name,
                    Country = country
                };

                cxt.Towns.Add(town);
                cxt.SaveChanges();
            }
        }

        public bool IsExist(string name)
        {
            using (var cxt = new PhotoShareContext())
            {
                return cxt.Towns.Any(t => t.Name == name);
            }
        }

        public Town GetTown(string name)
        {
            using (var cxt = new PhotoShareContext())
            {
                return cxt.Towns.SingleOrDefault(t => t.Name == name);
            }
        }
    }
}
