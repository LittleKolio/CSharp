namespace SOLID_Exercises.Exercises_01
{
    using SOLID_Exercises.Exercises_01.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_01_Logger
    {
        public static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender =
                 new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
