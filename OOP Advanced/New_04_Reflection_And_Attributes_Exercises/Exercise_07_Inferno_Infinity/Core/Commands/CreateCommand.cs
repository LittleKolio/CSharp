namespace Exercise_07_Inferno_Infinity.Core.Commands
{
    using Contracts;
    using System.Linq;

    public class CreateCommand : Command
    {
        private IWeaponFactory weaponFactory;
        private IRepository weaponRepository;

        protected CreateCommand(string[] data, IWeaponFactory weaponFactory, IRepository weaponRepository) : base(data)
        {
            this.weaponFactory = weaponFactory;
            this.weaponRepository = weaponRepository;
        }

        public override void Execute()
        {
            IWeapon weapon = this.weaponFactory.CreateWeapon(base.Data);
            this.weaponRepository.AddWeapon(weapon);
        }
    }
}
