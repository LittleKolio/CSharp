namespace SOLID_Exercises.Exercises_01.Models.Layouts
{
    using SOLID_Exercises.Exercises_01.Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class LayoutFactory
    {
        public ILayout GetLayout(string layoutName)
        {
            Type layoutType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == layoutName);
            return (ILayout)Activator.CreateInstance(layoutType);
        }
    }
}
