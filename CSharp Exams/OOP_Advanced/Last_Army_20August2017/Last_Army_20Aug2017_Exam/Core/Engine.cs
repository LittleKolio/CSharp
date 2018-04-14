using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Engine
{
    private const string Terminator = "Enough! Pull back!";

    private IGameController controller;
    private MethodInfo[] methods;
    private StringBuilder result;

    public Engine(IGameController controller)
    {
        this.controller = controller;
        this.methods = this.controller
            .GetType()
            .GetMethods();
        this.result = new StringBuilder();
    }

    private string[] CustomSplit(string input, params char[] chars)
    {
        return input.Split(chars, StringSplitOptions.RemoveEmptyEntries);
    }

    public void Run()
    {
        string input;
        while ((input = ConsoleReader.ReadLine()).Equals(Terminator))
        {
            string[] tokens = CustomSplit(input, ' ');
            string methodName = tokens[0];

            MethodInfo methodToInvoke = methods.FirstOrDefault(
                m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase)
                );

            ParameterInfo[] methodParams = methodToInvoke.GetParameters();
            object[] parsedParams = new object[methodParams.Length];
            for (int i = 0; i < methodParams.Length; i++)
            {
                Type type = methodParams[i].GetType();
                parsedParams[i] = Convert.ChangeType(tokens[i + 1], type);
            }

            try
            {
                this.result.AppendLine(methodToInvoke
                    .Invoke(this.controller, parsedParams)
                    .ToString()
                    );
            }
            catch (ArgumentException arg)
            {
                this.result.AppendLine(arg.Message);
            }
        }

        //gameController.RequestResult(result);
        ConsoleWriter.WriteLine(result.ToString());
    }
}