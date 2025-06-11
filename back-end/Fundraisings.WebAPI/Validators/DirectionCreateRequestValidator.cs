using FluentValidation;
using WebApp.Contracts.Directions;

namespace WebApp.Validators;

public class DirectionCreateRequestValidator : AbstractValidator<DirectionCreateRequest>
{
    public DirectionCreateRequestValidator()
    {
        RuleFor(d => d.DirectionName)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

        RuleFor(d => d.Coordinates)
            .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(d => d.Weight)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");
    }
}