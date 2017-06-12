namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;

    class Exercise_02_Golden_Books
    {
        static void Main()
        {
            var context = new BookShopContext();
            var str = "gold";
            var num = 5000;

            var type = Enum.Parse(typeof(EditionType), str, true).GetHashCode();

            var query = @"
SELECT Title
FROM dbo.Books
WHERE EditionType = {0}
AND Copies < {1}
ORDER BY Id ASC
";
            var books = context.Database
                .SqlQuery<string>(query, type, num)
                .ToList();
            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
        }
    }
}
