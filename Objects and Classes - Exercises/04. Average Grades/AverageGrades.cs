using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Average_Grades
{
    public class Student
    {
        public decimal[] Grades { get; set; }

        public string Name { get; set; }

        public decimal AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }
    }
    public class AverageGrades
    {
        public static void Main(string[] args)
        {
            var studentsList = new Dictionary<Student, decimal>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');

                var currentStudent = new Student
                {
                    Name = input[0],
                    Grades = input.Skip(1).Select(decimal.Parse).ToArray()
                };

                studentsList[currentStudent] = currentStudent.AverageGrade;
            }

            studentsList = studentsList.OrderBy(x => x.Key.Name).ThenByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var student in studentsList)
            {
                if (student.Value >= 5.00m)
                {
                    Console.WriteLine("{0} -> {1:f2}", student.Key.Name, student.Value);
                }
            }
        }
    }
}
