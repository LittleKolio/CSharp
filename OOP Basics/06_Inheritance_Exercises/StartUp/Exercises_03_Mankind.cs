namespace Inheritance_Exercises.StartUp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_03_Mankind
    {static void Main()
        {
            try
            {
                string[] inputStu = Console.ReadLine().Split(' ');
                Student stu = new Student(inputStu[0], inputStu[1], inputStu[2]);

                string[] inputWor = Console.ReadLine().Split(' ');
                Worker wor = new Worker(
                    inputWor[0],
                    inputWor[1],
                    decimal.Parse(inputWor[2]),
                    int.Parse(inputWor[3]));

                Console.WriteLine(stu);
                Console.WriteLine();
                Console.WriteLine(wor);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
