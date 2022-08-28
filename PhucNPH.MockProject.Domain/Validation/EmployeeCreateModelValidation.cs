using FluentValidation;
using PhucNPH.MockProject.Domain.Constants;
using PhucNPH.MockProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhucNPH.MockProject.Domain.Validation
{
    public class EmployeeCreateModelValidation : AbstractValidator<EmployeeCreateModel>
    {
        public EmployeeCreateModelValidation()
        {
            RuleFor(request => request.Username)
                .NotEmpty()
                .WithMessage(ValidationConstants.Messages.FieldIsRequried(nameof(EmployeeCreateModel.Username)));

            RuleFor(request => request.Password)
                .NotEmpty()
                .WithMessage(ValidationConstants.Messages.FieldIsRequried(nameof(EmployeeCreateModel.Password)))
                .MinimumLength(ValidationConstants.Constants.PasswordMinLength)
                .WithMessage(ValidationConstants.Messages.MinLengthRequired(nameof(EmployeeCreateModel.Password), ValidationConstants.Constants.PasswordMinLength));

            RuleFor(request => request.DOB)
               .NotEmpty()
               .WithMessage(ValidationConstants.Messages.FieldIsRequried(nameof(EmployeeCreateModel.DOB)))
               .Must(DOB => ValidationConstants.ValidateValidDateTime(DOB))
               .WithMessage(ValidationConstants.Messages.InvalidDate(nameof(EmployeeCreateModel.DOB)));

            RuleFor(request => request.JobDetailCreateModel).SetValidator(new JobDetailCreateModelValidation());
		}

	}
}
