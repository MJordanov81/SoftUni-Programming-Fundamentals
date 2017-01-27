using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join(", ", GetPrimesList(startNumber, endNumber)));
        }

        public static List<int> GetPrimesList (int start, int end)
        {
            List<int> primes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                bool isPrime = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        continue;
                    }
                }

                if (isPrime)
                {
                    primes.Add(i);
                }   
            }

            return primes;
        }
    }
}
