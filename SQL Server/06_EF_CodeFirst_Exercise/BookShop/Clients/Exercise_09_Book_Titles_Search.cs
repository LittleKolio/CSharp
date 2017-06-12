namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using System.Globalization;

    class Exercise_09_Book_Titles_Search
    {
        static void Main()
        {
            var input = Console.ReadLine().ToLower();
            using (var context = new BookShopContext())
            {
                var books = context.Books
                    .Where(b => b.Author.LastName.ToLower().StartsWith(input))
                    .Select(b => new { b.Title, b.Author.FirstName, b.Author.LastName})
                    .ToList();
                foreach (var b in books)
                {
                    Console.WriteLine($"{b.Title} ({b.FirstName} {b.LastName})");
                }
            }
        }
    }
}
