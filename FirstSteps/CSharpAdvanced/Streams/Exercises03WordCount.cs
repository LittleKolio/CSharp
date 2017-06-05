using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Streams
{
    class Exercises03WordCount
    {
        const string wordsFilePath = "../../Files/wordsForProblem3.txt";
        const string textFilePath = "../../Files/textForProblem3.txt";
        const string resultFilePath = "../../Files/resultsForProblem3.txt";

        static void Main()
        {
            //System.Diagnostics.Stopwatch watch
            //  = new System.Diagnostics.Stopwatch();
            //watch.Start();

            //List<KeyValuePair<string, int>> wordsDic
            //    = new List<KeyValuePair<string, int>>();

            Dictionary<string, int> wordsDic 
                = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                while (true)
                {
                    string word = reader.ReadLine();
                    if (word == null) { break; }

                    if (!wordsDic.ContainsKey(word))
                    {
                        wordsDic.Add(word, 0);
                    }
                }
            }

            using (StreamReader reader = new StreamReader(textFilePath))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null) { break; }

                    string[] wordsArr = line
                        .Split(" ,.-".ToCharArray(),
                            StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < wordsArr.Length; i++)
                    {
                        if (wordsDic.ContainsKey(wordsArr[i]))
                        {
                            wordsDic[wordsArr[i]]++;
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(resultFilePath))
            {
                foreach (var word in wordsDic.OrderByDescending(e => e.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }

            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);
        }
    }
}
