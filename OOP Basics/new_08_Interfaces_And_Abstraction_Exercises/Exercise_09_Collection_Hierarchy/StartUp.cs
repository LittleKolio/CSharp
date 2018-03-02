using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<CustomCollection> listOfCollections = new List<CustomCollection>
        {
            new AddCollection(),
            new AddRemoveCollection(),
            new MyList()
        };

        string[] input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int numToRemove = int.Parse(Console.ReadLine());

        foreach (IAdd coll in listOfCollections)
        {
            foreach (string item in input)
            {
                Console.Write(coll.Add(item) + " ");
            }
            Console.WriteLine();
        }

        List<IAddRemove> removeList = listOfCollections
            .Select(l => l as IAddRemove)
            .Where(l => l != null)
            .ToList();

        foreach (IAddRemove coll in removeList)
        {
            for (int i = 0; i < numToRemove; i++)
            {
                Console.Write(coll.Remove() + " ");
            }
            Console.WriteLine();
        }
    }
}