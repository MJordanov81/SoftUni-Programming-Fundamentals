using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var maxLenght = 0;
            var indexOfMaxLenght = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentLenght = 0;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j - 1] == numbers[j])
                    {
                        currentLenght++;
                    }

                    else
                    {
                        break;
                    }
                }

                if (currentLenght > maxLenght)
                {
                    maxLenght = currentLenght;
                    indexOfMaxLenght = i;
                }

                currentLenght = 0;
            }

            for (int i = indexOfMaxLenght; i < indexOfMaxLenght + maxLenght + 1; i++)
            {
                Console.Write(numbers[i] + " ");
            }

        }
    }
}
