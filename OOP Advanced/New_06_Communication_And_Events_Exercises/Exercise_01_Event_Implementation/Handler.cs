namespace Exercise_01_Event_Implementation
{
    using Contracts;
    using System;
    public class Handler : IHandler
    {
        public void OnDispatcherNameChange(object sender, INameChange args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}
