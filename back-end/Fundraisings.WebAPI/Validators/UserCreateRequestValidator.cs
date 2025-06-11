using FluentValidation;
using WebApp.Contracts.Users;

namespace WebApp.Validators;

public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
{
    public UserCreateRequestValidator()
    {
        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .EmailAddress().WithMessage("{PropertyName} must be a valid email");

        RuleFor(u => u.Password)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(u => u.Role)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(u => u.Status)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(u => u.Name)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

        RuleFor(u => u.Surname)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
    }
}