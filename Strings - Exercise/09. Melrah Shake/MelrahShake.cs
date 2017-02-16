using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Melrah_Shake
{
    public class MelrahShake
    {
        public static void Main()
        {
            var inputText = Console.ReadLine();
            var pattern = Console.ReadLine();

            var textOutput = new List<string>();

            do
            {
                var firstIndex = inputText.IndexOf(pattern);
                var lastIndex = inputText.LastIndexOf(pattern);

                if ((firstIndex != -1 && lastIndex != -1) && (firstIndex != lastIndex))
                {
                    inputText = inputText
                        .Remove(firstIndex, pattern.Length)
                        .Remove(lastIndex - pattern.Length, pattern.Length);

                    textOutput.Add("Shaked it.");
                }

                else
                {
                    break;
                }

                pattern = pattern.Remove(pattern.Length / 2, 1);
             
            } while (pattern != string.Empty);

            textOutput.Add("No shake.");
            textOutput.Add(inputText);

            foreach (var line in textOutput)
            {
                Console.WriteLine(line);
            }
        }
    }
}
