using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Circles_Intersection
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public static bool DoIntersect (Circle circle1, Circle circle2)
        {
            bool DoIntersect = false;
            double distanceCenters = Math.Sqrt(Math.Pow((circle1.Center.X - circle2.Center.X), 2) + Math.Pow((circle1.Center.Y - circle2.Center.Y), 2));

            if (distanceCenters <= circle2.Radius + circle2.Radius)
            {
                DoIntersect = true;           
            }

            return DoIntersect;
        }
    }

    public class CirclesIntersection
    {
        public static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Circle circle1 = new Circle
            {
                Center = new Point
                {
                    X = input[0],
                    Y = input[1]
                },

                Radius = input[2]
            };

            input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Circle circle2 = new Circle
            {
                Center = new Point
                {
                    X = input[0],
                    Y = input[1]
                },

                Radius = input[2]
            };

            if (Circle.DoIntersect(circle1, circle2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
