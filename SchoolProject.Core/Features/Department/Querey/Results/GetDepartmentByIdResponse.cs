using SchoolProject.Core.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Department.Querey.Results
{
    public class GetDepartmentByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public PaginatedResult<StudentResponse>? studentList { get; set; }
        public List<SubjectResponse>? subjectList { get; set; }
        public List<InstructorResponse>? instructorList { get; set; }
    }
    public class StudentResponse {

        public int Id { get; set; }
        public string Name { get; set; }

        public StudentResponse(int id,string name)
        {
            Id=id;
            Name=name;
        }

    }
    public class SubjectResponse {

        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class InstructorResponse {

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
