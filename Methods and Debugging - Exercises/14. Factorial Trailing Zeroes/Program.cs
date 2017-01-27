using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Factorial
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            BigInteger value = RandomNumberFactorial(n);
            Console.WriteLine(ZeroNumbersString(value));

        }


        public static BigInteger RandomNumberFactorial(int n)
        {
            BigInteger result = 1;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static long ZeroNumbersString(BigInteger factorialNumber)
        {
            string number = Convert.ToString(factorialNumber);
            char[] numberToChar = number.ToCharArray();
            Array.Reverse(numberToChar);

            long zeroCounter = 0;

            foreach (var digit in numberToChar)
            {
                if (digit == '0')
                {
                    zeroCounter++;
                }

                else
                {
                    break;
                }
            }

            return zeroCounter;

        }

        public static BigInteger ZeroNumbers(BigInteger factorialNumber)
        {
            long zeroCounter = 0;
            BigInteger digit = 0;

            while (digit == 0)
            {
                digit = factorialNumber % 10;
                if (digit == 0)
                {
                    zeroCounter++;
                }

                factorialNumber /= 10;
            }

            return zeroCounter;
        }
    }
}
