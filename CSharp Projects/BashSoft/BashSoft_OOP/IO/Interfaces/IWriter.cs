namespace BashSoft_OOP.IO.Interfaces
{
    using System.Collections.Generic;

    public interface IWriter
    {
        void WriteMessage(params string[] arguments);

        void WriteOneLineMessage(string message);

        void WriteException(params string[] arguments);

        void WriteAndWait(string message);

        void WriteHelp(List<List<string>> commands);

        void WriteEmptyLine();
    }
}