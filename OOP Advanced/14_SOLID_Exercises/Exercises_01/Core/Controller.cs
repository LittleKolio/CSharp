namespace SOLID_Exercises.Exercises_01.Core
{
    using Enums;
    using Interfaces;
    using Models;
    using Models.Appenders;
    using Models.Layouts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Controller
    {
        private LayoutFactory layoutFactory;
        private AppenderFactory appenderFactory;
        private ILogger logger;

        public Controller(LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
        }

        public void SendMessageToLogger(string message)
        {

        }

        public void InitilizeLogger(IReader reader)
        {
            IAppender[] appenders = this.ReadAllAppenders(reader);
            this.logger = new Logger(appenders);
        }

        private IAppender[] ReadAllAppenders(IReader reader)
        {
            int num = int.Parse(reader.ConsoleReader());
            IAppender[] appenders = new IAppender[num];

            for (int i = 0; i < num; i++)
            {
                string[] tokens = reader
                    .ConsoleReader()
                    .Split();
                ILayout layout = this.layoutFactory
                    .GetLayout(tokens[1]);
                IAppender appender = this.appenderFactory
                    .GetAppender(tokens[0], layout);
                if (tokens.Length > 2)
                {
                    ReportType reportType = (ReportType)Enum.Parse(typeof(ReportType), tokens[2]);
                    appender.Type = reportType;
                }
                appenders[i] = appender;
            }
            return appenders;
        }
    }
}
