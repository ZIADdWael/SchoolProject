using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Querey.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Department.Querey.Models
{
    public class GetDepartmentByIdQuerey:IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }

       
    }
}
