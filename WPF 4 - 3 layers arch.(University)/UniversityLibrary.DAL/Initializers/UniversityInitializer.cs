using System.Data.Entity;
using UniversityLibrary.DAL.Entities;

namespace UniversityLibrary.DAL.Initializers
{
    public class UniversityInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var students1 = new Student[]
            {
                new Student{Name = "George", Surname = "Moston"},
                new Student{Name = "John", Surname = "Mccane"},
                new Student{Name = "Bill", Surname = "Snow"},
            };

            var students2 = new Student[]
           {
                new Student{Name = "Stepan", Surname = "Moston"},
                new Student{Name = "Grisha", Surname = "Dizel"},
                new Student{Name = "Ivan", Surname = "Makhno"},
           };

            var group1 = new Group { Name = "34GS", Students = students1 };
            var group2 = new Group { Name = "14EF", Students = students2 };

            context.Groups.Add(group1);
            context.Groups.Add(group2);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
