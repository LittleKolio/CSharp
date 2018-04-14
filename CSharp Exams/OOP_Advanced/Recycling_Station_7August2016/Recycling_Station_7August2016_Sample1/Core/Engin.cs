namespace RecyclingStation.Core
{
    using IO;
    using global::RecyclingStation.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class Engin
    {
        private const string Terminator = "TimeToRecycle";
        private readonly MethodInfo[] stationMethods;

        private IReader read;
        private IWriter write;
        private IRecyclingManager manager;

        public Engin(IReader read, IWriter write, IRecyclingManager station)
        {
            this.read = read;
            this.write = write;
            this.manager = station;
            this.stationMethods = this.manager
                .GetType()
                .GetMethods();
        }

        private string[] SplitCommand(string input, params char[] splitBy)
        {
            return input
                .Split(splitBy, StringSplitOptions.RemoveEmptyEntries);
        }

        public void Run()
        {
            string input;
            while ((input = this.read.ConsoleReadLine()) != Terminator)
            {
                string[] tokens = SplitCommand(input, ' ');
                string[] garbageParams = default(string[]); // null
                if (tokens.Length == 2)
                {
                    garbageParams = SplitCommand(tokens[1], '|');
                }

                MethodInfo methodToInvoke = stationMethods
                    .FirstOrDefault(
                        m => m.Name.Equals(tokens[0], StringComparison.OrdinalIgnoreCase));

                ParameterInfo[] methodParams = methodToInvoke.GetParameters();

                object[] parsedParams = new object[methodParams.Length];
                for (int i = 0; i < methodParams.Length; i++)
                {
                    Type type = methodParams[i].ParameterType;
                    parsedParams[i] = Convert.ChangeType(garbageParams[i], type);
                }

                object result = methodToInvoke.Invoke(this.manager, parsedParams);

                this.write.AppendMessage(result.ToString());
            }

            this.write.ConsoleWrite();
        }
    }
}
