using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.Extract_sentences_by_keyword
{
    public class ExtractSentencesKeyword
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var input = Console.ReadLine().Insert(0, " ").Split(new [] {'.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);

            var pattern = @"(\b)" + word + @"(\b)";

            var result = new List<string>();
            foreach (var sentence in input)
            {
                var isContained = Regex.IsMatch(sentence, pattern);

                if (isContained)
                {
                    result.Add(sentence.Trim());
                }
            }

            Console.WriteLine(string.Join("\n", result));

        }
    }
}
