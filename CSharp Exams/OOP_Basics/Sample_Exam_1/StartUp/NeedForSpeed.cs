namespace Sample_Exam_1.StartUp
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class NeedForSpeed
    {
        static void Main()
        {
            CarManager manager = new CarManager();
            string input;
            while ((input = Console.ReadLine()) != "Cops Are Here")
            {
                string[] formatInput = input
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                string command = formatInput[0];
                int id = int.Parse(formatInput[1]);
                string type = formatInput[2];
                string brand = formatInput[3];
                string model = formatInput[4];
                int yearOfProduction = int.Parse(formatInput[5]);
                int horsepower = int.Parse(formatInput[6]);
                int acceleration = int.Parse(formatInput[7]);
                int suspension = int.Parse(formatInput[8]);
                int durability = int.Parse(formatInput[9]);

                switch (command)
                {
                    case "register":
                        manager.Register(
                            id,
                            type,
                            brand,
                            model,
                            yearOfProduction,
                            horsepower,
                            acceleration,
                            suspension,
                            durability);
                        break;
                }
            }
        }
    }
}
