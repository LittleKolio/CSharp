using System;
using System.Collections.Generic;

namespace Logger
{
    public class StartUp
    {
        public static void Main()
        {
            ILogger logger = CreateLogger();

            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static ILogger CreateLogger()
        {
            AppenderFactory appenderFactory = new AppenderFactory();
            LayoutFactory layoutFactory = new LayoutFactory();

            List<IAppender> appenders = new List<IAppender>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = SplitInput(Console.ReadLine(), " ");

                string appenderType = tokens[0];
                ILayout layout = layoutFactory.CreateLayout(tokens[1]);
                ErrorLevel level = ErrorLevel.INFO;

                if (tokens.Length == 3 && 
                    !Enum.TryParse(tokens[2], out level))
                {
                    throw new ArgumentException("Invalide Level Type!");
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, layout, level);
                appenders.Add(appender);
            }

            return new Logger(appenders);
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
