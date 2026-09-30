using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Command.Validation
{
    public class EditStudentValidator:AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public EditStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this._studentService = studentService;
            this._stringLocalizer = stringLocalizer;
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr).NotEmpty().WithMessage("Name Must Not Be Empty").NotNull().MaximumLength(10).WithMessage("MAx Length Is 10");
            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} Must Not Be Empty").NotNull().MaximumLength(10).WithMessage("{PropertyName} Length Is 10");

        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr).
                MustAsync(async (model,Key, CancellationToken) => !await _studentService.IsNameArExistExcludeSelf(Key,model.Id)).
                WithMessage("Name IS Exist");
            RuleFor(x => x.NameEn)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameEnExistExcludeSelf(Key, model.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);

        }
    }
}
