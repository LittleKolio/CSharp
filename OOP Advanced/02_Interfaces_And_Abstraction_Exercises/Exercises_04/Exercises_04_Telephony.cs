namespace Interfaces_And_Abstraction_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_04_Telephony
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string num in numbers)
            {
                Smartphone temp = new Smartphone();
                try
                {
                    temp.Number = num;
                    Console.WriteLine(temp.CallOtherPhones());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string[] urls = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string url in urls)
            {
                Smartphone temp = new Smartphone();
                try
                {
                    temp.Site = url;
                    Console.WriteLine(temp.WorldWideWeb());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
