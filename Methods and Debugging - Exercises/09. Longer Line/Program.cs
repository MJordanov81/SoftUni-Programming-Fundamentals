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

            var x3 = double.Parse(Console.ReadLine());
            var y3 = double.Parse(Console.ReadLine());
            var x4 = double.Parse(Console.ReadLine());
            var y4 = double.Parse(Console.ReadLine());

            var line1 = CalculateLenght(x1, y1, x2, y2);
            var line2 = CalculateLenght(x3, y3, x4, y4);


            if (line1 > line2)
            {
                switch (ComparePointDistance(x1, y1, x2, y2))
                {
                    case true:
                        Console.WriteLine("({0}, {1})({2}, {3})", x1, y1, x2, y2);
                        break;
                    case false:
                        Console.WriteLine("({0}, {1})({2}, {3})", x2, y2, x1, y1);
                        break;
                }
            }
            else
            {
                switch (ComparePointDistance(x3, y3, x4, y4))
                {
                    case true:
                        Console.WriteLine("({0}, {1})({2}, {3})", x3, y3, x4, y4);
                        break;
                    case false:
                        Console.WriteLine("({0}, {1})({2}, {3})", x4, y4, x3, y3);
                        break;
                }
            }
        }


        public static double CalculateLenght(double x1, double y1, double x2, double y2)
        {
            var lenght = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

            return lenght;
        }


        public static double CalculateDistance(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }


        public static bool ComparePointDistance(double x1, double y1, double x2, double y2)
        {
            bool isPointOneCloser = true;

            var point1 = CalculateDistance(x1, y1);
            var point2 = CalculateDistance(x2, y2);

            if (point2 < point1)
            {
                isPointOneCloser = false;
            }

            return isPointOneCloser;
        }
        
    }
}
