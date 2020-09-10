using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLibrary.BLL.Model;
using UniversityLibrary.DAL.Entities;
using UniversityLibrary.DAL.Repository;

namespace UniversityLibrary.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> repo;
        private readonly IGenericRepository<Group> repoGroup;
        private readonly IMapper mapper;

        public StudentService(IGenericRepository<Student> _repo,
                              IGenericRepository<Group> _repoGroup, IMapper _mapper)
        {
            repo = _repo;
            repoGroup = _repoGroup;
            mapper = _mapper;
        }
        public void AddStudent(StudentDTO student)
        {
            var addStudent = mapper.Map<Student>(student);
            var group = repoGroup.GetAll().FirstOrDefault(x => x.Name == student.Group);
            if (group!=null)
                addStudent.Group = group;
            repo.Create(addStudent);
        }

        public void DeleteStudent(StudentDTO student)
        {
            var deleteStudent = mapper.Map<Student>(student);
            deleteStudent = SetFromRepositories(deleteStudent, student);
            repo.Delete(deleteStudent);
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            var students = repo.GetAll();
            var model = mapper.Map<ICollection<StudentDTO>>(students);
            return model;
        }

        public void UpdateStudent(StudentDTO student)
        {
            var updateStudent = mapper.Map<Student>(student);
            //var newStudent = mapper.Map<Student>(clientUpdateStudent);
            //var group = repoGroup.GetAll().FirstOrDefault(x => x.Name == clientUpdateStudent.Group);
            //if (group!=null)
            //{
            //    newStudent.Group = group;
            //}
            updateStudent = SetFromRepositories(updateStudent, student);
            
            if (updateStudent!=null)
            {
                updateStudent.Name = "asf";
                repo.Update(updateStudent);
            }
        }

        private Student SetFromRepositories(Student mapStudent, StudentDTO student)
        {
            var group = repoGroup.GetAll().FirstOrDefault(x => x.Name == student.Group);
            mapStudent.Group = group;
            mapStudent.Id = repo.GetAll().FirstOrDefault(x => x.Name == mapStudent.Name && x.Surname == mapStudent.Surname && x.Group.Name == mapStudent.Group.Name).Id;
            mapStudent = repo.GetAll().FirstOrDefault(x => x.Id == mapStudent.Id);
            return mapStudent;
        }
    }
}
