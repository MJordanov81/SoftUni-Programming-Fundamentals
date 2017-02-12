using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Advertisement_Message
{
    public class AdvertisementMessage
    {
        public static void Main(string[] args)
        {
            var phrases = new string[] 
            { 
                "Excellent product.", 
                "Such a great product.", 
                "I always use that product.", 
                "Best product of its category.", 
                "Exceptional product.", 
                "I can’t live without this product." 
            };

            var events = new string[]
            {
                "Now I feel good.", 
                "I have succeeded with this product.", 
                "Makes miracles. I am happy of the results!", 
                "I cannot believe but now I feel awesome.", 
                "Try it yourself, I am very satisfied.", 
                "I feel great!"
            };

            var authors = new string[]
            {
                "Diana", 
                "Petya", 
                "Stella", 
                "Elena", 
                "Katya", 
                "Iva", 
                "Annie", 
                "Eva"
            };

            var cities = new string[]
            {
                "Burgas", 
                "Sofia", 
                "Plovdiv", 
                "Varna", 
                "Ruse"
            };

            int n = int.Parse(Console.ReadLine());

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                int phraseR = random.Next(0, 6);
                int eventR = random.Next(0, 6);
                int authorR = random.Next(0, 8);
                int cityR = random.Next(0, 5);

                Console.WriteLine(phrases[phraseR] + " " + events[eventR] + " " + authors[authorR] + " " + cities[cityR]);
            }
        }
    }
}
