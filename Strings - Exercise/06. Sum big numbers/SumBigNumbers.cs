using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sum_big_numbers
{
    public class SumBigNumbers
    {
        public static void Main()
        {
            var inputNumberOne = Console.ReadLine();
            var inputNumberTwo = Console.ReadLine();

            if (inputNumberTwo.Length > inputNumberOne.Length)
            {
                var tempString = inputNumberOne;
                inputNumberOne = inputNumberTwo;
                inputNumberTwo = tempString;
            }

            if (inputNumberOne.Length > inputNumberTwo.Length)
            {
                var difference = inputNumberOne.Length - inputNumberTwo.Length;

                inputNumberTwo = inputNumberTwo.Insert(0, new string('0', difference));
            }

            var result = GetSum(inputNumberOne, inputNumberTwo);

            Console.WriteLine(result.TrimStart('0'));
        }

        public static string GetSum(string numberOne, string numberTwo)
        {
            var sum = string.Empty;

            var charArrOne = numberOne.ToCharArray();
            var charArrTwo = numberTwo.ToCharArray();

            var remainder = 0;

            for (int i = charArrOne.Length - 1; i >= 0; i--)
            {
                var currentSum = int.Parse(Convert.ToString(charArrOne[i])) + int.Parse(Convert.ToString(charArrTwo[i])) + remainder;

                if (currentSum >= 10)
                {
                    currentSum = currentSum % 10;
                    remainder = 1;
                }

                else
                {
                    remainder = 0;
                }

                sum = sum.Insert(0, currentSum.ToString());
            }

            if (remainder > 0)
            {
                sum = sum.Insert(0, remainder.ToString());
            }

            return sum;
        }
    }
}
