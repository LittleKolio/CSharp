namespace BashSoft.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class IOManager
    {
        public static void TraverseFolder(string path)
        {
            OutputWriter.WriteEmptyLine();

            int folderDepth = path.Split('\\').Length;

            Stack<string> folders = new Stack<string>();
            folders.Push(path);

            while (folders.Count != 0)
            {
                string currentPath = folders.Pop();
                int depth = currentPath.Split('\\').Length - folderDepth;

                OutputWriter.WriteOneLineMessage(
                    '\u251C' + 
                    new string('\u2500', depth) + 
                    currentPath);

                try
                {
                    string[] subFolders = Directory.GetDirectories(currentPath);
                    foreach (string folder in subFolders)
                    {
                        folders.Push(folder);
                    }

                    string[] files = Directory.GetFiles(currentPath);
                    foreach (string file in files)
                    {
                        string fileName = file.Substring(
                            file.LastIndexOf("\\") + 1);

                        OutputWriter.WriteOneLineMessage(
                            new string(' ', depth + 1) + "\u2514\u2500 " +
                            fileName);
                    }
                }

                /**
                 * An UnauthorizedAccessException exception
                 * will be thrown if we do not have
                 * discovery permission on a folder or file.
                 */
                catch (UnauthorizedAccessException ex)
                {
                    OutputWriter.WriteOneLineMessage(ex.Message);
                    continue;
                }

                /**
                 * It is also possible (but unlikely) that a
                 * DirectoryNotFound exception will be raised.
                 * This will happen if currentDir has been deleted by
                 * another application or thread after our call to Directory.Exists.
                 */
                catch (DirectoryNotFoundException ex)
                {
                    OutputWriter.WriteOneLineMessage(ex.Message);
                    continue;
                }
            }
        }
    }
}
