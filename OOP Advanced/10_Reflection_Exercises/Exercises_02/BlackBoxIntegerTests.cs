namespace Reflection_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        //private const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        public static void Main()
        {
            Type testType = typeof(BlackBoxInt);

            //ConstructorInfo ctorType = testType.GetConstructor(
            //    BindingFlags.Instance | 
            //    BindingFlags.NonPublic,
            //    Type.DefaultBinder,
            //    new Type[] { },
            //    null
            //    );
            //BlackBoxInt blackBox = ctorType.Invoke(new object[] { });

            BlackBoxInt blackBox = (BlackBoxInt)Activator
                .CreateInstance(testType, true);



            //Dictionary < string, int> 

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('_');
                string methodName = tokens[0];
                int value = int.Parse(tokens[1]);

                testType.GetMethod(
                    methodName, 
                    BindingFlags.Instance | 
                    BindingFlags.NonPublic)
                    .Invoke(blackBox, new object[] { value });

                string innerState = testType
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First()
                    .GetValue(blackBox)
                    .ToString();

                Console.WriteLine(innerState);
            }
        }
    }
}
