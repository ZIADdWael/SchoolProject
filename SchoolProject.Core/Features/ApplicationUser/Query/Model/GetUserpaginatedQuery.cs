using MediatR;
using SchoolProject.Core.Features.ApplicationUser.Query.Result;
using SchoolProject.Core.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Query.Model
{
    public class GetUserpaginatedQuery:IRequest<PaginatedResult<GetUserPaginatedListResponse>>
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
    }
}
