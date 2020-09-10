using System.Collections.Generic;
using UniversityLibrary.BLL.Model;

namespace UniversityLibrary.BLL.Services
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetStudents();
        void AddStudent(StudentDTO student);
        void UpdateStudent(StudentDTO student);
        void DeleteStudent(StudentDTO student);
    }
}
