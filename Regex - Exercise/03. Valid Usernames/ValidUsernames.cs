using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Valid_Usernames
{
    public class ValidUsernames
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var matches = new List<string>();

            var pattern = @"^[a-zA-Z]\w{2,24}$";


            for (int i = 0; i < input.Length; i++)
            {
                if (Regex.IsMatch(input[i], pattern) )
                {
                    matches.Add(input[i]);
                }
            }
            
            var maxLength = int.MinValue;
            var firstUsername = string.Empty;
            var secondUsername = string.Empty;

            for (int i = 0; i < matches.Count-1; i++)
            {
                var currentLength = matches[i].Length + matches[i + 1].Length;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    firstUsername = matches[i];
                    secondUsername = matches[i + 1];                
                }
            }

            Console.WriteLine(firstUsername);
            Console.WriteLine(secondUsername);
        }
    }
}
