using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());

            IsMasterNumber(lastNumber);
        }


        public static bool IsPalindrome(int number)
        {
            string regularNumber = number.ToString();
            char[] reversedNumber = regularNumber.ToCharArray();
            Array.Reverse(reversedNumber);

            bool equalNumbers = true;
            int currentChar = 0;

            foreach (var character in regularNumber)
            {
                if (character != reversedNumber[currentChar])
                {
                    equalNumbers = false;
                }
                currentChar++;
            }

            return equalNumbers;
        }

        public static bool IsDevidedBySeven(int number)
        {
            bool isDevided = false;
            var sum = 0;

            foreach (var digit in number.ToString())
            {
                sum += digit - '0';
            }

            if (sum % 7 == 0)
            {
                isDevided = true;
            }

            return isDevided;
        }

        public static bool HasEvenDigit(int number)
        {
            bool hasEvenDigit = false;

            foreach (var digit in number.ToString())
            {
                if (Convert.ToInt32(digit.ToString()) % 2 == 0)
                {
                    hasEvenDigit = true;
                }
            }

            return hasEvenDigit;
        }


        public static void IsMasterNumber(int number)
        {

            for (int i = 1; i <= number; i++)
            {
                if (!IsPalindrome(i) || !HasEvenDigit(i) || !IsDevidedBySeven(i))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
