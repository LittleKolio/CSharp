namespace StudentSystem.Util
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.IO;

    public class Util
    {
        public static byte[] insertFile(string path)
        {
            byte[] file;
            var stream = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read
            );
            using (stream)
            {
                var reader = new BinaryReader(stream);
                using (reader)
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
            return file;
        }

        public static void readFile(string path, byte[] file)
        {
            var stream = new FileStream(
                path,
                FileMode.Create,
                FileAccess.Write
            );
            using (stream)
            {
                var writer = new BinaryWriter(stream);
                using (writer)
                {
                    writer.Write(file);
                }
            }
        }
    }
}
