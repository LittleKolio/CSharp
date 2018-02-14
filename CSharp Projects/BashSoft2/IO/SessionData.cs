namespace BashSoft2.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class SessionData
    {
        public static string currentPath = Directory.GetCurrentDirectory();

        public static string ParenetOfCurrentPath(int step)
        {
            string path = currentPath;
            for (int i = 0; i < step; i++)
            {
                path = Directory
                    .GetParent(path)
                    .ToString();
            }
            return path;

            //int index = path.Length;
            //for (int i = 0; i < step; i++)
            //{
            //    index--;
            //    index = path.LastIndexOf('\\', index);
            //}
            //return path.Substring(0, index);
        }
    }
}
