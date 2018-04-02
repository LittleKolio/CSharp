namespace Exercise_03_BarracksWars_A_New_Factory.Core.Commands
{
    using Attributes;
    using Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = base.Data[0];
            this.repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
    }
}
