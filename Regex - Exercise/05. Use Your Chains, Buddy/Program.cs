using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _05.Use_Your_Chains__Buddy
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"<p>(.*?)<\/p>";
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);

            var listMatches = new List<string>();

            foreach (Match match in matches)
            {
                string text = match.Groups[1].ToString();
                text = Regex.Replace(text, @"[^a-z0-9]+", " ");
                text = Regex.Replace(text, @"\s+", " ");

                listMatches.Add(text);
                
            }

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < listMatches.Count; i++)
            {

                for (int j = 0; j < listMatches[i].Length; j++)
                {
                    if (listMatches[i][j] >= 'a' && listMatches[i][j] <= 'm')
                    {
                        stringBuilder.Append((char)(listMatches[i][j] + 13));
                    }

                    else if (listMatches[i][j] >= 'n' && listMatches[i][j] <= 'z')
                    {
                        stringBuilder.Append((char)(listMatches[i][j] - 13));
                    }

                    else
                    {
                        stringBuilder.Append((char)listMatches[i][j]);
                    }
                }
            }

            var result = string.Join(" ", stringBuilder.ToString());

            Console.WriteLine(result);
        }
    }
}
