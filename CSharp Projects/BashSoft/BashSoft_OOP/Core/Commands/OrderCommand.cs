
namespace BashSoft_OOP.Core.Commands
{
    using BashSoft_OOP.Interface;

    public class OrderCommand : Command
    {
        private IStudentsRepository studentsRepository;

        protected OrderCommand(
            string[] arguments, 
            IStudentsRepository studentsRepository) 
            : base(arguments)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
