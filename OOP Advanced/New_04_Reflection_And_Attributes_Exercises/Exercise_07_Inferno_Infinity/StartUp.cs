namespace Exercise_07_Inferno_Infinity
{
    using Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Contracts;
    using IO;

    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureService();

            IEngine engine = serviceProvider.GetService<IEngine>();
            engine.Run();

            //Engine engine = serviceProvider.GetService<Engine>();
            //engine.Run();

        }

        private static IServiceProvider ConfigureService()
        {
            IServiceCollection collection = new ServiceCollection();

            collection.AddSingleton<IReader, InputReader>();
            collection.AddSingleton<IWriter, OutputWriter>();
            collection.AddSingleton<IFormat, FormatInput>();

            collection.AddTransient<IEngine, Engine>();
            //collection.AddTransient<Engine>();

            return collection.BuildServiceProvider();
        }
    }
}
