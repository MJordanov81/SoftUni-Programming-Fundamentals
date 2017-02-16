using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Character_Multiplier
{
    public class CharacterMultiplier
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var stringOne = input[0];
            var stringTwo = input[1];

            var result = 0;

            if (stringOne.Length == stringTwo.Length)
            {
                result = GetSum(stringOne, stringTwo);
            }

            else if (stringOne.Length > stringTwo.Length)
            {
                result = GetSumNotEqual(stringOne, stringTwo);
            }

            else
            {
                result = GetSumNotEqual(stringTwo, stringOne);
            }

            Console.WriteLine(result);
        }

        public static int GetSum (string stringOne, string stringTwo)
        {
            var result = 0;

            for (int i = 0; i < stringOne.Length; i++)
            {
                result += stringOne[i] * stringTwo[i];
            }

            return result;
        }

        public static int GetSumNotEqual(string stringOne, string stringTwo)
        {
            var result = 0;
            var difference = stringOne.Length - stringTwo.Length;

            result += GetSum(stringOne.Substring(0, stringOne.Length - difference), stringTwo);

            foreach (var letter in stringOne.Substring(stringOne.Length - difference))
            {
                result += letter;
            }

            return result;
        }
    }
}
