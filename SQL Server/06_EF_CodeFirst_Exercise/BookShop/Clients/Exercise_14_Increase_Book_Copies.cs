namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;
    using EntityFramework.Extensions;
    using System.Globalization;

    class Exercise_14_Increase_Book_Copies
    {
        static void Main()
        {
            var str = "06 Jun 2013";
            var num = 44;
            var date = DateTime.ParseExact(str, "dd MMM yyyy", CultureInfo.InvariantCulture);

            var context = new BookShopContext();
            var result = context.Books.Where(b => b.ReleaseDate > date);
            //result.Update(b => new Book { Copies = b.Copies + num });
            //context.SaveChanges();

            Console.WriteLine($@"
{result.Count()} books are released after 
{date: dd MMM yyyy} so total of
{result.Count() * num} book copies were added"
);
        }
    }
}
