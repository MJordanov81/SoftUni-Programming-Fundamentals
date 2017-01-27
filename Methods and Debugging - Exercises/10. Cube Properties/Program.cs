using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {

            var cubeSide = double.Parse(Console.ReadLine());
            string calculationType = Console.ReadLine();

            switch (calculationType)
            {
                case "face":
                    Console.WriteLine("{0:f2}", CalculateCubeFace(cubeSide)); ;
                    break;
                case "space":
                    Console.WriteLine("{0:f2}", CalculateCubeSpace(cubeSide)); ;
                    break;
                case "volume":
                    Console.WriteLine("{0:f2}", CalculateCubeVolume(cubeSide)); ;
                    break;
                case "area":
                    Console.WriteLine("{0:f2}", CalculateCubeArea(cubeSide)); ;
                    break;
            }
        }


        public static double CalculateCubeFace(double side)
        {
            var cubeFaceDiagonal = Math.Sqrt(2 * side * side);

            return cubeFaceDiagonal;
        }


        public static double CalculateCubeSpace(double side)
        {
            var cubeSpaceDiagonal = Math.Sqrt(3 * side * side);

            return cubeSpaceDiagonal;
        }


        public static double CalculateCubeVolume(double side)
        {
            var cubeVolume = side * side * side;

            return cubeVolume;
        }


        public static double CalculateCubeArea(double side)
        {
            var cubeArea = 6 * side * side;

            return cubeArea;
        }
    }
}
