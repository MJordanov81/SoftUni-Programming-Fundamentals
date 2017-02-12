using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _08.MentorGroup
{
    public class Student
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> Attendance { get; set; }
    }
    public class MentorGroup
    {
        public static void Main()
        {
            var listStudents = new List<Student>();
            var listStudentsComments = new Dictionary<string, List<string>>();
            var listStudentsAttendance = new Dictionary<string, List<DateTime>>();
            var listRegisteredStudents = new List<string>();

            var input = Console.ReadLine();

            while (input != "end of dates")
            {
                var dates = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var currentStudent = new Student
                {
                    Name = dates[0].ToLower(),
                    Attendance = dates
                    .Skip(1)
                    .Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                    .ToList()
                };

                listStudents.Add(currentStudent);
                listRegisteredStudents.Add(currentStudent.Name);
                listRegisteredStudents = listRegisteredStudents.Distinct().ToList();

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of comments")
            {
                var comments = input
                    .Split(new char[] { '-'}, StringSplitOptions.RemoveEmptyEntries);

                var currentStudent = new Student
                {
                    Name = comments[0].ToLower(),
                    Comments = comments
                    .Skip(1)
                    .ToList()
                };

                listStudents.Add(currentStudent);

                input = Console.ReadLine();
            }

            foreach (var student in listStudents)
            {
                if (student.Comments != null)
                {
                    if (!listStudentsComments.ContainsKey(student.Name))
                    {
                        listStudentsComments[student.Name] = new List<string>();
                    }

                    listStudentsComments[student.Name].AddRange(student.Comments);
                }

                    if (!listStudentsAttendance.ContainsKey(student.Name))
                    {
                        listStudentsAttendance[student.Name] = new List<DateTime>();
                    }

                    if (student.Attendance != null)
                    {
                        listStudentsAttendance[student.Name].AddRange(student.Attendance);  
                    }                               
            }

            listStudentsAttendance = listStudentsAttendance.OrderBy(x => x.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var student in listStudentsAttendance)
            {
                if (listRegisteredStudents.Contains(student.Key))
                {
                    Console.WriteLine("{0}" + Environment.NewLine + "Comments:", student.Key);

                    foreach (var student2 in listStudentsComments)
                    {
                        if (student2.Key == student.Key)
                        {
                            foreach (var item in student2.Value)
                            {
                                Console.WriteLine("- {0}", item);
                            }
                        }
                    }

                    Console.WriteLine("Dates attended:");

                    var listWithDates = student.Value
                        .OrderBy(x => x)
                        .ToList();

                    foreach (var dateList in listWithDates)
                    {
                        string date = dateList.ToString("dd/MM/yyyy");

                        Console.WriteLine("-- {0}", date);
                    }
                }

            }
        }
    }
}
