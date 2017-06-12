namespace ProductsShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Newtonsoft.Json;
    using System.IO;

    public class Query_01_Products_In_Range
    {
        static void Main()
        {
            using (var context = new ProductsShopContext())
            {
                var products = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        SellerName = (p.Seller.FirstName != null ? (p.Seller.FirstName + " ") : "") + 
                            p.Seller.LastName
                    });

                var result = JsonConvert
                    .SerializeObject(products, Formatting.Indented);
                //File.WriteAllText(@"../../Import/ProductsInRange.json", result);
                Console.WriteLine(result);

            }
        }
    }
}
