using FluentValidation;
using WebApp.Contracts.Equipments;

namespace WebApp.Validators;

public class EquipmentCreateRequestValidator : AbstractValidator<EquipmentCreateRequest>
{
    public EquipmentCreateRequestValidator()
    {
        RuleFor(e => e.EquipmentType)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

        RuleFor(e => e.Weight)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");
    }
}