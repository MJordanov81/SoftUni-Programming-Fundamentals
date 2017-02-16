using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Letters_Change_Numbers
{
    public class LettersChangeNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new [] {'\t', ' '}, StringSplitOptions.RemoveEmptyEntries);

            var sum = 0m;

            foreach (var oneString in input)
            {

                var firstLetter = oneString[0];
                var lastLetter = oneString[oneString.Length - 1];
                var numberString = oneString.Remove(0, 1);
                numberString = numberString.Remove(numberString.Length - 1, 1);

                var number = decimal.Parse(numberString);

                if (char.IsUpper(firstLetter))
                {
                    number /= firstLetter - 'A' + 1;
                }

                else
                {
                    number *= firstLetter - 'a' + 1;
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= lastLetter - 'A' + 1;
                }

                else
                {
                    number += lastLetter - 'a' + 1;
                }

                sum += number;
            }

            Console.WriteLine("{0:f2}", sum);
        }
    }
}
