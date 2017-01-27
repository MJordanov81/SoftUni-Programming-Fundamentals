using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var maxFrequency = 0;
            var mostFrequentNumber = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                var currentFrequency = 0;

                for (int j = numbers.Length - 1; j >= 0; j--)
                {
                    if (numbers[i] == numbers[j])
                    {
                        currentFrequency++;
                    }
                }

                if (currentFrequency >= maxFrequency)
                {
                    maxFrequency = currentFrequency;
                    mostFrequentNumber = numbers[i];
                }
            }

            Console.WriteLine(mostFrequentNumber);
        }
    }
}
