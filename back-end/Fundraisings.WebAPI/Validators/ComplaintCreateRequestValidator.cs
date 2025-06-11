using FluentValidation;
using WebApp.Contracts.Complaints;

namespace WebApp.Validators;

public class ComplaintCreateRequestValidator : AbstractValidator<ComplaintCreateRequest>
{
    public ComplaintCreateRequestValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(c => c.FundraisingId)
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(c => c.Description)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(1000).WithMessage("{PropertyName} must be fewer than 1000 characters");
    }
}