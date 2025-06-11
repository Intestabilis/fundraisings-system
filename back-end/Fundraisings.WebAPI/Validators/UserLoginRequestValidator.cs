using FluentValidation;
using WebApp.Contracts.Users;

namespace WebApp.Validators;

public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
{
    public UserLoginRequestValidator()
    {
        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .EmailAddress().WithMessage("{PropertyName} must be a valid email");

        RuleFor(u => u.Password)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required");
    }
}