using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _10.Student_Groups
{
    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    public class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Group
    {
        public string Town { get; set; }
        public List<Student> Student { get; set; }
    }

    public class StudentGroups
    {
        public static Dictionary<string, Town> listTowns = new Dictionary<string, Town>();
        public static void Main()
        {
            Dictionary<Group, string> listGroups = new Dictionary<Group, string>();
            var input = Console.ReadLine();
            var town = string.Empty;

            while (input != "End")
            {

                if (input.Contains("seats"))
                {
                    town = AddTown(input);
                }
                else
                {
                    AddStudent(input, town);
                }

                input = Console.ReadLine();
            }

            foreach (var singleTown in listTowns.Values)
            {
                singleTown.Students = singleTown.Students
                    .OrderBy(x => x.RegistrationDate)
                    .ThenBy(x => x.Name)
                    .ThenBy(x => x.Email)
                    .ToList();
            }

            var createdGroups = 0;

            foreach (var singleTown in listTowns.Values)
            {
                var notFullGroup = 0;
                if (singleTown.Students.Count % singleTown.SeatsCount > 0)
                {
                    notFullGroup = 1;
                }

                for (int i = 0; i < singleTown.Students.Count / singleTown.SeatsCount + notFullGroup; i++)
                {
                    var currentGroup = new Group
                    {
                        Town = singleTown.Name,
                        Student = new List<Student>()
                    };
                    createdGroups++;

                    currentGroup.Student = singleTown.Students.Skip(i * singleTown.SeatsCount).Take(singleTown.SeatsCount).ToList();

                    listGroups.Add(currentGroup, singleTown.Name);
                }
            }

            PrintResult(listGroups, createdGroups);
        }

        public static string AddTown(string input)
        {
            var inputArr = input.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.TrimStart()).Select(x => x.TrimEnd()).ToArray();
            var name = inputArr[0];
            var town = name;
            var seats = int.Parse((inputArr[1].Split(' ').Take(1).ToArray())[0]);

            var currentTown = new Town
            {
                Name = name,
                SeatsCount = seats,
                Students = new List<Student>()
            };

            if (!listTowns.ContainsKey(currentTown.Name))
            {
                listTowns[currentTown.Name] = currentTown;
            }

            return town;
        }

        public static void AddStudent(string input, string town)
        {
            var inputArr = input.Split('|').Select(x => x.TrimEnd()).Select(x => x.TrimStart()).ToArray();

            var currentStudent = new Student
            {
                Name = inputArr[0],
                Email = inputArr[1],
                RegistrationDate = DateTime.ParseExact(inputArr[2], "d-MMM-yyyy", CultureInfo.InvariantCulture)
            };


            listTowns[town].Students.Add(currentStudent);

        }

        public static void PrintResult (Dictionary<Group, string> groups, int createdGroups)
        {
            groups = groups.OrderBy(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);


            Console.WriteLine("Created " + createdGroups + " groups in " + listTowns.Count + " towns:");
            foreach (var group in groups.Keys)
	        {
                Console.Write(group.Town + " => ");

                List<string> emails = new List<string>();
                foreach (var student in group.Student)
                {
                    emails.Add(student.Email);
                }
                Console.Write(string.Join(", ", emails));
                Console.WriteLine();
	        }
        }
    }
}
