namespace Defining_Classes_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_14_Cat_Lady
    {
        public static void Main()
        {
            List<Cat> cats = new List<Cat>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                //My assembly name start with "02_" 
                //and the default name dont (they are different) ... F@CK^2
                Type type = Assembly.GetExecutingAssembly().GetType(
                    "Defining_Classes_Exercises." + tokens[0]);

                ParameterInfo[] cmdParams = type
                    .GetConstructors()
                    .FirstOrDefault()
                    .GetParameters();

                object[] paramsArray = new object[cmdParams.Length];

                for (int i = 0; i < cmdParams.Length; i++)
                {
                    Type paramType = cmdParams[i].ParameterType;
                    paramsArray[i] = Convert.ChangeType(tokens[i + 1], paramType);
                }

                Cat cat = (Cat)Activator.CreateInstance(type, paramsArray);
                cats.Add(cat);
            }

            string name = Console.ReadLine();
            Cat findCat = cats.First(c => c.Name == name);
            Console.WriteLine(findCat);
        }
    }
}
