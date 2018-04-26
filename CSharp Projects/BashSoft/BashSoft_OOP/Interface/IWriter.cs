namespace BashSoft_OOP.Interface
{
    public interface IWriter
    {
        //Console
        void WriteMessage(params string[] arguments);
        void WriteException(params string[] arguments);

        //File
        //void WriteMessage(string message, string path);
        //void WriteOneLineMessage(string message, string path);
        //void WriteException(string message, string path);

        void WriteEmptyLine();
    }
}