using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.Convert_from_base_10_to_base_N
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            var baseN = input[0];
            var number = input[1];

            var result = string.Empty;

            do
            {
                var digit = number % baseN;

                result = result.Insert(0, digit.ToString());

                number /= baseN;
                
            } while (number != 0);

            Console.WriteLine(result);
        }
    }
}
