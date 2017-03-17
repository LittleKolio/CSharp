namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;

    class Exercise_07_Authors_Search
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var context = new BookShopContext();
            var authors = context.Authors
                .Where(a => a.FirstName.Substring(a.FirstName.Length - input.Length) == input)
                .ToList();
            authors.ForEach(a => Console.WriteLine($"{a.FirstName} {a.LastName}"));
        }
    }
}
