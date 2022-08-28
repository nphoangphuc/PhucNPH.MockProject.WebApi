using FluentValidation;
using PhucNPH.MockProject.Domain.Constants;
using PhucNPH.MockProject.Domain.Models;

namespace PhucNPH.MockProject.Domain.Validation
{
	public class JobDetailUpdateModelValidation : AbstractValidator<JobDetailUpdateModel>
	{
		public JobDetailUpdateModelValidation()
		{
			RuleFor(request => request.JobTitle)
			   .IsEnumName(typeof(JobTitle))
			   .WithMessage(ValidationConstants.Messages.MustBeEnum(nameof(JobDetailUpdateModel.JobTitle), Enum.GetNames(typeof(JobTitle)).ToList()))
			   .When(request => request != null);

			RuleFor(request => request.JobLevel)
				.LessThanOrEqualTo(ValidationConstants.Constants.JobLevelMaxValue)
				.WithMessage(ValidationConstants.Messages.MaxValue(
					nameof(JobDetailUpdateModel.JobLevel), 
					ValidationConstants.Constants.JobLevelMaxValue.ToString()))
				.When(request => request != null);
		}
	}
}
