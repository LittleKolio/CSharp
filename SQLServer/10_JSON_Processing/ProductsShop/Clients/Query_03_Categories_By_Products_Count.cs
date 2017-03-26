namespace ProductsShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;

    public class Query_03_Categories_By_Products_Count
    {
        static void Main()
        {
            using (var context = new ProductsShopContext())
            {
                var categories = context.Categories
                    .OrderBy(c => c.Name)
                    .Select(c => new
                    {
                        Category = c.Name,
                        ProductsCount = c.Products.Count,
                        AveragePrice = c.Products.Average(p => p.Price),
                        TotalRevenue = c.Products.Sum(p => p.Price)
                    });

                var result = JsonConvert.SerializeObject(
                    categories, Formatting.Indented);
                //File.WriteAllText(@"../../Import/CategoriesByProducts.json", result);
                Console.WriteLine(result);
            }
        }
    }
}
