namespace BashSoft.Core
{
    using Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandController
    {
        private Dictionary<string, ICommand> commandList;
        private List<string> list;

        public CommandController()
        {
            this.list = new List<string>();
            //this.Initialize();
        }

        public ICommand Run(string input)
        {
            this.list = input.Split(new[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = this.list[0];

            Type type = Assembly.
                GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.);

            //if (!commandList.ContainsKey(command))
            //{
            //    return new NotFound(this.list);
            //}
            //else
            //{
            //    return this.commandList[command].Create(this.list);
            //}
        }

        //private void Initialize()
        //{
        //    this.commandList = new Dictionary<string, string>
        //    {
        //        { "mkdir", "CreateDirectorty" },
        //        { "test", new TestCommand() }
        //    };
        //}
    }
}
