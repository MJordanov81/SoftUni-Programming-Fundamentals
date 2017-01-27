using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.English_Name_of_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal inputNumber = decimal.Parse(Console.ReadLine());
            Console.WriteLine(GetNumberName(inputNumber));
        }

        public static string GetNumberName(decimal number)
        {
            string numberToString = number.ToString();
            char lastDigit = numberToString.Last();

            switch (lastDigit)
            {
                case '1': return "one"; break;
                case '2': return "two"; break;
                case '3': return "three"; break;
                case '4': return "four"; break;
                case '5': return "five"; break;
                case '6': return "six"; break;
                case '7': return "seven"; break;
                case '8': return "eight"; break;
                case '9': return "nine"; break;
                case '0': return "zero"; break;
                default: return "default";
                    break;
            }
        }
    }
}
