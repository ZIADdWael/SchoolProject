using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Core.Features.Students.Query.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrapper;
using SchoolProject.Data.Entites;
using SchoolProject.Service.Abstract;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Query.Handler
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetStudentSingleResponse>>,
        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> _stringLocalizer): base(_stringLocalizer)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._stringLocalizer = _stringLocalizer;
        }

        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            var result= Success(studentListMapper);
            result.Meta = new { Count = studentListMapper.Count() };
            return result;
        }

        public async Task<Response<GetStudentSingleResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var std = await _studentService.GetStudentByIDAsync(request.ID);
            if (std == null)
            {

                return NotFound<GetStudentSingleResponse>(_stringLocalizer[SharedResourcesKeys.Notfound]);

            }
            else
            {
                var res = _mapper.Map<GetStudentSingleResponse>(std);
                return Success(res);
            }

        }



        async Task<PaginatedResult<GetStudentPaginatedListResponse>> IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>.Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr,e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr,e.Department.DNameEn));
            //var quarable = _studentService.GetStudentsQuerable();
            var FilterQuery = _studentService.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);
            var paginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginatedList.Meta = new {Count=paginatedList.Data.Count()};
            return paginatedList;
        }
    }
}
