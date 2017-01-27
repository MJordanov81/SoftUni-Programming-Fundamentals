using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());

            var numbers = new int[n - 1];


            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 2;
            }


            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (numbers[j] % numbers[i] == 0)
                        {
                            numbers[j] = 0;
                        }
                    }
                }
            }

            foreach (var character in numbers)
            {
                if (character != 0)
                {
                    Console.Write(character + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
