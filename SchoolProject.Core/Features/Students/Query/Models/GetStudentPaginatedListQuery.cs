using MediatR;
using SchoolProject.Core.Features.Students.Query.Results;
using SchoolProject.Core.Wrapper;
using SchoolProject.Data.Helper;

namespace SchoolProject.Core.Features.Students.Query.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public String? Search { get; set; }

    }
}
