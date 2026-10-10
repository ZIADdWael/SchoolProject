
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Query.Result;

namespace SchoolProject.Core.Features.ApplicationUser.Query.Model
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }

       
        
    }
}
