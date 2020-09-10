using AutoMapper;
using UniversityLibrary.BLL.Model;
using UniversityLibrary.DAL.Entities;

namespace UniversityLibrary.BLL.Utils
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Student, StudentDTO>().ForMember(x => x.Group, opt => opt.MapFrom(x => x.Group.Name));

            CreateMap<StudentDTO, Student>().ForMember(x => x.Group, opt => opt.MapFrom(x => new Group { Name = x.Group }));
        }
    }
}
