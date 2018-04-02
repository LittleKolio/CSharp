namespace Exercise_06_Traffic_Lights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static void Main()
        {
            List<LightSignal> signals = new List<LightSignal>();

            string[] line = SplitInput(Console.ReadLine(), " ");

            for (int i = 0; i < line.Length; i++)
            {
                Light light = (Light)Enum.Parse(typeof(Light),line[i]);
                signals.Add(new LightSignal(light));
            }

            int num = int.Parse(Console.ReadLine());

            //Console.WriteLine(string.Join(" ", signals.Select(s => s.Light)));

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < signals.Count; j++)
                {
                    signals[j].ChangeLight();
                }
                Console.WriteLine(string.Join(" ", signals.Select(s => s.Light)));
            }
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
