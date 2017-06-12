namespace MassDefect.Data.Store
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Dto;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PersonStore
    {
        public static void AddPeople(
            IEnumerable<PersonDto> peopleCollection)
        {
            var context = new MassDefectContext();
            using (context)
            {
                foreach (var person in peopleCollection)
                {
                    if (person.Name == null || 
                        person.HomePlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var homePlanet = PlanetStore.GetPlanet(
                            person.HomePlanet, context);

                        if (homePlanet == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            context.People.Add(new Person
                            {
                                Name = person.Name,
                                HomePlanet = homePlanet
                            });
                            Console.WriteLine(
                                $"Successfully imported Person {person.Name}.");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static Person GetPerson(string name, MassDefectContext context)
        {
            return context.People
                .FirstOrDefault(p => p.Name == name);
        }

        public static List<ExportPersonDto> PeopleNotBeenVictims()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Person, ExportPersonDto>();
                cfg.CreateMap<Planet, ExportHomePlanetDto>();
            });

            var context = new MassDefectContext();
            using (context)
            {
                return context.People
                    .Where(p => p.Anomalies.Count == 0)
                    .ProjectTo<ExportPersonDto>()
                    .ToList();
            }
        }
    }
}
