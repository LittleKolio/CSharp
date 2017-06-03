using System;
using System.Collections.Generic;
using System.IO;

namespace Step2
{
    public static class DirectoryTraverser
    {
        /*
        private static void TraversDir(DirectoryInfo dir, string spaces)
        {
            Console.WriteLine(spaces + dir.FullName);
            DirectoryInfo[] children = dir.GetDirectories();
            foreach (var child in children)
            {
                TraversDir(child, spaces + "  ");
            }
        }

        private static void TraversDir(string directoryPath)
        {
            TraversDir(new DirectoryInfo(directoryPath), string.Empty);
        }
        */

        public static void TraversDir(string directoryPath)
        {
            Queue<DirectoryInfo> visitedDirsQueue = new Queue<DirectoryInfo>();
            visitedDirsQueue.Enqueue(new DirectoryInfo(directoryPath));
            while (visitedDirsQueue.Count > 0)
            {
                DirectoryInfo currentDir = visitedDirsQueue.Dequeue();
                Console.WriteLine(currentDir.FullName);

                DirectoryInfo[] children = currentDir.GetDirectories();
                foreach (var child in children)
                {
                    visitedDirsQueue.Enqueue(child);
                }
            }
        }

        public static void Main()
        {
            TraversDir("C:\\");
        }
    }
}
