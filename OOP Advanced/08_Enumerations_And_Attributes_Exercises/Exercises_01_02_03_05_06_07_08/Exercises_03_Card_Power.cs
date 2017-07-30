namespace Enumerations_And_Attributes_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_03_Card_Power
    {
        static void Main()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            Card card = new Card(suit, rank);
            Console.WriteLine(card);
        }
    }
}
