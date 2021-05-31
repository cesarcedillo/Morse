using Morse.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Morse
{
    class Program
    {
        private static List<string> words = new List<string>();
        private static int numThreads = 0;

        static void Main(string[] args)
        {
            string morseSentence =   ".--..-..-.-.-----.-----....--...-.-.-..-....--.-......----.";
            words = new List<string>(Resources.words.ToUpper().Split('\n'));
            var initValue = new DecodeSentence();
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();
            var results = Decode(initValue, morseSentence);
            timeMeasure.Stop();
            Console.WriteLine($"Time: {timeMeasure.Elapsed.TotalMilliseconds / 1000} s -- Number of threads: {numThreads}");
            Console.WriteLine("-----RESULTS-----");
            foreach (var result in results)
            {
                Console.WriteLine(result.ToString());
            }
            Console.ReadLine();
        }

        static List<DecodeSentence> Decode(DecodeSentence initValue, string morseString)
        {
            var returnValues = new List<DecodeSentence>();
            var iterator = "";
            var length = morseString.Length - initValue.Position;
            if (length > 4)
            {
                length = 4;
            }
            var decodeString = morseString.Substring(initValue.Position, length);
            List<Task<List<DecodeSentence>>> tasks = new();
            for (var i = 1; i <= decodeString.Length; i++)
            {
                iterator = decodeString.Substring(0, i);
                var candidate = Util.morseCode.Where((m) => m.Key == iterator).FirstOrDefault();
                if (String.IsNullOrEmpty(candidate.Value)) continue;
                var cloneValue = (DecodeSentence)initValue.Clone();
                cloneValue.Value += candidate.Value;
                cloneValue.Position += i;
                if (words.Where((w) => w == cloneValue.Value).Count() == 1)
                {
                    cloneValue.Sentence += $" {cloneValue.Value}";
                    cloneValue.Value = "";
                    if (cloneValue.Position == morseString.Length)
                    {
                        cloneValue.Sentence = cloneValue.Sentence.Substring(1, cloneValue.Sentence.Length - 1);
                        returnValues.Add(cloneValue);
                        continue;
                    }
                }
                if (words.Where((w) => w.StartsWith(cloneValue.Value)).Any())
                {
                    tasks.Add(Task.Run(() => Decode(cloneValue, morseString)));
                    numThreads++;
                }
            }
            Task.WaitAll(tasks.ToArray());
            foreach (var task in tasks)
            {
                returnValues.AddRange(task.Result);
            }
            return returnValues;
        }
    }
}
