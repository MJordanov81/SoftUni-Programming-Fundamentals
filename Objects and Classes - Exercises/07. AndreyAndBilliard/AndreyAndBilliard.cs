using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AndreyAndBilliard
{
    public class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, decimal> shoppingCart = new Dictionary<string, decimal>();
    }
    public class AndreyAndBilliard
    {
        public static void Main(string[] args)
        {
            var shop = new Dictionary<string, decimal>();
            var listCustomers = new Dictionary<string, Dictionary<string, decimal>>();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split('-');

                shop[input[0]] = decimal.Parse(input[1]);
            }

            var inputCustomer = Console.ReadLine();

            while (inputCustomer != "end of clients")
            {
                var purchase = inputCustomer.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (shop.ContainsKey(purchase[1]))
                {
                    var currentCustomer = new Customer
                    {
                        Name = purchase[0],
                    };

                    if (!listCustomers.ContainsKey(currentCustomer.Name))
                    {
                        listCustomers[currentCustomer.Name] = new Dictionary<string, decimal>();
                    }

                    if (!listCustomers[currentCustomer.Name].ContainsKey(purchase[1]))
                    {
                        listCustomers[currentCustomer.Name][purchase[1]] = 0;
                    }

                    listCustomers[currentCustomer.Name][purchase[1]] += decimal.Parse(purchase[2]);
                }

                inputCustomer = Console.ReadLine();                
            }

            listCustomers = listCustomers.OrderBy(x => x.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            var totalBill = 0m;
            foreach (var item in listCustomers)
            {
                Console.WriteLine(item.Key);

                decimal currentBill = 0;

                foreach (var purchase in item.Value)
                {
                    Console.WriteLine("-- {0} - {1}", purchase.Key, purchase.Value);
                    currentBill += GetPrice(purchase.Key, purchase.Value, shop);
                }

                Console.WriteLine("Bill: {0:f2}", currentBill);
                totalBill += currentBill;
            }

            Console.WriteLine("Total bill: {0:f2}", totalBill);
        }

        public static decimal GetPrice(string product, decimal price, Dictionary<string, decimal> priceList)
        {
            return price * priceList[product];
        }
    }
}
