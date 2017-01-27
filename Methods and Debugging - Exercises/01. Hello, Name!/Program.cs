
namespace Hello__Name_

{
    using System;

    class Program
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Name(name);
        }

        public static void Name(string name)
        {           
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
