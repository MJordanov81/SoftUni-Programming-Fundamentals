using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool equal = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                var sumLeftNumbers = 0;
                var sumRightNumbers = 0;


                for (int j = 0; j < i; j++)
                {
                    sumLeftNumbers += numbers[j];
                }

                for (int k = i + 1; k < numbers.Length; k++)
                {
                    sumRightNumbers += numbers[k];
                }

                if (sumRightNumbers == sumLeftNumbers)
                {
                    Console.WriteLine(i);
                    equal = true;
                }
            }

            if (!equal)
            {
                Console.WriteLine("no");
            }


        }
    }
}
