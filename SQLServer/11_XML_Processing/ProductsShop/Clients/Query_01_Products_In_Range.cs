namespace ProductsShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using System.Xml.Serialization;
    using System.IO;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
    using Models;

    class Query_01_Products_In_Range
    {
        static void Main()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>()
                    .ForMember(
                    dest => dest.BuyerName,
                    opt => opt.MapFrom(src => src.Buyer.FirstName + " " + src.Buyer.LastName)
                    );
            });

            using (var context = new ProductsShopContext())
            {
                var products = context.Products
                    .Where(p => p.Price >= 1000 &&
                        p.Price <= 2000 &&
                        p.BuyerId != null)
                    .OrderBy(p => p.Price)
                    .ProjectTo<ProductDto>();

                //var list = new Products();
                //list.Props.AddRange(products);

                var list = new Products();
                list.AddRange(products);

                var serializer = new XmlSerializer(typeof(Products));
                var writer = new StreamWriter("../../Clients/zzz.xml");
                using (writer)
                {
                    serializer.Serialize(writer, list);
                }
            }
        }
    }

    [XmlRoot("products")]
    public class Products
        : List<ProductDto>
    {
    }

    //[XmlRoot("Neznam")]
    //public class Products
    //{
    //    public Products()
    //    {
    //        this.Props = new List<ProductDto>();
    //    }
    //    [XmlArray("products"), XmlArrayItem("product")]
    //    public List<ProductDto> Props { get; set; }
    //}

    public class ProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("buyer")]
        public string BuyerName { get; set; }
    }
}
