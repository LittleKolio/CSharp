namespace Interfaces_And_Abstraction_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_09_Collection_Hierarchy
    {
        static void Main()
        {
            IAddCollection addColl = new AddCollection();
            IAddRemoveCollection addRemColl = new AddRemoveCollection();
            IMyList myList = new MyList();

            string[] input = Console.ReadLine()
                .Split(' ');
            int operations = int.Parse(Console.ReadLine());

            AddElement<IAddCollection>(addColl, input);
            AddElement<IAddRemoveCollection>(addRemColl, input);
            AddElement<IMyList>(myList, input);

            RemoveElement<IAddRemoveCollection>(addRemColl, operations);
            RemoveElement<IMyList>(myList, operations);
        }

        private static void RemoveElement<T>(T collectoin, int operatons)
            where T : IAddRemoveCollection
        {
            StringBuilder sb = new StringBuilder();

            for (var i = 0; i < operatons; i++)
            {
                sb.Append(collectoin.Remove() + " ");
            }

            Console.WriteLine(sb);
        }

        private static void AddElement<T>(T collectoin, string[] input)
            where T : IAddCollection
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in input)
            {
                sb.Append(collectoin.Add(item) + " ");
            }

            Console.WriteLine(sb);
        }
    }
}
