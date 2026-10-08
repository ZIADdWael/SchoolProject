using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.ApplicationUser.Command.Model;
using SchoolProject.Core.Features.Students.Command.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Data.AppMetaData.Router.UserRouting.Create)]

        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response= await _mediator.Send(command);

            return NewResult(response);
        }
    }
}
