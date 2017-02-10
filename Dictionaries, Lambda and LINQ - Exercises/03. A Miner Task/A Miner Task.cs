using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.A_Miner_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var resourceCount = new Dictionary<string, decimal>();

            string resource = Console.ReadLine();

            decimal quantity = 0;

            if (resource != "stop")
            {
                quantity = decimal.Parse(Console.ReadLine());
            }
            
            while (resource != "stop")
            {
                if (!resourceCount.ContainsKey(resource))
                {
                    resourceCount[resource] = 0;
                }

                resourceCount[resource] += quantity;

                resource = Console.ReadLine();

                if (resource == "stop")
                {
                    foreach (var item in resourceCount)
                    {
                        Console.WriteLine("{0} -> {1}", item.Key, item.Value);
                    }

                    break;
                }

                quantity = decimal.Parse(Console.ReadLine());              
            }
        }
    }
}
