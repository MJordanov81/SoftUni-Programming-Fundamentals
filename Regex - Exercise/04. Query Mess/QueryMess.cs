using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.Query_Mess
{
    public class QueryMess
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var result = new List<string>();

            while (input != "END")
            {

                var inputArray = input.Split(new[] { '&', '?' }, StringSplitOptions.RemoveEmptyEntries);

                var pattern = @"^.+?=.+$";
                var regex = new Regex (pattern);
                var listMatches = new List<string>();


                foreach (var pair in inputArray)
                {
                    if (Regex.IsMatch(pair, pattern))
                    {
                        listMatches.Add(pair.Replace("+", " ").Replace("%20", " ").Trim());
                    }
                }

                for (int i = 0; i < listMatches.Count; i++)
                {
                    var spaces = @"\s+";
                    Regex regexSpace = new Regex(spaces);
                    listMatches[i] = regexSpace.Replace(listMatches[i], " ");
                }

                var dictionary = new Dictionary<string, List<string>>();

                foreach (var pair in listMatches)
                {
                    var keyValue = pair.Split('=').Select(x => x.Trim()).ToArray();

                    if (!dictionary.ContainsKey(keyValue[0]))
                    {
                        dictionary[keyValue[0]] = new List<string>();
                    }

                    dictionary[keyValue[0]].Add(keyValue[1]);
                }

                var stringBuilder = new StringBuilder();

                foreach (var pair in dictionary)
                {
                    stringBuilder.Append(pair.Key + "=[" + string.Join(", ", pair.Value) + "]");

                }

                result.Add(stringBuilder.ToString());

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}
