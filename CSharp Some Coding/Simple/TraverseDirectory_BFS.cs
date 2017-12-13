using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    public static class TraverseDirectory_BFS
    {
        public static void Traverse(string path)
        {
            Queue<DirectoryInfo> directories = new Queue<DirectoryInfo>();

            directories.Enqueue(new DirectoryInfo(path));

            while (directories.Count > 0)
            {
                DirectoryInfo dir = directories.Dequeue();
                Console.WriteLine(dir.FullName);

                DirectoryInfo[] dirChildren = dir.GetDirectories();
                foreach (DirectoryInfo child in dirChildren)
                {
                    directories.Enqueue(child);
                }
            }
        }

    }
}
