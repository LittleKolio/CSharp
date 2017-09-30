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

        public static void TraverseFolder(int depth)
        {
            OutputWriter.WriteEmptyLine();

            int folderDepth = CustomPath.CurrentPath.Split('\\').Length;

            Stack<string> folders = new Stack<string>();
            folders.Push(CustomPath.CurrentPath);

            while (folders.Count != 0)
            {
                string currentPath = folders.Pop();
                int currentDepth = currentPath.Split('\\').Length - folderDepth;
                if (currentDepth > depth)
                {
                    break;
                }

                OutputWriter.WriteOneLineMessage(
                    '\u251C' + 
                    new string('\u2500', currentDepth) + 
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
                            new string(' ', currentDepth + 1) + "\u2514\u2500 " +
                            fileName);
                    }
                }

                /**
                 * An UnauthorizedAccessException exception
                 * will be thrown if we do not have
                 * discovery permission on a folder or file.
                 */
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.WriteExeption(
                        CustomMessages.UnauthorizedAccess);
                    continue;
                }

                /**
                 * It is also possible (but unlikely) that a
                 * DirectoryNotFound exception will be raised.
                 * This will happen if currentDir has been deleted by
                 * another application or thread after our call to TraverseFolder().
                 */
                catch (DirectoryNotFoundException ex)
                {
                    OutputWriter.WriteExeption(ex.Message);
                    continue;
                }
            }
        }
    }
}
