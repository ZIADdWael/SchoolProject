using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Command.Validation
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public AddStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer, IDepartmentService departmentService)
        {
            this._studentService = studentService;
            this._stringLocalizer = stringLocalizer;
            this._departmentService = departmentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();

        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]).NotNull().MaximumLength(10).WithMessage("MAx Length Is 10");
            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} Must Not Be Empty").NotNull().MaximumLength(10).WithMessage("{PropertyName} Length Is 10");
            RuleFor(x => x.DepartmentID).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]).NotNull();
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr).
                MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key)).
                WithMessage("Name IS Exist");
            RuleFor(x => x.NameEn).
                MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key)).
                WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);

                RuleFor(x => x.DepartmentID).
               MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIDExist(Key)).
               WithMessage(_stringLocalizer[SharedResourcesKeys.DepartmentIDNotExist]);
          
           
        }
    }


}
