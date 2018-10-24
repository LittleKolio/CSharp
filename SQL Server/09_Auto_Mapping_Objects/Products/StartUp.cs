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

            using (ProductsContext cxt = new ProductsContext())
            {
                Product product = cxt.Products.FirstOrDefault(p => p.Name == "HP LaserJet Pro MFP M426fdw");

                ProductStock productStock = product.ProductsStocks.First();

                Console.WriteLine(productStock.Storage.Name + " - " + productStock.Quantity);
                Console.ReadKey();
            }
        }

        private static void Filtration()
        {
            string query = "SELECT * FROM Clients WHERE Name LIKE @nameParam";
            SqlParameter nameParam = new SqlParameter("@nameParam", "tartei");

            //string query2 = "SELECT * FROM Clients WHERE Name = {0}";

            List<Client> cients;


            //we ca
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