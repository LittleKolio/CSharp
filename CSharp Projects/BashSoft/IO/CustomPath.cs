namespace BashSoft.IO
{
    using System.IO;

    public static class CustomPath
    {
        public static string CurrentPath = Directory.GetCurrentDirectory();
        public static void ParenetOfCurrentPath(int step)
        {
            for (int i = 0; i < step; i++)
            {
                CurrentPath = Directory
                    .GetParent(CurrentPath)
                    .ToString();
            }
        }

        public static void CreateDirectory(string folderName)
        {
            string path = CurrentPath + "\\" + folderName;
            Directory.CreateDirectory(path);
        }

        public static void ChangePath(string newPath)
        {
            CurrentPath = newPath;
        }
    }
}
