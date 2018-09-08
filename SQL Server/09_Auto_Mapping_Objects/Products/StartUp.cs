namespace Products
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class StartUp
    {
        static void Main(string[] args)
        {
            Init.Initializer();

            string query = "SELECT * FROM Clients WHERE Name LIKE @nameParam";
            SqlParameter nameParam = new SqlParameter("@nameParam", "tartei");

            //string query2 = "SELECT * FROM Clients WHERE Name = {0}";

            List<Client> cients;

            ProductsContext context = new ProductsContext();
            using (context)
            {
                cients = context.Database
                    .SqlQuery<Client>(query, nameParam)
                    .ToList();

                //cients = context.Database
                //    .SqlQuery<Client>(query2, "tartei")
                //    .ToList();
            }

            foreach (Client c in cients)
            {
                Console.WriteLine(c.Name);
            }
        }
    }
}