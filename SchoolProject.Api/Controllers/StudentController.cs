using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Core.Features.Students.Query.Models;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentController : AppControllerBase
    {


        [HttpGet(Data.AppMetaData.Router.StudentRouting.List)]
        public async Task<IActionResult> GetAllStudent()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [HttpGet(Data.AppMetaData.Router.StudentRouting.Paginated)]
        public async Task<IActionResult> GetStudentPaginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Data.AppMetaData.Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetByIdStudent([FromRoute] int id)
        {
            return NewResult(await _mediator.Send(new GetStudentByIdQuery() { ID = id }));
        }

        [HttpPost(Data.AppMetaData.Router.StudentRouting.Create)]

        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
        {

            return NewResult(await _mediator.Send(command));
        }

        [HttpPut(Data.AppMetaData.Router.StudentRouting.Edit)]

        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {
            var response = await _mediator.Send(command);


            return NewResult(response);
        }
        [HttpDelete(Data.AppMetaData.Router.StudentRouting.Delete)]

        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var response = await _mediator.Send(new DeleteStudendCommand(id));


            return NewResult(response);
        }

    }
}
