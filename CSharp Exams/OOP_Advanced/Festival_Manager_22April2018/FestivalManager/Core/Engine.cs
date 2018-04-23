
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;
    using Entities.Factories.Contracts;
    using Entities.Contracts;

    class Engine : IEngine
	{
        private IReader reader;
        private IWriter writer;

        private IStage stage;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        private bool isRunning;

        public Engine(
            IFestivalController festivalCоntroller, 
            ISetController setCоntroller,
            IStage stage,
            IReader reader, 
            IWriter writer)
        {
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
            this.stage = stage;
            this.reader = reader;
            this.writer = writer;
            this.isRunning = true;
        }

		public void Run()
		{
            string input = this.reader.ReadLine();
            while (isRunning)
			{
                string result = string.Empty;

				try
				{
					result = this.ProcessCommand(input);
				}
				catch (Exception ex)
				{
                    result = "ERROR: " + ex.Message;
                }

                if (!string.IsNullOrEmpty(result))
                {
                    this.writer.WriteLine(result);
                }

                input = this.reader.ReadLine();

                this.isRunning = this.ShouldEnd(input);
            }

            string end = this.festivalCоntroller.ProduceReport();
            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);

        }

		public string ProcessCommand(string input)
		{
            if (input == "LetsRock")
            {
                return this.setCоntroller.PerformSets();
            }

            string[] tokens = this.SplitInput(input, " ");

			string methodName = tokens[0];

            MethodInfo method = this.festivalCоntroller
                .GetType()
                .GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

            //if (method == null)
            //{
            //    throw new ArgumentException(
            //        "Invalide MethodName!");
            //}

            object[] parameters = new object[] { tokens.Skip(1).ToArray() };

            object result;

            try
            {
                result = method.Invoke(this.festivalCоntroller, parameters);
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }

            return result as string;
        }

        private bool ShouldEnd(string input)
        {
            return !input.Equals("END");
        }

        private string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}