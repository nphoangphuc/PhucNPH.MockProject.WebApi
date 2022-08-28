using FluentValidation;
using PhucNPH.MockProject.Domain.Constants;
using PhucNPH.MockProject.Domain.Models;

namespace PhucNPH.MockProject.Domain.Validation
{
	public class JobDetailCreateModelValidation : AbstractValidator<JobDetailCreateModel>
	{
		public JobDetailCreateModelValidation()
		{
			RuleFor(request => request.JobTitle)
			   .NotEmpty()
			   .WithMessage(ValidationConstants.Messages.FieldIsRequried(nameof(JobDetailCreateModel.JobTitle)))
			   .IsEnumName(typeof(JobTitle))
			   .WithMessage(ValidationConstants.Messages.MustBeEnum(nameof(JobDetailCreateModel.JobTitle), Enum.GetNames(typeof(JobTitle)).ToList()));

			RuleFor(request => request.JobLevel)
				.LessThanOrEqualTo(ValidationConstants.Constants.JobLevelMaxValue)
				.WithMessage(ValidationConstants.Messages.MaxValue(
					nameof(JobDetailCreateModel.JobLevel), 
					ValidationConstants.Constants.JobLevelMaxValue.ToString()));
		}
	}
}
