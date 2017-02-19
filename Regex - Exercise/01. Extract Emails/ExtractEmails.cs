using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Extract_Emails
{
    public class ExtractEmails
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"((?<=\s)[a-zA-Z0-9]+([-.]\w*)*@[a-zA-Z]+?([.-][a-zA-Z]*)*(\.[a-z]{2,}))";
            var reg = new Regex(pattern);
            var matches = reg.Matches(input);

            foreach (Match email in matches)
            {
                Console.WriteLine(email.Groups[0]);
            }
        }
    }
}
