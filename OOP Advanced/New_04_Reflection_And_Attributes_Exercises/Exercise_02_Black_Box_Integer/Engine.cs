namespace Exercise_02_Black_Box_Integer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private Type type;
        private BlackBoxInteger blackBox;

        public Engine()
        {
            this.type = typeof(BlackBoxInteger);
            this.blackBox = (BlackBoxInteger)Activator
                .CreateInstance(this.type, true);
        }

        public void Run()
        {
            string input;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] tokens = this.SplitInput(input, "_");

                this.InvokeMethod(tokens);

                string result = this.InnerState();

                Console.WriteLine(result);
            }
        }

        private string InnerState()
        {
            return this.type
                .GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(this.blackBox)
                .ToString();
        }

        private void InvokeMethod(string[] tokens)
        {
            string methodName = tokens[0];
            int value = int.Parse(tokens[1]);

            MethodInfo method = this.type.GetMethod(
                methodName, BindingFlags.Instance | BindingFlags.NonPublic);

            method.Invoke(this.blackBox, new object[] { value });
        }

        private string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
