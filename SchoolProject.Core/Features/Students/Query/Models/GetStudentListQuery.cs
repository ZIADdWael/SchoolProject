using Azure;
using MediatR;
using SchoolProject.Core.Features.Students.Query.Results;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Core.Bases;
namespace SchoolProject.Core.Features.Students.Query.Models
{
    public class GetStudentListQuery:IRequest<Bases.Response<List<GetStudentListResponse>>>
    {
    }
}
