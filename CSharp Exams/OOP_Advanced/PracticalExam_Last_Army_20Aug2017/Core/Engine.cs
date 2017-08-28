using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Engine
{
    private const string Terminator = "Enough! Pull back!";
    private IGameController gameController;
    private MethodInfo[] methods;
    private StringBuilder result;

    public Engine(IGameController gameController)
    {
        this.gameController = gameController;
        this.methods = this.gameController
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

            string methodResult = string.Empty;

            try
            {
                //methodResult = methodToInvoke.Invoke(this.gameController, parsedParams);
            }
            catch (ArgumentException arg)
            {
                methodResult = arg.Message;
            }

            this.result.AppendLine(methodResult);
        }

        //gameController.RequestResult(result);
        ConsoleWriter.WriteLine(result.ToString());
    }
}