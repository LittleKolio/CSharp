namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using System.IO;

    class Exercise_11_Total_Book_Copies
    {
        static void Main()
        {
            var query = File.ReadAllText(@"../../Clients/Exercise_11_Total_Book_Copies.sql");
            using (var context = new BookShopContext())
            {
                var authors = context.Database
                    .SqlQuery<Filter>(query)
                    .ToList();
                foreach (var a in authors)
                {
                    Console.WriteLine($"{a.FullName} - {a.Copies}");
                }
            }

            #region linq groupby
            /*
            using (var context = new BookShopContext())
            {
                var authors = context.Books
                    .GroupBy(b => b.AuthorId)
                    .Select(b => new
                    {
                        Copies = b.Sum(c => c.Copies),
                        FullName = b.FirstOrDefault().Author.FirstName + 
                            " " + b.FirstOrDefault().Author.LastName
                    })
                    .OrderByDescending(s => s.Copies)
                    .ToList();
                foreach (var a in authors)
                {
                    Console.WriteLine($"{a.FullName} - {a.Copies}");
                }
            }
            */
            #endregion
        }
    }

    class Filter
    {
        public string FullName { get; set; }
        public int Copies { get; set; }
    }
}