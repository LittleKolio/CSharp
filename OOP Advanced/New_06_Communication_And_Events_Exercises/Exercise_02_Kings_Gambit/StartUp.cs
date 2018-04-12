namespace Exercise_02_Kings_Gambit
{
    using Contracts;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string kingName = Console.ReadLine();
            string[] royalGuards = SplitInput(Console.ReadLine(), " ");
            string[] footmens = SplitInput(Console.ReadLine(), " ");

            IKing king = new King(kingName);
            AddSubordinate(royalGuards, typeof(RoyalGuard), king);
            AddSubordinate(footmens, typeof(Footman), king);

            string input;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                string[] tokens = SplitInput(input, " ");
                string cmd = tokens[0];
                string name = tokens[1];
                switch (cmd)
                {
                    case "Attack":
                        king.Attacked();
                        break;

                    case "Kill":
                        king.Subordinates
                            .First(s => s.Name == name)
                            .Die();
                        break;

                    default:
                        throw new ArgumentException(
                            "Invalid command!");
                }
            }
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }

        private static void AddSubordinate(string[] subs, Type type, IKing king)
        {
            for (int i = 0; i < subs.Length; i++)
            {
                king.AddSubordinates(Factory(type, subs[i]));
            }
        }

        private static ISubordinate Factory(Type type, string name)
        {
            return (ISubordinate)Activator.CreateInstance(
                    type, new object[] { name });
        }
    }
}
