using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.DAL.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public virtual Group Group { get; set; }
    }
}
