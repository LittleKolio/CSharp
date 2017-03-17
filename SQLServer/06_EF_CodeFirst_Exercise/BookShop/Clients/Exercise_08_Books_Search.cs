namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;

    class Exercise_08_Books_Search
    {
        static void Main()
        {
            var input = Console.ReadLine().ToLower();
            var context = new BookShopContext();

            var books = context.Books.Select(b => b.Title).ToList();
            books.Where(b => b.ToLower().Contains(input))
                .ToList()
                .ForEach(b => Console.WriteLine(b));
        }
    }
}
