namespace Exercise_08_Create_User
{
    using System;
    using System.Collections.Generic;
    //---------------------
    using System.Data.SqlTypes;
    using System.IO;

    public class Util
    {
        /*
        public static SqlBytes f_ckingFile_2(string path)
        {
            SqlBytes file;

            var stream = File.OpenRead(path);
            using (stream)
            {
                file = new SqlBytes(stream);
            }
            return file;
        }
        */

        public static byte[] f_ckingFile(string path)
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

            /*
            float aspectRatio;
            string tempDirectory;
            int autoSaveTime;
            bool showStatusBar;

            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    aspectRatio = reader.ReadSingle();
                    tempDirectory = reader.ReadString();
                    autoSaveTime = reader.ReadInt32();
                    showStatusBar = reader.ReadBoolean();
                }

                Console.WriteLine("Aspect ratio set to: " + aspectRatio);
                Console.WriteLine("Temp directory is: " + tempDirectory);
                Console.WriteLine("Auto save time set to: " + autoSaveTime);
                Console.WriteLine("Show status bar: " + showStatusBar);
            }
            */
        }

        public static void readTheF_ckingFile(string path, byte[] file)
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

            /*
            string ext = "";
            string tempFile = Path.Combine(@"C:\Temp\Blobs\",
                Path.GetFileNameWithoutExtension(Path.GetTempFileName()));

            ext = rdr.GetString(2);
            File.WriteAllBytes(tempFile + ext, (byte[])rdr["itemData"]);

            // OS run test
            Process prc = new Process();
            prc.StartInfo.FileName = tempFile + ext;
            prc.Start();
            */

            /*
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                writer.Write(1.250F);
                writer.Write(@"c:\Temp");
                writer.Write(10);
                writer.Write(true);
            }
            */
        }
    }
}
