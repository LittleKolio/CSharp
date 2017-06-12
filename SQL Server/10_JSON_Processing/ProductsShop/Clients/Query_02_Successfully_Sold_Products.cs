namespace ProductsShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using AutoMapper;
    using Models;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;

    class Query_02_Successfully_Sold_Products
    {
        static void Main()
        {
            MapperInitialize();

            using (var context = new ProductsShopContext())
            {
                var sellers = context.Users
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                    .OrderBy(s => s.LastName)
                    .ThenBy(s => s.FirstName)
                    .ProjectTo<SellerDto>();

                var result = JsonConvert.SerializeObject(
                    sellers, Formatting.Indented);
                //File.WriteAllText(@"../../Import/SoldProducts.json", result);
                Console.WriteLine(result);
            }
        }

        private static void MapperInitialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, SellerDto>()
                    .ForMember(
                        dto => dto.ProdSold,
                        opt => opt.MapFrom(
                            src => src.ProductsSold
                                .Where(p => p.BuyerId != null)));

                cfg.CreateMap<Product, BuyerAndProductDto>()
                    .ForMember(
                        dto => dto.FirstName,
                        opt => opt.MapFrom(src => src.Buyer.FirstName))
                    .ForMember(
                        dto => dto.LastName,
                        opt => opt.MapFrom(src => src.Buyer.LastName));
            });
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }

    public class SellerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<BuyerAndProductDto> ProdSold { get; set; }
        /*
        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(
                $"{this.FirstName} {this.LastName} | " +
                $"ProductsSold: {this.ProdSold.Count()}");

            foreach (var prod in this.ProdSold)
            {
                result.AppendLine(prod.ToString());
            }

            return result.ToString();
        }
        */
    }

    public class BuyerAndProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /*
        public override string ToString()
        {
            return $"\tname: {this.Name}\n" +
                $"\tprice: {this.Price}\n" +
                $"\tbuyerFirstName: {this.FirstName}\n" +
                $"\tbuyerLastName: {this.LastName}";
        }
        */
    }
}
