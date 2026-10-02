using SchoolProject.Core.Features.Students.Query.Results;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentListPAginationMap()
        {
            CreateMap<Student, GetStudentPaginatedListResponse>().
                ForMember(dest => dest.DepartName, opt => opt.MapFrom(src => src.Department.Localize(src.Department.DNameAr, src.Department.DNameEn))).
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn))).
                ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address)).
                ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.StudID));
        }
    }
}





