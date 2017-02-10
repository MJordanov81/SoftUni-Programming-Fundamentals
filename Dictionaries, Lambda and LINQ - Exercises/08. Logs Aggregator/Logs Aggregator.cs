using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Logs_Aggregator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var log = new SortedDictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                var name = input.Split(' ')[1];
                var ip = input.Split(' ')[0];
                var duration = int.Parse(input.Split(' ')[2]);

                if (!log.ContainsKey(name))
                {
                    log[name] = new Dictionary<string, int>();
                    log[name]["total duration"] = 0;
                }

                if (!log[name].ContainsKey(ip))
                {
                    log[name][ip] = 0;
                }

                log[name]["total duration"] += duration;
                log[name][ip] += duration;

            }

            foreach (var user in log)
            {
                Console.Write(user.Key + ": " + user.Value["total duration"] + " ");

                List<string> ip = new List<string>();

                foreach (var item in user.Value)
                {
                    if (item.Key != "total duration")
                    {
                        ip.Add(item.Key); 
                    }               
                }

                ip = ip.OrderBy(x => x).ToList();

                Console.WriteLine("[" + string.Join(", ", ip) + "]");
            }
        }
    }
}
