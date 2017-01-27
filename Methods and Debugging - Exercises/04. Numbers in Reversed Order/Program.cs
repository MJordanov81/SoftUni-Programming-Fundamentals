using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal inputNumber = decimal.Parse(Console.ReadLine());
            Console.WriteLine(ReverseANumber(inputNumber));
        }

        public static string ReverseANumber(decimal number)
        {
            string numberToString = number.ToString();
            char[] numberToChars = numberToString.ToCharArray();
            Array.Reverse(numberToChars);

            numberToString = String.Join("", numberToChars);

            return numberToString;
        }
    }
}
