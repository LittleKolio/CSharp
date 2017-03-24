namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;
    using System.Globalization;

    class Exercise_06_Books_Released_Before_Date
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var date = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            using (var context = new BookShopContext())
            {
                var books = context.Books
                    .Where(b => b.ReleaseDate < date)
                    .Select(b => new { b.Title, b.Price, b.EditionType })
                    .ToList();
                foreach (var b in books)
                {
                    Console.WriteLine($"{b.Title} - {b.EditionType.ToString()} - {b.Price}");
                }
            }
        }
    }
}
