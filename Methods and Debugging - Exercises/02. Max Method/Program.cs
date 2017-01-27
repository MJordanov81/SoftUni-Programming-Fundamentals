using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMax(a, b, c));
        }

        public static int GetMax(int a, int b, int c)
        {
            int d = Math.Max(a, b);
            return Math.Max(c, d);
        }
    }
}
