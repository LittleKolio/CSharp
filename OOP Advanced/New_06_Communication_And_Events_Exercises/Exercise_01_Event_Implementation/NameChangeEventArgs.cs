namespace Exercise_01_Event_Implementation
{
    using Contracts;
    using System;

    public class NameChangeEventArgs : EventArgs, INameChange
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
