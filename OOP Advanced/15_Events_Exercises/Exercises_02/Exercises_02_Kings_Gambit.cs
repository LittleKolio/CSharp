namespace Events_Exercises.Exercises_02
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_02_Kings_Gambit
    {
        public delegate Soldier GetSoldier(string name);

        static IList<Soldier> army;

        public static void Main()
        {
            army = new List<Soldier>();

            King king = new King(Console.ReadLine());

            AddSoldier(king, (name) => new RoyalGuard(name));
            AddSoldier(king, (name) => new Footman(name));

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split();
                switch (commands[0])
                {
                    case "Kill":
                        Soldier killedSoldier = army.FirstOrDefault(s => s.Name == commands[1]);
                        king.UnderAttack -= killedSoldier.KingUnderAttack;
                        army.Remove(killedSoldier);
                        break;
                    case "Attack":
                        king.OnUnderAttack();
                        break;
                }
            }
        }

        private static void AddSoldier(King king, GetSoldier soldier)
        {
            foreach (string name in Console.ReadLine().Split())
            {
                Soldier tempSoldier = soldier(name);
                king.UnderAttack += tempSoldier.KingUnderAttack;
                army.Add(tempSoldier);
            }
        }
    }
}
