using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _02.Convert_from_base_N_to_base_10
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            var baseN = int.Parse(input[0]);
            var number = BigInteger.Parse(input[1]);

            var result = BigInteger.Zero;
            var power = 0;

            do
            {
                var currentNumber = number % 10;
                currentNumber = currentNumber * BigInteger.Pow(baseN, power);
                result += currentNumber;

                power++;
                number /= 10;
                
            } while (number != 0);

            Console.WriteLine(result);
        }
    }
}
