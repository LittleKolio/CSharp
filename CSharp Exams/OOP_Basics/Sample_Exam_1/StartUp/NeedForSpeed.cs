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

                switch (command)
                {
                    case "register":
                        manager.Register(
                            int.Parse(formatInput[1]), //id
                            formatInput[2], //type
                            formatInput[3], //brand
                            formatInput[4], //model
                            int.Parse(formatInput[5]), //yearOfProduction
                            int.Parse(formatInput[6]), //horsepower
                            int.Parse(formatInput[7]), //acceleration
                            int.Parse(formatInput[8]), //suspension
                            int.Parse(formatInput[9]) //durability
                            );
                        break;

                    case "open":
                        manager.Open(
                            int.Parse(formatInput[1]), //id
                            formatInput[2], //type
                            int.Parse(formatInput[3]), //length
                            formatInput[4], //route
                            int.Parse(formatInput[5]) //prizePool
                            );
                        break;
                    case "participate":
                        manager.Participate(
                            int.Parse(formatInput[1]), //carId
                            int.Parse(formatInput[2]) //raceId
                            );
                        break;
                }
            }
        }
    }
}
