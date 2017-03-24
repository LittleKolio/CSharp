namespace EFCommandPatternReflection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    public class CommandParser
    {
        private Dictionary<string, Command> commands;
        public CommandParser()
        {
            this.commands = new Dictionary<string, Command>();
            this.Initialize();
        }

        public Command Parse(string key, MyData data)
        {
            if (this.commands.ContainsKey(key))
            {
                return this.commands[key].Create(data);
            }
            else
            {
                return new CommandNotFound(null);
            }
        }

        private void Initialize()
        {
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => 
                    t.CustomAttributes.Any(a => 
                        a.AttributeType == typeof(CommandAttribute)));

            foreach (var t in types)
            {
                var at = t.GetCustomAttributes(true).First() as CommandAttribute;
                //Console.WriteLine(at.commandStr);
                var keyWord = at.commandStr;

                this.commands.Add(keyWord, (Command)Activator.CreateInstance(t));
            }

            //foreach (var t in types)
            //{
            //    Console.WriteLine(t.FullName);
            //    foreach (var a in t.CustomAttributes)
            //    {
            //        Console.WriteLine(a.AttributeType == typeof(CommandAttribute));
            //    }
            //    Console.WriteLine("--------------------");
            //}
        }
    }
}
