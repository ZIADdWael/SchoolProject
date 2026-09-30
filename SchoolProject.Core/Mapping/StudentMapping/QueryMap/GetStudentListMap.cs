using SchoolProject.Core.Features.Students.Query.Results;
using SchoolProject.Data.Entites;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentListMap()
        {
            CreateMap<Student, GetStudentListResponse>().
                ForMember(dest => dest.DepartName, opt => opt.MapFrom(src => src.Department.Localize(src.Department.DNameAr, src.Department.DNameEn))).
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
