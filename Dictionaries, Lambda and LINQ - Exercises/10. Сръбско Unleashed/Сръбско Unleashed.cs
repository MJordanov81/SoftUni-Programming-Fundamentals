using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _10.Сръбско_Unleashed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var singerData = new Dictionary<string, Dictionary<string, int>>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                string pattern = @"([a-zA-Z]+\s){1,3}@([a-zA-Z0-9]+\s){1,3}[0-9]+\s[0-9]+";

                var matches = Regex.Matches(input, pattern);

                if (matches.Count <= 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                var inputString = input.Split(' ').ToList();

                int ticketCount = 0;
                int ticketPrice = 0;
                string name = string.Empty;
                string venue = string.Empty;

                ticketCount = int.Parse(inputString.Last());
                ticketPrice = int.Parse(inputString[inputString.Count-2]);

                var nameArray = inputString.TakeWhile(x => !x.Contains('@')).ToArray();
                name = string.Join(" ", nameArray);

                inputString.RemoveAt(inputString.Count - 1);
                inputString.RemoveAt(inputString.Count - 1);

                var venueArray = inputString.Skip(nameArray.Length).TakeWhile(x => x != "").ToArray();
                venue = string.Join(" ", venueArray).Remove(0, 1);
                
                if (!singerData.ContainsKey(venue))
                {
                    singerData[venue] = new Dictionary<string, int>();
                }

                if (!singerData[venue].ContainsKey(name))
                {
                    singerData[venue][name] = 0;
                }

                singerData[venue][name] += ticketCount * ticketPrice;

                input = Console.ReadLine();
            }

            foreach (var venue in singerData)
            {
                Console.WriteLine(venue.Key);
                var singers = venue.Value.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

                foreach (var singer in singers)
                {
                    Console.WriteLine("#  " + singer.Key + " -> " + singer.Value);
                }
            }
        }
    }
}
