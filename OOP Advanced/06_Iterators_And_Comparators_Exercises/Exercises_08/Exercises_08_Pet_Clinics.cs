namespace Iterators_And_Comparators_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Threading.Tasks;
    class Exercises_08_Pet_Clinics
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                List<string> input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string cmd = input[0];
                input.Remove(cmd);

                switch (cmd)
                {
                    case "Create":
                        CreateEntity(input);
                        break;
                }
            }
        }

        private static void CreateEntity(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
