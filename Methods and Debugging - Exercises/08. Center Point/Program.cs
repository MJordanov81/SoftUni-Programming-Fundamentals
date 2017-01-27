using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {

            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());

            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            var distancePoint1 = CalculateDistance(x1, y1);
            var distancePoint2 = CalculateDistance(x2, y2);

            if (distancePoint1 < distancePoint2)
            {
                Console.WriteLine("({0}, {1})", x1, y1);
            }
            else
            {
                Console.WriteLine("({0}, {1})", x2, y2);
            }
        }


        public static double CalculateDistance(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }
    }
}
