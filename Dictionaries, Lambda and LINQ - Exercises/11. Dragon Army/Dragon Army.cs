using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Dragon_Army
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dragons = new Dictionary<string, Dictionary<string, decimal? []>>();
            var dragonsCount = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');

                var dragonType = input[0];
                var dragonName = input[1];
                var dragonVariablesString = input.Skip(2).Take(3).ToArray();
                var dragonVariables = new decimal?[3];

                for (int j = 0; j < dragonVariables.Length; j++)
                {
                    try
                    {
                        dragonVariables[j] = decimal.Parse(dragonVariablesString[j]);
                    }

                    catch(Exception)
                    {
                        dragonVariables[j] = null;
                    }                 
                }

                if (!dragons.ContainsKey(dragonType))
                {
                    dragons[dragonType] = new Dictionary<string, decimal?[]>();
                    dragons[dragonType]["@average"] = new decimal?[3] { 0, 0, 0 };
                    dragons[dragonType]["@sum"] = new decimal?[3] { 0, 0, 0 };
                }

                if (!dragonsCount.ContainsKey(dragonType))
                {
                    dragonsCount[dragonType] = 0;
                }

                if (!dragons[dragonType].ContainsKey(dragonName))
                {
                    dragons[dragonType][dragonName] = new decimal?[3] { 0, 0, 0 };

                    dragonsCount[dragonType]++;

                }

                if (dragons[dragonType].ContainsKey(dragonName))
                {
                    for (int m = 0; m < 3; m++)
			        {
                        dragons[dragonType]["@sum"][m] -= dragons[dragonType][dragonName][m];
			        }
                    
                }

                for (int k = 0; k < 3; k++)
                {
                    if (dragonVariables[k] != null)
                    {
                        dragons[dragonType][dragonName][k] = dragonVariables[k];
                    }

                    else
                    {
                        if (k == 0)
                        {
                            dragons[dragonType][dragonName][k] = 45;
                        }

                        else if (k == 1)
                        {
                            dragons[dragonType][dragonName][k] = 250;
                        }

                        else
                        {
                            dragons[dragonType][dragonName][k] = 10;
                        }
                    }

                        dragons[dragonType]["@sum"][k] += dragons[dragonType][dragonName][k];
                
                }

                for (int k = 0; k < 3; k++)
                {
                    dragons[dragonType]["@average"][k] = dragons[dragonType]["@sum"][k] / dragonsCount[dragonType];
                }
            }

            foreach (var dragonType in dragons)
            {
                Console.WriteLine(dragonType.Key + "::({0:f2}/{1:f2}/{2:f2})", dragonType.Value["@average"][0], dragonType.Value["@average"][1], dragonType.Value["@average"][2]);

                var dragonTypeSorted = dragonType.Value.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                foreach (var dragonName in dragonTypeSorted)
                {
                    if (dragonName.Key != "@average" & dragonName.Key != "@sum")
                    {
                        Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", dragonName.Key, dragonName.Value[0], dragonName.Value[1], dragonName.Value[2]);
                    }                 
                }
            }
        }
    }
}
