namespace CarDealer.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using System.Xml.Linq;
    using AutoMapper;
    using Models;
    using AutoMapper.QueryableExtensions;
    using System.Xml.Serialization;
    using System.IO;

    class Query_06_Sales_Applied_Discount
    {
        //Xml Format
        //<sales>
        //    <sale>
        //        <car make = "Peugeot" model="405" travelled-distance="92036854775807" />
        //        <customer-name>Donnetta Soliz</customer-name>
        //        <discount>0.3</discount>
        //        <price>1402.53</price>
        //        <price-with-discount>981.771</price-with-discount>
        //    </sale>
        //    <sale>
        //    ...
        //</sales>

        static void Main()
        {
            var context = new CarDealerContext();
            using (context)
            {
                //AnonymousObjects(context);
                DtoObjects(context);
            }
        }

        private static void DtoObjects(CarDealerContext context)
        {
            MapInitializer();

            var sales = context.Sales
                .ProjectTo<SaleDto>()
                .ToList();

            var serializer = new XmlSerializer(typeof(List<SaleDto>));
            var writer = new StreamWriter(@"../../Clients/ruru.xml");
            using (writer)
            {
                serializer.Serialize(writer, sales);
            }
        }

        private static void MapInitializer()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarDto>()
                    .ForMember(
                    dto => dto.TravelledDistance,
                    opt => opt.MapFrom(src => src.TravelledDistance.HasValue 
                        ? src.TravelledDistance.Value.ToString() 
                        : "null"));

                cfg.CreateMap<Sale, SaleDto>()

                    .ForMember(
                    dto => dto.CustomerName,
                    opt => opt.MapFrom(src => src.Customer.Name))

                    .ForMember(
                    dto => dto.Price,
                    opt => opt.MapFrom(src => src.Car.Parts.Sum(p => p.Price)))

                    .ForMember(
                    dto => dto.PriceWithDiscount,
                    opt => opt.MapFrom(src => src.Car.Parts.Sum(p => p.Price) * (1 - src.Discount / 100m)));
            });
            Mapper.AssertConfigurationIsValid();
        }

        private static void AnonymousObjects(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    Car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Customer = s.Customer.Name,
                    Discount = s.Discount,
                    Price = s.Car.Parts.Sum(p => p.Price),
                    PriceWithDiscount = s.Car.Parts.Sum(p => p.Price) * (1m - s.Discount / 100m)
                })
                .ToList();

            var salesXml = new XDocument();
            salesXml.Add(new XElement("sales"));

            foreach (var sale in sales)
            {
                salesXml.Root.Add(new XElement("sale",
                    new XElement("car",
                        new XAttribute("make", sale.Car.Make),
                        new XAttribute("model", sale.Car.Model),
                        new XAttribute("travelled-distance", sale.Car.TravelledDistance)
                        ),
                    new XElement("customer-name", sale.Customer),
                    new XElement("price", sale.Price),
                    new XElement("price-with-discount", sale.PriceWithDiscount)
                    ));
            }
            salesXml.Save(@"../../Clients/dudu.xml");
        }
    }

    public class SaleDto
    {
        [XmlElement("car")]
        public CarDto Car { get; set; }
        [XmlElement("customer-name")]
        public string CustomerName { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }

    public class CarDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public string TravelledDistance { get; set; }
    }
}
