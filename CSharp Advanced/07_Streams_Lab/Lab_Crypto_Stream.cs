using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Streams_Lab
{
    class Lab_Crypto_Stream
    {
        const string encryptionKey = "ABCDEFGH";
        const string filePath = "../../Files/encryptedText.txt";

        static void Main()
        {
            SaveEncrypted("CSharp Advanced", encryptionKey, filePath);
            string result = Decrypt(encryptionKey, filePath);
            Console.WriteLine(result);
        }

        private static string Decrypt(string key, string path)
        {
            using (FileStream fileStream = new FileStream(
                path, FileMode.Open))
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                cryptoProvider.Key = Encoding.ASCII.GetBytes(key);
                cryptoProvider.IV = Encoding.ASCII.GetBytes(key);

                using (CryptoStream cryptoStream = new CryptoStream(
                    fileStream, cryptoProvider.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cryptoStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        private static void SaveEncrypted(string text, string key, string path)
        {
            using (FileStream destinationStream = new FileStream(
                path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                cryptoProvider.Key = Encoding.ASCII.GetBytes(key);
                cryptoProvider.IV = Encoding.ASCII.GetBytes(key);

                using (CryptoStream cryptoStream = new CryptoStream(
                    destinationStream, cryptoProvider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] data = Encoding.ASCII.GetBytes(text);
                    cryptoStream.Write(data, 0, data.Length);
                }
            }
        }
    }
}
