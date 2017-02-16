using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Unicode_Characters
{
    public class UnicodeCharacters
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            foreach (var singleChar in input)
            {
                Console.Write("\\u" + ((int)singleChar).ToString("x4"));
            }

            Console.WriteLine();
        }
    }
}
