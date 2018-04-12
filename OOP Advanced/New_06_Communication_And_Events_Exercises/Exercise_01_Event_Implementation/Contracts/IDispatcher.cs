namespace Exercise_01_Event_Implementation.Contracts
{
    public interface IDispatcher
    {
        string Name { get; set; }
        event NameChangeEventHandler NameChange;
        void OnNameChange(INameChange args);
    }
}
