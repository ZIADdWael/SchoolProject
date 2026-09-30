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
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public AddStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            this._studentService = studentService;
            this._stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();

        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]).NotNull().MaximumLength(10).WithMessage("MAx Length Is 10");
            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} Must Not Be Empty").NotNull().MaximumLength(10).WithMessage("{PropertyName} Length Is 10");

        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr).
                MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key)).
                WithMessage("Name IS Exist");
            RuleFor(x => x.NameEn).
                MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key)).
                WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }
    }


}
