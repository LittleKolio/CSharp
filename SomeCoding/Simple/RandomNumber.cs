namespace Simple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class RandomNumber
    {
        static Random rnd = new Random();
        static void Main()
        {
            //For simple tasks, the Random class is good enough.
            //But for complex things, a RNGCryptoServiceProvider is better.
            //We should "create one Random to generate many random numbers over time."
            //This can be done with a local variable or field.

            CallRandom();
            CallRandom();
            CallRandom();
            CallRandom();
            CallRandom();
            CallRandom();

            RandomText("senators");
            RandomText("senators");
            RandomText("senators");
            RandomText("senators");

        }

        private static void CallRandom()
        {
            //Next() with 2 arguments.
            //The first argument to Next() is the inclusive minimum number.
            //The second argument is an exclusive maximum number.
            //So it never occurs in the output—all numbers must be lower.
            int num = rnd.Next(5, 100);
            Console.WriteLine(num);
        }

        private static void RandomText(string original)
        {
            // Create new string from the reordered char array.
            string rand = new string(original
                    .ToCharArray()
                    .OrderBy(s => (rnd.Next(2) % 2) == 0)
                    .ToArray()
                );

            Console.WriteLine(rand);
        }
    }
}
