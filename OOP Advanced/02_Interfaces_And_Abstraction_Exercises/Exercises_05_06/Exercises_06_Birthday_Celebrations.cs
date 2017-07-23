namespace Interfaces_And_Abstraction_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_06_Birthday_Celebrations
    {
        static void Main()
        {
            IList<IBirthdate> all = new List<IBirthdate>();

            string input;
            while (!(input = Console.ReadLine())
                .Equals("End"))
            {
                IList<string> tokens = input
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string model = tokens[0];
                tokens.Remove(model);

                switch ()
                {

                }

                DateTime date;
                bool isDate = DateTime.TryParseExact(
                    tokens[tokens.Length - 1],
                    "dd/MM/yyyy",
                    null, //CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out date);

                if (tokens.Length == 2 && isDate)
                {
                    all.Add(new Pet(tokens[0], date));
                }
                else if (tokens.Length == 4)
                {
                    all.Add(new Citizen(
                        tokens[0], 
                        int.Parse(tokens[1]), 
                        tokens[2],
                        date));
                }
                else
                {
                    throw new Exception("Something is wrong");
                }
            }

            int year = int.Parse(Console.ReadLine());
            CheckBirthday(all, year);
        }

        private static void CheckBirthday(IList<IBirthdate> all, int year)
        {
            foreach (var item in all)
            {
                if (item.CheckBirthday(year))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}
