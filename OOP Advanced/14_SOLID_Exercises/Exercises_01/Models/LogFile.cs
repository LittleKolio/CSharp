
namespace SOLID_Exercises.Exercises_01.Models
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;


    public class LogFile
    {
        private const string path = "log.txt";
        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size { get; private set; }

        private int LettersSum(string message)
        {
            return message
                .Where(c => char.IsLetter(c))
                .Sum(c => c);
        }

        public void Write(string message)
        {
            this.sb.AppendLine(message);
            File.AppendAllText(path, message + Environment.NewLine);
            this.Size = this.LettersSum(message);
        }
    }
}
