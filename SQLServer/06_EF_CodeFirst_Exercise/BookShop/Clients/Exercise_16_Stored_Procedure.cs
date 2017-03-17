namespace BookShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;
    using System.Data.SqlClient;

    class Exercise_16_Stored_Procedure
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstName = new SqlParameter("@firstName", input[0]);
            var lastName = new SqlParameter("@lastName", input[1]);

            var context = new BookShopContext();
            var count = context.Database
                .SqlQuery<int>("TotalNumberOfBooks @firstName, @lastName", 
                    firstName, lastName)
                .First();
            Console.WriteLine($"{input[0]} {input[1]} has written {count} books");
        }
    }
}
