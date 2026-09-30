using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Querey.Models;
using SchoolProject.Core.Features.Department.Querey.Results;
using SchoolProject.Core.Features.Students.Query.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrapper;
using SchoolProject.Data.Entites;
using SchoolProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Department.Querey.Handler
{
    public class DepartmentQuereyHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdQuerey, Response<GetDepartmentByIdResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public DepartmentQuereyHandler(IStringLocalizer<SharedResources> stringLocalizer,IDepartmentService departmentService, IMapper mapper,IStudentService studentService) :base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _mapper = mapper;
            _studentService = studentService;
        }
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuerey request, CancellationToken cancellationToken)
        {
            //service Fet by id include St Sub ins
            var response= await _departmentService.GetDepartmentByID(request.Id);

            //ceck if not  Exsist
            if (response == null)
                return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.Notfound]);
            // mapping
            var mapper= _mapper.Map<GetDepartmentByIdResponse>(response);
            //Paginated
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Localize(e.NameAr, e.NameEn));
            var studentListQuerable=_studentService.GetStudentsByDepartmentIDQuerable(request.Id);
              var paginatedList = await studentListQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.studentList= paginatedList;
            // return response 
            return Success(mapper);
        }
    }
}
