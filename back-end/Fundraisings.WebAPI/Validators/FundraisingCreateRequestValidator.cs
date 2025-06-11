using FluentValidation;
using WebApp.Contracts;

namespace WebApp.Validators;

public class FundraisingCreateRequestValidator : AbstractValidator<FundraisingCreateRequest>
{
    public FundraisingCreateRequestValidator()
    {
        RuleFor(f => f.Title)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        RuleFor(f => f.Description)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(600).WithMessage("{PropertyName} must be fewer than 600 characters");
        RuleFor(f => f.GoalAmount)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");
        RuleFor(f => f.VolunteerId)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(f => f.DirectionId)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(f => f.EquipmentId)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(f => f.DonationUrl)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute)).WithMessage("{PropertyName} must be a valid URL.");;
        RuleFor(x => x.Deadline)
            .GreaterThan(DateTime.UtcNow)
            .When(x => x.Deadline.HasValue)
            .WithMessage("Deadline must be in the future.");
    }
}