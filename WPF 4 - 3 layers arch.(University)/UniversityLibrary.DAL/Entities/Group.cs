using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.DAL.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}
