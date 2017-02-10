using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Population_Counter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cityPopulation = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (input != "report")
            {
                string country = input.Split('|')[1];
                string city = input.Split('|')[0];
                long population = long.Parse(input.Split('|')[2]);

                if (!cityPopulation.ContainsKey(country))
                {
                    cityPopulation[country] = new Dictionary<string, long>();
                    cityPopulation[country]["total population"] = 0;
                }

                if (!cityPopulation[country].ContainsKey(city))
                {
                    cityPopulation[country][city] = 0;
                }

                cityPopulation[country]["total population"] += population;
                cityPopulation[country][city] += population;

                input = Console.ReadLine();
            }

            cityPopulation = cityPopulation
                .OrderByDescending(pair => pair.Value["total population"])
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var country in cityPopulation)
            {
                Console.WriteLine(country.Key + " (total population: " + country.Value["total population"] + ")");

                Dictionary<string, long> itemsToPrint = new Dictionary<string, long>();
                foreach (var item in country.Value)
                {
                    if (item.Key != "total population")
                    {                      
                        if (!itemsToPrint.ContainsKey(item.Key))
	                    {
		                    itemsToPrint[item.Key] = 0;
	                    }   
                
                        itemsToPrint[item.Key] += item.Value;
                    }
                }

                itemsToPrint = itemsToPrint.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

                foreach (var city in itemsToPrint)
                {
                    Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
                }
            }
        }
    }
}

