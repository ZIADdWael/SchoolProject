using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Department.Querey.Models;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
  
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetByIdDepartment([FromQuery] GetDepartmentByIdQuerey querey  )
        {
            return NewResult(await _mediator.Send(querey));
        }
    }
}
