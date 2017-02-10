using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Phonebook
{
    public class Phonebook
    {
        public static void Main(string[] args)
        {
            var phoneBook = new SortedDictionary<string, string>();
            var input = Console.ReadLine().Split(' ');
            var command = input[0];

            while (command != "END")
            {
                switch (command)
                {
                    case "A":

                        var name = input[1];
                        var phone = input[2];

                        if (!phoneBook.ContainsKey(name))
                        {
                            phoneBook[name] = string.Empty;
                        }

                        phoneBook[name] = phone;
                        break;

                    case "S":

                        name = input[1];

                        if (!phoneBook.ContainsKey(name))
                        {
                            Console.WriteLine("Contact {0} does not exist.", name);
                        }

                        else
                        {
                            Console.WriteLine("{0} -> {1}", name, phoneBook[name]);
                        }

                        break;

                    default:
                        break;
                }

                input = Console.ReadLine().Split(' ');
                command = input[0];
            }
        }
    }
}
