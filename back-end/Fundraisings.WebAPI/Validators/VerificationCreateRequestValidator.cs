using FluentValidation;
using WebApp.Contracts.Verifications;

namespace WebApp.Validators;

public class VerificationCreateRequestValidator : AbstractValidator<VerificationCreateRequest>
{
    public VerificationCreateRequestValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(v => v.Description)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(1000).WithMessage("{PropertyName} must be fewer than 1000 characters");
    }
}