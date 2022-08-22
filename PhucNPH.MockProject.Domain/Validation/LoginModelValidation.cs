using FluentValidation;
using PhucNPH.MockProject.Domain.Constants;
using PhucNPH.MockProject.Domain.Models;

namespace PhucNPH.MockProject.Domain.Validation
{
    public class LoginModelValidation : AbstractValidator<LoginModel>
    {
        public LoginModelValidation()
        {
            RuleFor(request => request.Username)
                .NotEmpty()
                .WithMessage(ValidationConstants.Messages.FieldIsRequried(nameof(LoginModel.Username)));

            RuleFor(request => request.Password)
                .NotEmpty()
                .WithMessage(ValidationConstants.Messages.FieldIsRequried(nameof(LoginModel.Password)))
                .MinimumLength(ValidationConstants.Constants.PasswordMinLength)
                .WithMessage(ValidationConstants.Messages.MinLengthRequired(nameof(LoginModel.Password), ValidationConstants.Constants.PasswordMinLength));
        }
    }
}
