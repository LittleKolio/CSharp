namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {

            string input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                string[] args = InputParser.SplitInput(input, " ");

                string result = string.Empty;

                try
                {
                    result = CommandSwitcher(args);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(
                        string.Format(Constants.Exception_Argument, ex.Message));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(
                        string.Format(Constants.Exception_InvalidOperation, ex.Message));
                }

                Console.WriteLine(result);
            }
        }

        private string CommandSwitcher(string[] args)
        {
            string commsnd = args[0];
            args = args.Skip(1).ToArray();

            switch (commsnd)
            {
                case "JoinParty": return this.dungeonMaster.JoinParty(args);

                case "AddItemToPool": return this.dungeonMaster.AddItemToPool(args);
                case "PickUpItem": return this.dungeonMaster.PickUpItem(args);
                case "UseItem": return this.dungeonMaster.UseItem(args);
                case "UseItemOn": return this.dungeonMaster.UseItemOn(args);
                case "GiveCharacterItem": return dungeonMaster.GiveCharacterItem(args);
                case "GetStats": return this.dungeonMaster.GetStats();
                case "Attack": return this.dungeonMaster.Attack(args);
                default: return null;
            }
        }
    }
}
