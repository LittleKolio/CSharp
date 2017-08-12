namespace SOLID_Exercises.Exercises_01.Models.Appenders
{
    using SOLID_Exercises.Exercises_01.Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AppenderFactory
    {
        public IAppender GetAppender(string appenderName, ILayout layout)
        {
            Type appenderType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == appenderName);

            return (IAppender)Activator.CreateInstance(appenderType, layout);
        }
    }
}
