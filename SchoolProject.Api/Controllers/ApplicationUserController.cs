using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.ApplicationUser.Command.Model;
using SchoolProject.Core.Features.ApplicationUser.Query.Model;
using SchoolProject.Core.Features.Students.Query.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Data.AppMetaData.Router.UserRouting.Create)]

        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);

            return NewResult(response);
        }
        [HttpGet(Data.AppMetaData.Router.UserRouting.Paginated)]
        public async Task<IActionResult> GetUserPaginated([FromQuery] GetUserpaginatedQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Data.AppMetaData.Router.UserRouting.GetById)]
        public async Task<IActionResult> GetStudentByID([FromRoute] int id)
        {
            return NewResult(await _mediator.Send(new GetUserByIdQuery { Id=id}));
        }
    }
}
