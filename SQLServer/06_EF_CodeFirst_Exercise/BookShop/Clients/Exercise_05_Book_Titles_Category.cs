namespace BookShop.Clients
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;

    class Exercise_05_Book_Titles_Category
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .ToLower()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

            var books = new List<Book>();
            using (var context = new BookShopContext())
            {
                books = context.Books.Include(b => b.Categories).ToList();
            }

            books.Where(b =>
            {
                var catList = b.Categories.Select(c => c.Name.ToLower()).ToArray();
                foreach (var cat in input)
                {
                    if (!catList.Contains(cat)) { return false; }
                }
                return true;
            })
            .OrderBy(b => b.Id)
            .ToList()
            .ForEach(b => Console.WriteLine(b.Title));
        }
    }
}
