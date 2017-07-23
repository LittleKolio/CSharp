namespace Interfaces_And_Abstraction_Exercises.Exercises_08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_08_Military_Elite
    {
        private static IList<ISoldier> army;
        public static void Main()
        {
            army = new List<ISoldier>();

            string input;
            while (!(input = Console.ReadLine())
                .Equals("End"))
            {
                string[] tokens = input
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Private":
                        army.Add(new Private(
                            int.Parse(tokens[1]), 
                            tokens[2], 
                            tokens[3], 
                            double.Parse(tokens[4])
                            ));
                        break;
                    case "LeutenantGeneral":
                        IList<ISoldier> privates = GetPrivates(tokens.Skip(5).ToList());
                        army.Add(new LeutenantGeneral(
                            int.Parse(tokens[1]),
                            tokens[2],
                            tokens[3],
                            double.Parse(tokens[4]),
                            privates
                            ));
                        break;
                    case "Engineer":
                        IList<IRepair> repairs = GetRepairs(tokens.Skip(6).ToList());
                        army.Add(new Engineer(
                            int.Parse(tokens[1]),
                            tokens[2],
                            tokens[3],
                            double.Parse(tokens[4]),
                            tokens[5],
                            repairs
                            ));
                        break;
                    case "Commando":
                        IList<IMission> missions = GetMissions(tokens.Skip(6).ToList());
                        army.Add(new Commando(
                            int.Parse(tokens[1]),
                            tokens[2],
                            tokens[3],
                            double.Parse(tokens[4]),
                            tokens[5],
                            missions
                            ));
                        break;
                    case "Spy":
                        army.Add(new Spy(
                            int.Parse(tokens[1]),
                            tokens[2],
                            tokens[3],
                            int.Parse(tokens[4])
                            ));
                        break;
                }
            }

            foreach (var soldier in army)
            {
                Console.WriteLine(soldier);
            }
        }

        private static IList<IRepair> GetRepairs(List<string> tokens)
        {
            List<IRepair> list = new List<IRepair>();
            for (int i = 0; i < tokens.Count; i += 2)
            {
                list.Add(new Repair(tokens[i], int.Parse(tokens[i + 1])));
            }
            return list;
        }

        private static IList<IMission> GetMissions(IList<string> tokens)
        {
            List<IMission> list = new List<IMission>();
            for (int i = 0; i < tokens.Count; i += 2)
            {
                list.Add(new Mission(tokens[i], tokens[i + 1]));
            }
            return list;
        }

        private static IList<ISoldier> GetPrivates(IList<string> tokens)
        {
            List<ISoldier> list = new List<ISoldier>();
            foreach (var item in tokens)
            {
                list.Add(army.First(s => s.Id == int.Parse(item)));
            }
            return list;
        }
    }
}
