using System;
using System.Numerics;

namespace Factorial
{
    class Factorial
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            BigInteger value = RandomNumberFactorial(n);
            Console.WriteLine(value);
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
    }
}
