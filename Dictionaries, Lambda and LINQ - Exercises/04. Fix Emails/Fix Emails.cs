using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fix_Emails
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var emailBook = new Dictionary<string, string>();

            var inputName = Console.ReadLine();
            var inputEmail = string.Empty;

            if (inputName != "stop")
            {
                inputEmail = Console.ReadLine();
            }

            else
            {
                return;
            }

            do
            {
                if (!inputEmail.EndsWith("us") && !inputEmail.EndsWith("uk"))
                {
                    emailBook[inputName] = inputEmail;
                }

                inputName = Console.ReadLine();

                if (inputName != "stop")
                {
                    inputEmail = Console.ReadLine();
                }

            } while (inputName != "stop");

            foreach (var item in emailBook)
	            {
		            Console.WriteLine("{0} -> {1}", item.Key, item.Value);
	            }
            
        }
    }
}
