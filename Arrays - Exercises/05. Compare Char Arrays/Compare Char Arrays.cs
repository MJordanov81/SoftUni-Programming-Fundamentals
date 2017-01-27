using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] first = Console.ReadLine().Split(' ').Select(Convert.ToChar).ToArray();

            char[] second = Console.ReadLine().Split(' ').Select(Convert.ToChar).ToArray();

            var shorter = Math.Min(first.Length, second.Length);



            for (int i = 0; i < shorter; i++)
            {
                if (first[i] > second[i])
                {
                    Console.WriteLine(string.Join("", second));
                    Console.WriteLine(string.Join("", first));
                    break;
                }

                else if (first[i] < second[i])
                {
                    Console.WriteLine(string.Join("", first));
                    Console.WriteLine(string.Join("", second));
                    break;
                }
                else
                {
                    if (i == shorter - 1 && second.Length <= first.Length)
                    {
                        Console.WriteLine(string.Join("", second));
                        Console.WriteLine(string.Join("", first));
                        break;
                    }
                    else if (i == shorter - 1 && second.Length > first.Length)
                    {
                        Console.WriteLine(string.Join("", first));
                        Console.WriteLine(string.Join("", second));
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
        }
    }
}
