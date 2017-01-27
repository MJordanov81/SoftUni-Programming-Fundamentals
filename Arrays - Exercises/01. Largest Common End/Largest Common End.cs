using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstString = Console.ReadLine().Split(' ');
            string[] secondString = Console.ReadLine().Split(' ');

            int left = CheckCommonEnd(firstString, secondString);

            Array.Reverse(firstString);
            Array.Reverse(secondString);

            int right = CheckCommonEnd(firstString, secondString);

            Console.WriteLine("{0}", Math.Max(left, right));
        }

        public static int CheckCommonEnd(string [] firstString, string [] secondString)
        {
            int commonEnd = 0;
            for (int i = 0; ; i++)
            {
                if (firstString.Length < i + 1 || secondString.Length < i + 1)
                {
                    return commonEnd;
                }

                else if (firstString[i] == secondString[i])
                {
                    commonEnd++;
                }

                else
                {
                    return commonEnd;
                }
            }
        }
    }
}
