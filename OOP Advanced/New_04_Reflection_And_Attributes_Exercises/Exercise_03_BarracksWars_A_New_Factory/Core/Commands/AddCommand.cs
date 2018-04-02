
namespace Exercise_03_BarracksWars_A_New_Factory.Core.Commands
{
    using Contracts;
    using Attributes;

    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = base.Data[0];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output =  $"{unitType} added!";
            return output;
        }
    }
}
