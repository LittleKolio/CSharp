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
            using (var context = new BookShopContext())
            {
                //var books = context.Database
                //    .SqlQuery<string>(query, num1, num2)
                //    .ToList();

                var books = context.Books
                    .Where(b => b.Price < num1 || b.Price > num2)
                    .OrderBy(b => b.Id)
                    .ToList();

                foreach (var b in books)
                {
                    //Console.WriteLine(b);
                    Console.WriteLine(b.Title + " - $" + b.Price);
                }
            }

        }
    }
}
