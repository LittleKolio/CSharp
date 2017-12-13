namespace Simple
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class TraverseDirectory_DFS
    {
        public static void Traverse(DirectoryInfo dir, string space)
        {
            Console.WriteLine(space + dir.FullName);

            DirectoryInfo[] children = dir.GetDirectories();
            foreach (DirectoryInfo cild in children)
            {
                Traverse(cild, space + "  ");
            }
        }

        public static void Traverse(string path)
        {
            Traverse(new DirectoryInfo(path), string.Empty);
        }
    }
}
