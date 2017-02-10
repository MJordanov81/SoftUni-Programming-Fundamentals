using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Legendary_Farming
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var materialsList = new Dictionary<string, int>();
            string itemAquired = string.Empty;
          
            for (int i = 0; i < 10; i++)
            {
                var input = Console.ReadLine().Split(' ').ToList();

                for (int j = 0; j < input.Count; j += 2)
                {
                    int quantity = int.Parse(input[j]);
                    string material = input[j + 1].ToLower();

                    if (!materialsList.ContainsKey(material))
                    {
                        materialsList[material] = 0;
                    }

                    if (i == 0 && j == 0)
                    {
                        materialsList["shards"] = 0;
                        materialsList["fragments"] = 0;
                        materialsList["motes"] = 0;
                    }

                    materialsList[material] += quantity;

                    if (materialsList.ContainsKey("shards") && materialsList["shards"] >= 250)
                    {
                        materialsList["shards"] -= 250;
                        itemAquired = "Shadowmourne";
                        PrintStock(itemAquired, materialsList);
                        return;
                    }

                    if (materialsList.ContainsKey("fragments") && materialsList["fragments"] >= 250)
                    {
                        materialsList["fragments"] -= 250;
                        itemAquired = "Valanyr";
                        PrintStock(itemAquired, materialsList);
                        return;
                    }

                    if (materialsList.ContainsKey("motes") && materialsList["motes"] >= 250)
                    {
                        materialsList["motes"] -= 250;
                        itemAquired = "Dragonwrath";
                        PrintStock(itemAquired, materialsList);
                        return;
                    }
                }
            }
        }

        public static void PrintStock(string itemAquired, Dictionary<string, int> aquisitions)
        {
            Console.WriteLine("{0} obtained!", itemAquired);

            var importantMaterials = new Dictionary <string, int> ();
            foreach (var pair in aquisitions)
            {
                if (pair.Key == "shards" || pair.Key == "fragments" || pair.Key == "motes")
                {
                    importantMaterials[pair.Key] = pair.Value;
                }
            }

            importantMaterials = importantMaterials.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var pair in importantMaterials)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }

            aquisitions = aquisitions.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var pair in aquisitions)
            {
                if (pair.Key != "shards" && pair.Key != "fragments" && pair.Key != "motes")
                {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }                
            }
        }
    }
}
