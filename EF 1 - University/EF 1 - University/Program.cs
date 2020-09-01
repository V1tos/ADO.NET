using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EF_1___University
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityEntities context = new UniversityEntities();


            //Вивести всіх студентів групи А123

            var students = context.Students.Where(x => x.Group.Name == "B123");

            ShowStudents(students);


            //Знайти кількість студентів у групах Р123 та Р456 разом

            var studentCount = context.Students.Where(x => x.Group.Name == "B123" || x.Group.Name == "Pr456").Count();

            Console.WriteLine(studentCount);

            //Знайти студента з максимальною оцінкою по предмету С++

            var studentsMaxMark = context.Achievements.Where(x => x.Subject.Name == "C++" && x.Mark == context.Achievements.Where(y => y.Subject.Name == "C++").Max(z => z.Mark)).Select(x=>x.Student);

            ShowStudents(studentsMaxMark);

            //Вивести всі предмети, які читає Андрій Трофімчук

            var subjects = context.Departments.FirstOrDefault(x => x == context.Teachers.FirstOrDefault(y => y.Name == "Andrii" && y.Surname == "Trofimchuk").Department).Subjects;

            ShowSubjects(subjects);

            //Знайти, скільки студентів з іменем Оля є в БД

            var countStudentsWithSpecName = context.Students.Count(x=>x.Name == "Sergey");

            Console.WriteLine($"{countStudentsWithSpecName} students with name Sergey");


            //Студенту з мінімальною оцінкою по предмету С# змінити прізвище

            context.Achievements.FirstOrDefault(x => x.Subject.Name == "C#" && x.Mark == context.Achievements.Where(y => y.Subject.Name == "C#").Min(z => z.Mark)).Student.Surname = "Gates";

        }

        private static void ShowSubjects(ICollection<Subject> subjects)
        {
            foreach (var item in subjects)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void ShowStudents(IQueryable<Student> students)
        {
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Name} {item.Surname} - {item.Group.Name}");
            }
        }
    }
}
