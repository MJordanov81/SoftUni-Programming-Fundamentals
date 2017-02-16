using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Multiply_big_number
{
    public class MultiplyBigNumber
    {
        public static void Main()
        {
            var inputNumberOne = Console.ReadLine().TrimStart('0');
            var inputNumberTwo = Console.ReadLine().TrimStart('0');
            var result = string.Empty;

            if ((inputNumberOne != "0" && inputNumberTwo != "0") 
                && (inputNumberOne != "" && inputNumberTwo != ""))
            {
                if (inputNumberTwo.Length > inputNumberOne.Length)
                {
                    var tempString = inputNumberOne;
                    inputNumberOne = inputNumberTwo;
                    inputNumberTwo = tempString;
                }

                if (inputNumberOne.Length >= inputNumberTwo.Length)
                {
                    result = GetProduct(inputNumberOne, inputNumberTwo);
                }

                Console.WriteLine(result.TrimStart('0'));
            }
            else
            {
                Console.WriteLine("0");
            }

        }

        public static string GetProduct (string stringOne, string stringTwo)
        {
            var result = "0";
            var trailingZeroes = 0;

            for (int i = stringTwo.Length - 1; i >= 0; i--)
            {
                var remainder = 0;
                var currentProduct = 0;
                var product = string.Empty;

                for (int j = stringOne.Length - 1; j >= 0; j--)
                {
                    currentProduct = int.Parse(Convert.ToString(stringTwo[i])) * int.Parse(Convert.ToString(stringOne[j])) + remainder;

                    if (currentProduct >= 10)
                    {
                        remainder = currentProduct / 10;
                        currentProduct %= 10;                        
                    }

                    else
                    {
                        remainder = 0;
                    }

                    product = product.Insert(0, currentProduct.ToString());
                }

                if (remainder > 0)
                {
                   product = product.Insert(0, remainder.ToString()); 
                }

                product = string.Concat(product, new string('0', trailingZeroes));
                trailingZeroes++;

                if (result.Length > product.Length)
	            {
		            var temp = result;
                    result = product;
                    product = temp;
	            }

                if (product.Length > result.Length)
                {
                    var difference = product.Length - result.Length;

                    result = result.Insert(0, new string('0', difference));
                }

                result = GetSum(product, result).TrimStart('0');
            }

            return result;
        }

        public static string GetSum(string numberOne, string numberTwo)
        {
            var sum = string.Empty;

            var charArrOne = numberOne.ToCharArray();
            var charArrTwo = numberTwo.ToCharArray();

            var remainder = 0;

            for (int i = charArrOne.Length - 1; i >= 0; i--)
            {
                var currentSum = int.Parse(Convert.ToString(charArrOne[i])) + int.Parse(Convert.ToString(charArrTwo[i])) + remainder;

                if (currentSum >= 10)
                {
                    currentSum = currentSum % 10;
                    remainder = 1;
                }

                else
                {
                    remainder = 0;
                }

                sum = sum.Insert(0, currentSum.ToString());
            }

            if (remainder > 0)
            {
                sum = sum.Insert(0, remainder.ToString());
            }

            return sum;
        }
    }
}
