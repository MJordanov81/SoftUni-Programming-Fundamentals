using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _01.Count_Work_Days
{
    public class CountWorkDays
    {
        public static void Main(string[] args)
        {
            DateTime[] officialHolidays = new DateTime[] 
            {
                new DateTime (2016, 1, 1),
                new DateTime (2016, 3, 3),
                new DateTime (2016, 5, 1),
                new DateTime (2016, 5, 6),
                new DateTime (2016, 5, 24),
                new DateTime (2016, 9, 6),
                new DateTime (2016, 9, 22),
                new DateTime (2016, 11, 1),
                new DateTime (2016, 12, 24),
                new DateTime (2016, 12, 25),
                new DateTime (2016, 12, 26)
            };

            var input = Console.ReadLine();
            var date1 = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            input = Console.ReadLine();
            var date2 = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            int workingDays = 0;

            for (DateTime i = date1; i <= date2; i = i.AddDays(1))
            {
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday )
                {
                    bool isHoliday = false;

                    for (int j = 0; j < officialHolidays.Length; j++)
                    {
                        if (i.Day == officialHolidays[j].Day && i.Month == officialHolidays[j].Month)
                        {
                            isHoliday = true;
                        }
                    }

                    if (!isHoliday)
                    {
                        workingDays++;
                    }
                }
            }

            Console.WriteLine(workingDays);
        }
    }
}
