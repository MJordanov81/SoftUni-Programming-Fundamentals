using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] sum = new int[number.Length];
            int[] tempNumbers = new int[number.Length];

            for (int i = 0; i < rotations; i++)
            {
                Array.Copy(number, tempNumbers, number.Length);

                for (int j = 0; j < number.Length; j++)
                {
                    if (j == 0)
                    {
                        number[j] = tempNumbers[number.Length - 1];
                    }

                    else
                    {
                        number[j] = tempNumbers[j - 1];
                    }             
                }

                for (int j = 0; j < number.Length; j++)
                {
                    sum[j] += number[j];
                }
            }

            Console.WriteLine(String.Join(" ", sum));
        }
    }
}
