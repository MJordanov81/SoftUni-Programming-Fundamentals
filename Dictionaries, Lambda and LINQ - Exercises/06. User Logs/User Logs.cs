using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.User_Logs___NEW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ipList = new SortedDictionary<string, Dictionary<string, int>>();

            var input = Console.ReadLine();

            while (input != "end")
            {
                string ip = input.Split(' ').Take(1).ToArray()[0].Substring(3);
                string user = input.Split(' ').Skip(2).Take(1).ToArray()[0].Substring(5);

                if (!ipList.ContainsKey(user))
                {
                    ipList[user] = new Dictionary<string, int>();
                }

                if (!ipList[user].ContainsKey(ip))
                {
                    ipList[user][ip] = 0;
                }

                ipList[user][ip]++;

                input = Console.ReadLine();
            }

            foreach (var item in ipList)
            {
                Console.WriteLine(item.Key + ": ");

                List<string> ipToPrint = new List<string>();

                foreach (var ip in item.Value)
                {
                    string temp = ip.Key + " => " + ip.Value;
                    ipToPrint.Add(temp);
                }

                Console.Write(string.Join(", ", ipToPrint));
                Console.WriteLine(".");
            }
        }
    }
}
