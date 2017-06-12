namespace CarDealer.Clients
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Query_04_Cars_List_Parts
    {
        static void Main()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, MyDto>()
                .ForMember(
                    dest => dest.Car,
                    opts => opts.MapFrom(src => new CarDto
                    {
                        Make = src.Make,
                        Model = src.Model,
                        TravelledDistance = src.TravelledDistance
                    }));
                cfg.CreateMap<Part, PartDto>();
            });
            Mapper.AssertConfigurationIsValid();

            using (var context = new CarDealerContext())
            {
                var cars = context.Cars
                    .ProjectTo<MyDto>();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    //PreserveReferencesHandling = PreserveReferencesHandling.All,
                    Formatting = Formatting.Indented
                };
                var result = JsonConvert.SerializeObject(cars, settings);
                Console.WriteLine(result);
            }

            #region Select(anonymous object)
            /*
            using (var context = new CarDealerContext())
            {
                var cars = context.Cars
                    .Select(c => new
                    {
                        car = new
                        {
                            Make = c.Make,
                            Model = c.Model,
                            TravelledDistance = c.TravelledDistance
                        },
                        parts = c.Parts.Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                    });

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    //PreserveReferencesHandling = PreserveReferencesHandling.All,
                    Formatting = Formatting.Indented
                };
                var result = JsonConvert.SerializeObject(cars, settings);
                Console.WriteLine(result);
            }
            */
            #endregion
        }
    }
    public class MyDto
    {
        [JsonProperty("car")]
        public CarDto Car { get; set; }
        [JsonProperty("parts")]
        public IEnumerable<Part> Parts { get; set; }

    }

    public class CarDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long? TravelledDistance { get; set; }
    }
    public class PartDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
