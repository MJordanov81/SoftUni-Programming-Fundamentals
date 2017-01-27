using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Fold_and_Sum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbersResult = new int[numbers.Length / 2];
            for (int i = 0; i < numbers.Length / 4; i++)
            {
                numbersResult[i] = numbers[(numbers.Length / 4) - 1 - i] + numbers[(numbers.Length / 4) + i];
                numbersResult[(numbersResult.Length / 2) + i] = numbers[numbers.Length - 1 - i] + numbers[(numbers.Length / 2) + i];
            }

            Console.WriteLine(string.Join(" ", numbersResult));
        }
    }
}
