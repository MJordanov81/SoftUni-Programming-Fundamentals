using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _05.Book_Library
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
    }

    public class Library
    {
        public string Name { get; set; }
        public List<Book> ListOfBooks { get; set; }
    }

    public class BookLibrary
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var library = new Library()
            {
                Name = "Public Library",
                ListOfBooks = new List<Book>(),
            };

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');

                var currentBook = new Book
                {
                    Title = input[0],
                    Author = input[1],
                    Publisher = input[2],
                    ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ISBN = input[4],
                    Price = decimal.Parse(input[5])
                };

                library.ListOfBooks.Add(currentBook);
            }

            DateTime comparativeDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            var titlesAfterDate = new Dictionary<DateTime, List<string>>();

            foreach (var book in library.ListOfBooks)
            {
                if (!titlesAfterDate.ContainsKey(book.ReleaseDate))
                {
                    titlesAfterDate[book.ReleaseDate] = new List<string>();
                }
                titlesAfterDate[book.ReleaseDate].Add(book.Title);
            }

            titlesAfterDate = titlesAfterDate.OrderBy(x => x.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var date in titlesAfterDate)
            {
                if (date.Key > comparativeDate)
                {
                    var titles = date.Value.OrderBy(x => x).ToList();
                    for (int i = 0; i < titles.Count; i++)
                    {
                        Console.WriteLine("{0} -> {1:dd.MM.yyyy}", titles[i], date.Key);
                    }
                }

            }
        }
    }
}
