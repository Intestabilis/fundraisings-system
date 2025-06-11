using FluentValidation;
using WebApp.Contracts.Reports;

namespace WebApp.Validators;

public class ReportCreateRequestValidator : AbstractValidator<ReportCreateRequest>
{
    public ReportCreateRequestValidator()
    {
        RuleFor(r => r.FundraisingId)
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(r => r.Description)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(1000).WithMessage("{PropertyName} must be fewer than 1000 characters");
    }
}