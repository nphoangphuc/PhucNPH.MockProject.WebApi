using FluentValidation;
using PhucNPH.MockProject.Domain.Constants;
using PhucNPH.MockProject.Domain.Models;

namespace PhucNPH.MockProject.Domain.Validation
{
    public class DepartmentCreateModelValidation : AbstractValidator<DepartmentCreateModel>
    {
        public DepartmentCreateModelValidation()
        {
            RuleFor(request => request.DepartmentName)
                .NotEmpty()
                .WithMessage(ValidationConstants.Messages.FieldIsRequried(nameof(DepartmentCreateModel.DepartmentName)))
                .MinimumLength(6)
                .WithMessage(ValidationConstants.Messages.MinLengthRequired(nameof(DepartmentCreateModel.DepartmentName), ValidationConstants.Constants.DepartmentMinLength));

			RuleFor(request => request.DepartmentLocation)
				 .NotEmpty()
				 .WithMessage(ValidationConstants.Messages.FieldIsRequried(nameof(DepartmentCreateModel.DepartmentLocation)))
                 .MinimumLength(6)
                 .WithMessage(ValidationConstants.Messages.MinLengthRequired(nameof(DepartmentCreateModel.DepartmentLocation), ValidationConstants.Constants.DepartmentMinLength));
		}

    }
}
