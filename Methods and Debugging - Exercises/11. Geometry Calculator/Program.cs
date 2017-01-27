using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            switch (figure)
            {
                case "triangle":
                    Console.WriteLine("{0:f2}", TriangleAreaCalculate()); ;
                    break;
                case "rectangle":
                    Console.WriteLine("{0:f2}", RectangleAreaCalculate()); ;
                    break;
                case "square":
                    Console.WriteLine("{0:f2}", SquareAreaCalculate()); ;
                    break;
                case "circle":
                    Console.WriteLine("{0:f2}", CircleAreaCalculate()); ;
                    break;
            }
        }

        public static double TriangleAreaCalculate()
        {
            var side = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var triangleArea = side * height / 2;

            return triangleArea;
        }


        public static double CircleAreaCalculate()
        {
            var radius = double.Parse(Console.ReadLine());

            var circleArea = Math.PI * radius * radius;

            return circleArea;
        }

        public static double SquareAreaCalculate()
        {
            var side = double.Parse(Console.ReadLine());

            var squareArea = side * side;

            return squareArea;
        }

        public static double RectangleAreaCalculate()
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var rectangleArea = width * height;

            return rectangleArea;
        }
    }
}
