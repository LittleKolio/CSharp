namespace Simple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class UnionAndItersect
    {
        static void Main()
        {
            List<int> firstList = new List<int>();
            firstList.Add(1);
            firstList.Add(2);
            firstList.Add(3);
            firstList.Add(4);
            firstList.Add(5);

            Console.Write("firstlist = ");
            PrintList(firstList);

            List<int> secondList = new List<int>();
            secondList.Add(2);
            secondList.Add(4);
            secondList.Add(6);

            Console.Write("secondlist = ");
            PrintList(secondList);

            List<int> unionList = new List<int>();
            unionList.AddRange(firstList);
            for (int i = unionList.Count - 1; i >= 0; i--)
            {
                if (secondList.Contains(unionList[i]))
                {
                    unionList.RemoveAt(i);
                }
            }
            unionList.AddRange(secondList);

            Console.Write("unionlist = ");
            PrintList(unionList);

            List<int> intersectList = new List<int>();
            intersectList.AddRange(firstList);
            for (int i = intersectList.Count - 1; i >= 0; i--)
            {
                if (!secondList.Contains(intersectList[i]))
                {
                    intersectList.RemoveAt(i);
                }
            }

            Console.Write("intersectlist = ");
            PrintList(intersectList);
        }

        //static void Main()
        //{
        //    List<int> firstList = new List<int>();
        //    firstList.Add(1);
        //    firstList.Add(2);
        //    firstList.Add(3);
        //    firstList.Add(4);
        //    firstList.Add(5);

        //    Console.Write("firstlist = ");
        //    PrintList(firstList);

        //    List<int> secondList = new List<int>();
        //    secondList.Add(2);
        //    secondList.Add(4);
        //    secondList.Add(6);

        //    Console.Write("secondlist = ");
        //    PrintList(secondList);

        //    List<int> unionList = Union(firstList, secondList);
        //    Console.Write("unionlist = ");
        //    PrintList(unionList);

        //    List<int> intersectList = Intersection(firstList, secondList);
        //    Console.Write("intersectlist = ");
        //    PrintList(intersectList);
        //}

        public static List<int> Union(List<int> firstList, List<int> secondList)
        {
            List<int> union = new List<int>();
            union.AddRange(firstList);
            foreach (var item in secondList)
            {
                if (!union.Contains(item))
                {
                    union.Add(item);
                }
            }
            return union;
        }

        public static List<int> Intersection(List<int> firstList, List<int> secondList)
        {
            List<int> intersection = new List<int>();
            foreach (var item in firstList)
            {
                if (secondList.Contains(item))
                {
                    intersection.Add(item);
                }
            }
            return intersection;
        }

        public static void PrintList(List<int> list)
        {
            Console.Write("{ ");
            foreach (var item in list)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine("}");
        }
    }
}
