using System;

namespace Logger
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger)
        {
            this.logger = logger;
            this.errorFactory = new ErrorFactory();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = SplitInput(input, "|");

                IError error = this.errorFactory.CreateErrorMessages(
                    tokens[0], tokens[1], tokens[2]);

                this.logger.ChoseAppender(error);
            }

            Console.WriteLine(this.logger);
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
