namespace BashSoft2
{
    public class Launcher
    {
        public static void Main()
        {
            //string projects = @"D:\Repository\CSharp\CSharp Projects";
            //SessionData.ChangeCurrentFolder(projects);
            //IOManager.TraversingCurrentDirectory(3);

            //string path = @"../../Resources/data.txt";
            //StudentsRepository.InitializeData(path);
            //StudentsRepository.GetAllStudents("Unity");

            //IOManager.CreateDirectoryInCurrentFolder("TestDirectory");

            InputReader.StartReadingCommands();
        }
    }
}
