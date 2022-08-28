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
    public class EmployeeUpdateModelValidation : AbstractValidator<EmployeeUpdateModel>
    {
        public EmployeeUpdateModelValidation()
        {
            RuleFor(request => request.DOB)
               .NotEmpty()
               .WithMessage(ValidationConstants.Messages.FieldIsRequried(nameof(EmployeeUpdateModel.DOB)))
               .Must(DOB => ValidationConstants.ValidateValidDateTime(DOB))
               .WithMessage(ValidationConstants.Messages.InvalidDate(nameof(EmployeeUpdateModel.DOB)));

            RuleFor(request => request.JobDetailUpdateModel).SetValidator(new JobDetailUpdateModelValidation()).When(request => request.JobDetailUpdateModel != null);
		}

	}
}
