using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Command.Handler
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudendCommand, Response<string> >

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;


        public StudentCommandHandler(IStudentService studentService, IMapper mapper,IStringLocalizer<SharedResources> _tringLocalizer):base(_tringLocalizer)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._stringLocalizer = _tringLocalizer;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //MAp Between Student and Request
            var StdudentMApper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(StdudentMApper);

            if (result == "Success")
                return Created("");
            else
                return BadRequest<string>();


        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // Check If ID Is Exist Or Not
            var student = await _studentService.GetByIDWithoutIncludeAsync(request.Id);

            //return notFound
            if (student == null)
                return NotFound<string>("Student Is Not Found");

            //MAp Between Student and Request
            var StdudentMApper = _mapper.Map(request,student);

            //CallS service thaat make edit
            var result = await _studentService.EditAsync(StdudentMApper);

            //return response
            if (result == "Success")
                return Success($"Added Sucssessfully {StdudentMApper.StudID}");
            else
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudendCommand request, CancellationToken cancellationToken)
        {
            // Check If ID Is Exist Or Not
            var student = await _studentService.GetByIDWithoutIncludeAsync(request.Id);

            //return notFound
            if (student == null)
                return NotFound<string>("Student Is Not Found");

            //CallS service thaat make Delete
            var result = await _studentService.DeleteAsync(student);
            //return response
            if (result == "Success")
                return Deleted<string>($"Added Sucssessfully {request.Id}");
            else
                return BadRequest<string>();

        }
    }
}
