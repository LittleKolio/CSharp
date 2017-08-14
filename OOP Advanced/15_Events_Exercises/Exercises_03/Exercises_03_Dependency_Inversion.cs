using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_Exercises.Exercises_03
{
    public class Exercises_03_Dependency_Inversion
    {
        public static void Main()
        {
            PrimitiveCalculator calc = new PrimitiveCalculator();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split();

                if (commands[0] == "mode")
                {
                    calc.changeStrategy(char.Parse(commands[1]));
                }
                else
                {
                    Console.WriteLine(
                        calc.performCalculation(
                            int.Parse(commands[0]),
                            int.Parse(commands[1])
                            )
                        );
                }
            }
        }
    }
}
