namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;

    class Exercise_01_Books_Titles_Age_Restriction
    {
        static void Main()
        {
            var input = Console.ReadLine();
            AgeRestriction res;
            try
            {
                res = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), input, true);
                using (var context = new BookShopContext())
                {
                    var bookList = context.Books
                    .Where(b => b.AgeRestriction == res)
                    .ToList();

                    foreach (var b in bookList) { Console.WriteLine(b.Title); }
                }
            }
            catch (ArgumentException)
            {
                //Console.WriteLine($"'{ageRes}' is not a member of the enumeration.");
            }




            //var context = new BookShopContext();
            //string[] strResArray = { "minor", "teen", "adult" };

            //Print2(context, strResArray);
            //Print1(context, resArray);
        }

        private static void Print2(BookShopContext context, string[] resArray)
        {
            var enumResArray = new AgeRestriction[resArray.Length];
            for (var i = 0; i < resArray.Length; i++)
            {
                try
                {
                    var res = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), resArray[i], true);
                    enumResArray[i] = res;
                }
                catch (ArgumentException)
                {
                    //Console.WriteLine($"'{ageRes}' is not a member of the enumeration.");
                }
            }

            var bookList = context.Books
                .Where(b => enumResArray.Contains(b.AgeRestriction))
                .ToList();

            foreach (var b in bookList) { Console.WriteLine(b.Title); }
        }

        private static void Print1(BookShopContext context, string[] resArray)
        {
            var bookList = context.Books
                .Where(b => resArray.Contains(b.AgeRestriction.ToString().ToLower()))
                .ToList();

            foreach (var b in bookList) { Console.WriteLine(b.Title); }
        }
    }
}
