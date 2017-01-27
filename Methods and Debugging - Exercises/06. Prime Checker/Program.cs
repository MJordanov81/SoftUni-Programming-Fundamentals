using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(isPrime(number));
        }

        public static bool isPrime(long number)
        {
            bool isPrime = true;

            if (number <= 1)
            {
                isPrime = false;
                return isPrime;
            }

            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        continue;
                    }
                }

                return isPrime;
            }
        }
    }
}
