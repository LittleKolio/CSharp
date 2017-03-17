namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;

    class Exercise_03_Books_Price
    {
        static void Main()
        {
            var context = new BookShopContext();
            var num1 = 5;
            var num2 = 40;

            var query = @"
SELECT Title + ' - $' + CONVERT(varchar(5), Price)
AS Result
FROM dbo.Books
WHERE Price < {0}
OR Price > {1}
ORDER BY Id ASC
";
            var books = context.Database
                .SqlQuery<string>(query, num1, num2)
                .ToList();
            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
        }
    }
}
