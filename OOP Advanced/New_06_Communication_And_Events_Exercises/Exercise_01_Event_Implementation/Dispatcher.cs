namespace Exercise_01_Event_Implementation
{
    using Contracts;

    public delegate void NameChangeEventHandler(object sender, INameChange args);

    public class Dispatcher : IDispatcher
    {
        public event NameChangeEventHandler NameChange;
        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }

        public void OnNameChange(INameChange args)
        {
            //if (this.NameChange != null)
            //{
            //    this.NameChange(this, args);
            //}

            this.NameChange?.Invoke(this, args);
        }
    }
}