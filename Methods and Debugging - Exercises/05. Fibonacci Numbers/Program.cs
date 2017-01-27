using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFib(n));
        }

        public static int CalculateFib(int n)
        {
            int previosNumber = 1;
            int currentNumber = 1;
            int FibonacciNumber = 0;

            for (int i = 0; i < n-1; i++)
            {
                FibonacciNumber = previosNumber + currentNumber;

                previosNumber = currentNumber;
                currentNumber = FibonacciNumber;
            }

            return currentNumber;
        }
    }
}
