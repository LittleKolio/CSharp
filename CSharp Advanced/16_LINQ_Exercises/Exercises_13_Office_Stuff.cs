using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises
{
    public class Stuff
    {
        public string company;
        public int amount;
        public string product;
        public Stuff(string company, int amount, string product)
        {
            this.company = company;
            this.amount = amount;
            this.product = product;
        }
    }
    class Exercises_13_Office_Stuff
    {
        static void Main()
        {
            int order = int.Parse(Console.ReadLine());

            List<Stuff> comapnyProducts = new List<Stuff>();

            for (int i = 0; i < order; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("|- ".ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);

                comapnyProducts.Add(new Stuff(
                    input[0], int.Parse(input[1]), input[2]
                    ));
            }

            var result = comapnyProducts
                .GroupBy(stuff => stuff.company)
                .OrderBy(gCompany => gCompany.Key)
                .Select(gCompany => new
                {
                    Company = gCompany.Key,
                    Products = gCompany
                        .GroupBy(stuff => stuff.product)
                        .Select(gProduct =>
                            gProduct.Key + "-" +
                            gProduct.Select(pNum => pNum.amount).Sum())
                });

            foreach (var comapny in result)
            {
                Console.Write(comapny.Company + ": ");
                Console.WriteLine(string.Join(", ", comapny.Products));
            }
        }
    }
}
