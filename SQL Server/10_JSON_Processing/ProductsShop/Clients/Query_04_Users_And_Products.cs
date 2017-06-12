namespace ProductsShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Newtonsoft.Json;

    public class Query_04_Users_And_Products
    {
        static void Main()
        {
            using (var context = new ProductsShopContext())
            {
                var users = context.Users
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.ProductsSold.Count,
                            products = u.ProductsSold
                             .Select(p => new
                             {
                                 name = p.Name,
                                 price = p.Price
                             })
                        }
                    });

                var result = JsonConvert.SerializeObject(new
                {
                    usersCount = context.Users.Count(),
                    users = users
                },
                Formatting.Indented);
                //File.WriteAllText(@"../../Import/UsersAndProducts.json", result);
                Console.WriteLine(result);
            }
        }
    }
}
