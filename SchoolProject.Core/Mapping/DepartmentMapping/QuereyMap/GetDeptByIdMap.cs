using SchoolProject.Core.Features.Department.Querey.Results;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.DepartmentMapping 
{
    public partial class DepartmentProfile
    {
        public void GetDeptByIdMap()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Localize(src.DNameAr,src.DNameEn)))
                .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.DID))
                .ForMember(dest=>dest.ManagerName,opt=>opt.MapFrom(src=>src.Instructor.Localize(src.Instructor.ENameAr, src.Instructor.ENameEn)))
               .ForMember(dest => dest.subjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
               //.ForMember(dest => dest.studentList, opt => opt.MapFrom(src => src.Students))
               .ForMember(dest => dest.instructorList, opt => opt.MapFrom(src => src.Instructors));

            CreateMap<DepartmetSubject,SubjectResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.Localize(src.Subject.SubjectNameAr,src.Subject.SubjectNameEn)));

            //CreateMap<Student,StudentResponse>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr,src.NameEn)));

            CreateMap<Instructor,InstructorResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.ENameAr,src.ENameEn)));
        }
    }
}
