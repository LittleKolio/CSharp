namespace Enumerations_And_Attributes_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_06_Custom_Enum_Attribute
    {
        static void Main()
        {
            string input = Console.ReadLine();

            if (input == "Rank")
            {
                PrintAttribute(typeof(CardRanks));
            }
            else if (input == "Suit")
            {
                PrintAttribute(typeof(CardSuits));
            }
            else
            {
                throw new InvalidOperationException(
                    "Emiiii");
            }
        }

        private static void PrintAttribute(Type type)
        {
            var attrs = type.GetCustomAttributes(false);
            Console.WriteLine(attrs[0]);
        }
    }
}
