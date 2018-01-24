namespace Command_Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class IOManager
    {
        public static void TraversingFileSystem(string path)
        {
            Queue<string> fileSystem = new Queue<string>();
            fileSystem.Enqueue(path);

            int depth = 0;
            while (fileSystem.Count > 0)
            {
                string currentPath = fileSystem.Dequeue();
                Console.WriteLine(new string(' ', depth) +
                    currentPath);

                try
                {
                    string[] directories = Directory.GetDirectories(currentPath);
                    string[] files = Directory.GetFiles(currentPath);

                    foreach (string dir in directories)
                    {
                        fileSystem.Enqueue(dir);
                    }

                    foreach (string file in files)
                    {
                        //string fileName = file.Substring(
                        //        file.LastIndexOf("\\") + 1);


                        Console.WriteLine(new string(' ', depth) +
                            file);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                Console.WriteLine();
            }
        }
    }
}
