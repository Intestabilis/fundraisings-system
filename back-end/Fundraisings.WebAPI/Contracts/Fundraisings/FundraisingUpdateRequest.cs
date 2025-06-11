namespace WebApp.Contracts;

public record FundraisingUpdateRequest(
    Guid Id,
    string? Title = null,
    string? Description = null,
    decimal? GoalAmount = null,
    Guid? DirectionId = null,
    Guid? EquipmentId = null,
    string? DonationUrl = null,
    string? ImageUrl = null,
    decimal? Value = null,
    DateTime? Deadline = null
);