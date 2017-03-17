namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;
    using System.Data.Entity;

    class Exercise_04_Not_Released_Books
    {
        static void Main()
        {
            var input = int.Parse(Console.ReadLine());

            var context = new BookShopContext();
            var books = Load();
            //books.ForEach(b => Console.WriteLine(context.Entry(b).State));
            books.Where(b => b.ReleaseDate.Value.Year != input)
                .OrderBy(b => b.Id)
                .ToList()
                .ForEach(b => Console.WriteLine(b.Title));
        }

        private static List<Book> Load()
        {
            var list = new List<Book>();
            using (var context = new BookShopContext())
            {
                list.AddRange(context.Books.ToList());
            }
            return list;
        }
    }
}
