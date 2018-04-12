namespace Exercise_01_Event_Implementation.Contracts
{
    public interface IHandler
    {
        void OnDispatcherNameChange(object sender, INameChange args);
    }
}
