namespace UniversityLibrary.DAL
{
    using System.Data.Entity;
    using UniversityLibrary.DAL.Entities;
    using UniversityLibrary.DAL.Initializers;

    public class ApplicationContext : DbContext
    {

        public ApplicationContext()
            : base("name=ApplicationContext")
        {
            Database.SetInitializer(new UniversityInitializer());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }


    }
}