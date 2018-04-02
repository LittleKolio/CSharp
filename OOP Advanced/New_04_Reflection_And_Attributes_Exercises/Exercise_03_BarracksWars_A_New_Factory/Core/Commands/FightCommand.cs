namespace Exercise_03_BarracksWars_A_New_Factory.Core.Commands
{
    using System;

    public class FightCommand : Command
    {
        protected FightCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
