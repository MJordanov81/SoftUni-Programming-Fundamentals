using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var difference = int.Parse(Console.ReadLine());

            var count = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (difference == Math.Abs(numbers[i] - numbers[j]))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);

        }
    }
}
